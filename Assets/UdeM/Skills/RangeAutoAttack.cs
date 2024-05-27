using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UdeM.Controllers;
using UnityEngine;

namespace UdeM.Skills { 
    public class RangeAutoAttack : AutoAttack
    {
        protected GameObject _bullet;
        protected GameObject _bulletSpawn;
        protected float _speed;

        public RangeAutoAttack(
            float atckDamage,
            float range,
            GameObject bullet,
            GameObject bulletSawn,
            float speed) :
        base(atckDamage, range)
        {
            _bullet = bullet;
            _speed = 5f;
            _bulletSpawn = bulletSawn;
            _coolDown = 6f;
        }

        public override void DoAtack()
        {
            if (_target != null)
            {
                GameObject bulletClone = GameObject.Instantiate(_bullet,
                _bulletSpawn.transform.position, Quaternion.identity);
                BulletBehaviour bb = bulletClone.AddComponent<BulletBehaviour>();
                bb.target = _target.ConvertTo<GameObject>();
                bb.speed = _speed;
                bb.skill = this;
                SphereCollider sc = bulletClone.AddComponent<SphereCollider>();
                sc.isTrigger = true;
            }
        }

         public class BulletBehaviour : MonoBehaviour
         {
            public GameObject target;
            public BaseSkill skill;
            public float speed;

            void Update()
            { 
                Vector3 direction = target.transform.position - transform.position;
                transform.Translate(direction * Time.deltaTime * speed);
            }

            void OnTriggerEnter (Collider other)
            {
                if (other.gameObject == target) {
                    target.GetComponent<Damageable>().GetDamageRange(skill);
                    Destroy(gameObject);
                }
            }

            private void OnCollisionEnter(Collision collision)
            {
                Destroy(gameObject);
            }
        }

    }
}