using Data.Models.Heros;
using Data.Models.Monsters;

using Domain.Repositories.Attack_Interfaces;

namespace Domain.Repositories.Attacks
{
    public class GladiatorAttack : IGladiatorAttack
    {
        public int GetGladiatorAttackDamage(Gladiator gladiator, Monster monster)
        {
            int baseDamage = gladiator.DamagePoints;

            bool shouldRage = gladiator.RageChance > new Random().Next(0, 100) && gladiator.HealthPoints >= 0.1 * gladiator.HealthPoints;

            int totalDamage = shouldRage ? baseDamage * 2 : baseDamage;

            if (shouldRage)
            {
                gladiator.HealthPoints -= gladiator.MaxHealthPoints * 0.1;
                Console.WriteLine($"You hit him with the Rage!");
                Console.ReadKey();
            }
            monster.HealthPoints -= totalDamage;
            Console.WriteLine($"You gave him {totalDamage} damage");
            Console.ReadKey();

            if (monster.HealthPoints <= 0)
            {
                Console.WriteLine("You killed this one, Good Job!");
                Console.ReadKey();
                gladiator.HealthPoints = Math.Round(gladiator.HealthPoints + gladiator.MaxHealthPoints * 0.25, 2);
                gladiator.Experience += monster.ExperiencePrize;
                if (gladiator.Experience > 80)
                {
                    gladiator.Level++;
                    gladiator.HealthPoints += 10;
                    gladiator.MaxHealthPoints += 10;
                    gladiator.DamagePoints += 3;
                    gladiator.Experience -= 80;
                };
            }

            return totalDamage;
        }
    }
}
