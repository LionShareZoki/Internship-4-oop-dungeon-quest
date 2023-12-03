
using Data.Models.Heroes;
using Data.Models.Monsters;

namespace Domain.Repositories.Attacks
{
    internal class WitchAttack
    {
        public (bool, bool) PerformWitchAttack(Hero hero, Witch witch)
        {
            var damage = new Random().Next(0, 100) >= 10 ? witch.DamagePoints : 0;
            hero.HealthPoints -= damage;
            if (hero.HealthPoints < 0)
            {
                return (false, false);
            }
            else if (damage == 0) return (true, true);
            else return (true, false);
        }
    }
}
