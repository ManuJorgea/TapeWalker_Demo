using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TapeWalker.Skills
{ 

    public class BaseSkill{
        protected float _coolDown;
        protected float _atckDamage;
        protected float _range;
        protected string _name;

        public BaseSkill
            (string name,
            float coolDown,
            float atckDamage,
            float range)
        {
            _name = name;
            _coolDown = coolDown;
            _atckDamage = atckDamage;
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


        public float Range
        { 
            get { return _range; } 
        }

        public virtual void DoAtack() { }
    }

}
