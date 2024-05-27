using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdeM.Skills;

namespace UdeM.Controllers
{
    public abstract class EntityController : MonoBehaviour
    {
        protected float _speed;
        protected float _currentSpeed;
        protected float _jumpForce;
        //protected float _punchForce;
        protected float _gravityMod;
        

        protected LayerMask _terrainLayer;

        [SerializeField] protected GameObject _target;
        [SerializeField] protected bool _isGrounded;
        [SerializeField] protected bool _isFalling;
        [SerializeField] public bool _isCrouching;

        protected Dictionary<BaseSkill, bool> _coolDownDic;


        protected virtual void Awake() {
            _speed = 10f;
            _jumpForce = 10f;
            //_punchForce = 10f;
            _gravityMod = 1f;
            _isGrounded = false;
            _isCrouching = false;
            _coolDownDic = new Dictionary<BaseSkill, bool>();

            _terrainLayer = LayerMask.NameToLayer("Terrain");
            if ( _terrainLayer == -1) {
                Debug.LogWarning("El layer de terreno no ha sido encontrado");
            }

        }
        protected virtual void Start () { }

        protected virtual void Update () { }

        protected virtual void FixedUpdate() { }

        protected virtual void LateUpdate() { }

        protected virtual void Jump() { }

        //protected virtual void Punch() { }

        public virtual void Crouch() { }

        protected virtual void StartFall() { }

        protected virtual void Atack(BaseSkill skill) {
            if ( !_coolDownDic.ContainsKey(skill)) {
                _coolDownDic.Add(skill, true);            
            }
            if (_coolDownDic[skill])
            {
                skill.DoAtack();
                StartCoroutine(SkillCoolDown(skill));
            }
        }

        IEnumerator SkillCoolDown(BaseSkill skill)
        {
            _coolDownDic[skill] = false;
            yield return new WaitForSeconds(skill.CoolDown);
            _coolDownDic[skill] = true;
        }
    }
}
