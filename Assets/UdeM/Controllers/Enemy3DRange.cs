using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdeM.Skills;

namespace UdeM.Controllers { 
    public class Enemy3DRange : Enemy3D
    {
        bool _hasAttacked;
        protected override void Start()
        {
            base.Start();
            _autoAttack = new RangeAutoAttack(
                10f,
                3f,
                Resources.Load<GameObject>("Bullet"),
                gameObject,
                1f
                );
            _hasAttacked = false;
        }
        protected override void Update()
        {
            if (_isAttacking)
            {
                if (!_isExecutingAttck)
                {
                    _navigator.destination = _target.transform.position;
                }
                else
                {
                    _navigator.destination = transform.position;
                }
                if (_navigator.remainingDistance <= _autoAttack.Range)
                {
                    _navigator.destination = transform.position;
                    _isExecutingAttck = true;
                    _autoAttack.Target = _target.GetComponent<Damageable>();
                    
                    StartCoroutine(AttackAnim());

                }
                else
                {
                    _navigator.destination = _target.transform.position;
                    _isExecutingAttck = false;
                }

            }
        }

        IEnumerator AttackAnim()
        {
            if (_hasAttacked == false)
            {
                _hasAttacked = true;
                _anims.SetTrigger("Attack");
                yield return new WaitForSeconds(0.5f);
                Atack(_autoAttack);
                yield return new WaitForSeconds(5.5f);
                _hasAttacked = false;
            }
        }
    }
}