using TapeWalker.Skills;

namespace TapeWalker.Controllers
{
    public interface Damageable
    {
        public void GetDamage(BaseSkill skill);
    }
}