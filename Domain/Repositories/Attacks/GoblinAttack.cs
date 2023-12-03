
using Data.Models.Heroes;
using Data.Models.Monsters;

namespace Domain.Repositories.Attacks
{
    internal class GoblinAttack
    {
        public bool PerformGoblinAttack(Hero hero, Goblin goblin)
        {
            hero.HealthPoints -= goblin.DamagePoints;
            if (hero.HealthPoints < 0)
            {
                return false;
            }
            else return true;
        }
    }
}
