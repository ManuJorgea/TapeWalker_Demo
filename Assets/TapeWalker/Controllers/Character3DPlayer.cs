using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TapeWalker.Skills;

namespace TapeWalker.Controllers
{

    public class Character3DPlayer : Character3D, Damageable
    {

        protected float _axisH;
        protected float _axisV;

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


            /*
            if (_isGrounded && Input.GetButtonDown("Jump"))
            {
                Jump();
            }
            

            if (_isTaking && Input.GetButtonDown("E"))
            {
                TakeVHS();
            }
            */
            
        }

        public void GetDamage(BaseSkill skill)
        {
            Debug.Log("Ay me pegaste estupida. Me quitaste");
        }
    }
}
