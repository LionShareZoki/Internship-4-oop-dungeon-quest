
using Data.Models.Heroes;
using Data.Models.Monsters;

namespace Domain.Repositories.Attacks
{
    internal class BruteAttack
    {
        public bool PerformBruteAttack(Hero hero, Brute brute)
        {
            var damage = new Random().Next(0, 100) >= 10 ? brute.DamagePoints : hero.HealthPoints * (brute.DamagePoints / 100);
            hero.HealthPoints -= damage;
            if (hero.HealthPoints < 0)
            {
                return false;
            }
            else return true;
        }
    }
}
