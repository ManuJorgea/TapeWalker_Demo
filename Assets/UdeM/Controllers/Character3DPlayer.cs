using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdeM.Skills;


namespace UdeM.Controllers { 

    public class Character3DPlayer : Character3D, Damageable {

        protected float _axisH;
        protected float _axisV;
        [SerializeField] GameObject particulas;
        protected bool _hasBeenAttacked;
        protected int _hp;
        [SerializeField] protected GameObject particulas2;

        protected override void Start()
        {
            base.Start();
            _hasBeenAttacked = false;
            _hp = 3;
        }

        protected override void Update()
        {
            base.Update();

            _axisH = Input.GetAxis("Horizontal");
            _axisV = Input.GetAxis("Vertical");

            _direction = new Vector3(_axisH, 0, _axisV).normalized;

            //Debug.Log(_direction.magnitude);

            if (_direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);

                transform.rotation = Quaternion.Euler(0, angle, 0);
                Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
                _cc.Move(moveDir.normalized * _speed * Time.deltaTime);
            }

            /*if (_isGrounded && Input.GetButtonDown("Jump"))
            {
                Jump();
            }*/

            /*if (_isGrounded && Input.GetButtonDown("Punch"))
            {
                Punch();
            }*/
        }

        public void GetDamage(BaseSkill skill)
        {
            StartCoroutine(MeleeDmg());
        }

        public void GetDamageRange(BaseSkill skill)
        {
            StartCoroutine(AttackRange());
        }

        IEnumerator AttackRange()
        {
            _speed = 3f;
            GameObject _particulas = Instantiate(particulas, transform.position, Quaternion.identity);
            _particulas.transform.position = transform.position;
            yield return new WaitForSeconds(5f);
            _speed = 10f;
        }

        IEnumerator MeleeDmg()
        {
            if (_hasBeenAttacked == false)
            {
                _hasBeenAttacked = true;
                _hp = _hp-1;
                Instantiate(particulas2, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(3f);
                _hasBeenAttacked = false;

            }
        }

    }
}