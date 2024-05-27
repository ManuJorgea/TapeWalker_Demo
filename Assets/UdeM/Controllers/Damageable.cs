
using UdeM.Skills;

namespace UdeM.Controllers { 
    public interface Damageable{
        public void GetDamage(BaseSkill skill);
        public void GetDamageRange(BaseSkill skill);
    }
}