using Data.Models.Heros;
using Data.Models.Monsters;

namespace Domain.Repositories.Attacks
{
    public static class GladiatorAttack
    {
        public static int GetGladiatorAttackDamage(Gladiator gladiator, Monster monster)
        {
            int baseDamage = gladiator.DamagePoints;

            bool shouldRage = gladiator.RageChance > new Random().Next(0, 100) && gladiator.HealthPoints >= 0.1 * gladiator.HealthPoints;

            int totalDamage = shouldRage ? baseDamage * 2 : baseDamage;

            if (shouldRage) gladiator.HealthPoints -= gladiator.HealthPoints * 0.1;


            if (monster.HealthPoints <= 0)
            {
                gladiator.HealthPoints += gladiator.HealthPoints * 0.25;
                gladiator.Experience += monster.ExperiencePrize;
                if (gladiator.Experience > 80) 
                {
                    gladiator.Level++;
                    gladiator.HealthPoints += 10;    
                    gladiator.DamagePoints += 3;
                };
            }

            return totalDamage;
        }
    }
}
