using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdeM.Controllers;

namespace UdeM.Skills {

    public class TargetShot : BaseSkill
    {
        protected Damageable _target;

        public TargetShot
            (string name,
            float coolDown,
            float atckDamage,
            float mgkDamage,
            float range) : base(name, coolDown, atckDamage, mgkDamage, range)
        {
            _target = null;
        }

        public override void DoAtack()
        {
            base.DoAtack();
            if ( _target != null )
            {
                _target.GetDamage(this);
            }
        }

        public Damageable Target
        {
            get { return _target; }
            set { _target = value; }
        }
    }
}
