using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdeM.Skills;

namespace UdeM.Controllers { 

    public class Enemy3D : NPC3D
    {
        [SerializeField] protected bool _isExecutingAttck;
        protected AutoAttack _autoAttack;
        protected Animator _anims;

        protected override void Awake()
        {
            base.Awake();
            _isAgro = true;
            _speed = 5f;
        }

        protected override void Start()
        {
            base.Start();
            _autoAttack = new AutoAttack(10f, 2f);
            _anims = transform.Find("Animations").GetComponent<Animator>();
        }

        protected override void Update() {
            base.Update();
            _navigator.destination = _target.transform.position;

            if (_isAttacking == true)
            {
                _navigator.isStopped = false;
                _anims.SetBool("IsWalking", true);
                if (_navigator.remainingDistance <= 2f)
                {
                    JaneDowController playerController = _target.GetComponent<JaneDowController>();
                    playerController.GetDamage(_autoAttack);
                    _anims.SetTrigger("Attack");
                }
            } else if (_isAttacking == false)
            {
                _navigator.isStopped = true;
                _anims.SetBool("IsWalking", false);
            }
            
            
        }

        protected void OnTriggerEnter(Collider collider)
        {
            if(collider.gameObject == _target)
            {
                _isAttacking = true;            
            }
        }

        protected void OnTriggerExit(Collider collider)
        {
            if (collider.gameObject == _target)
            {
                _isAttacking = false;
            }
        }
    }
}