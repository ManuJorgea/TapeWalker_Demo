using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TapeWalker.Controllers
{
    public class NPC3D : EntityController
    {
        protected float _signRange;
        [SerializeField] protected bool _isAgro;
        [SerializeField] protected bool _isAttacking;

        protected NavMeshAgent _navigator;


        protected override void Awake()
        {
            base.Awake();
            _signRange = 6f;
            _isAttacking = false;
        }

        protected override void Start()
        {
            base.Start();
            CreateSignTrigger();
            _navigator = GetComponent<NavMeshAgent>();
            if (_navigator == null)
            {
                Debug.Log("NavMeshAgent no esta presente");
            }
        }

        protected void CreateSignTrigger()
        {
            SphereCollider collider = gameObject.AddComponent<SphereCollider>();
            collider.isTrigger = true;
            collider.radius = _signRange;
        }

        protected override void Punch()
        {
            base.Punch();
        }
    }
}
