using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TapeWalker.Controllers;

namespace TapeWalker.Skills
{

    public class TargetShot : BaseSkill
    {
        protected Damageable _target;

        public TargetShot
            (string name,
            float coolDown,
            float atckDamage,
            float range) : base(name, coolDown, atckDamage, range)
        {
            _target = null;
        }

        public override void DoAtack()
        {
            base.DoAtack();
            if (_target != null)
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
