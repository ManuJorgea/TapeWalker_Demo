using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdeM.Skills { 

    public class BaseSkill{
        protected float _coolDown;
        protected float _atckDamage;
        protected float _mgkDamage;
        protected float _range;
        protected string _name;

        public BaseSkill
            (string name,
            float coolDown,
            float atckDamage,
            float mgkDamage,
            float range)
        {
            _name = name;
            _coolDown = coolDown;
            _atckDamage = atckDamage;
            _mgkDamage = mgkDamage;
            _range = range;

        }

        public string Name
        {
            get { return _name; }
        }

        public float CoolDown
        {
            get { return _coolDown; }
        }

        public float AtckDamage
        {
            get { return _atckDamage; } 
        }

        public float MgkDamage
        {
            get { return _mgkDamage; } 
        }

        public float Range
        { 
            get { return _range; } 
        }

        public virtual void DoAtack() { }
    }

}
