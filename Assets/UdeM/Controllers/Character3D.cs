using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdeM.Controllers { 

    public class Character3D : EntityController
    {
        protected CharacterController _cc;

        [SerializeField] protected float _high;

        protected float _gravity = -0.981f;

        protected float _velYGrounded = -0.181f;
        protected float _lastYPos;

        protected Vector3 _velocity;
        protected Vector3 _direction;

        protected float _turnSmoothTime;
        protected float _turnSmoothVelocity;

        protected override void Awake()
        {
            base.Awake();
            _turnSmoothTime = 0.2f;
            _turnSmoothVelocity = 0f;
            _jumpForce = 0.03f;
            _cc = gameObject.GetComponent<CharacterController>();

            if (_cc == null )
            {
                Debug.LogError("Debe tener el CharacterController attached");
            }

        }

        protected override void Start()
        {
            base.Start();
            _lastYPos = transform.position.y;
            StartCoroutine("HighVerify");
        }

        protected override void Update()
        {
            base.Update();
            _isGrounded = _cc.isGrounded;

            if (_lastYPos > transform.position.y && !_isGrounded)
            {
                if (!_isFalling)
                {
                    StartFall();
                }
                _isFalling = true;
            }else
            {
                _isFalling = false;
            }
            
        }

        IEnumerator HighVerify() {
            yield return new WaitForSeconds(0.1f);
            _lastYPos = transform.position.y;
            StartCoroutine("HighVerify");
        
        }

        protected override void LateUpdate() {
            base.LateUpdate();

            /* Velocity Y */
            _velocity.y += _gravity * Time.deltaTime;

            if (_isGrounded && _velocity.y < 0)
            {
                _velocity.y = _velYGrounded;
            }

            _cc.Move(_velocity);
        }

        protected override void Jump()
        {
            base.Jump();

            _velocity.y = Mathf.Sqrt(_jumpForce * -2 * _gravity);
        }

        /*protected override void Punch()
        {
            base.Punch();
        }*/

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            DetectHigh();
        }

        protected virtual void DetectHigh()
        {
            RaycastHit[] hits = Physics.RaycastAll(transform.position, Vector3.down, Mathf.Infinity);

            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                if (hit.collider.gameObject != this.gameObject)
                {
                    _high = hit.distance;
                    return;
                }
            }

        }

    }

}
