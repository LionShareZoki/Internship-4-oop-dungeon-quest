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
            monster.HealthPoints -= totalDamage;
            Console.WriteLine($"You gave him {totalDamage} and his health now is {monster.HealthPoints}");

            if (monster.HealthPoints <= 0)
            {
                Console.WriteLine("You killed this one, Good Job!");
                Console.ReadKey();
                gladiator.HealthPoints += gladiator.HealthPoints * 0.05;
                gladiator.Experience += monster.ExperiencePrize;
                if (gladiator.Experience > 80)
                {
                    gladiator.Level++;
                    gladiator.HealthPoints += 10;
                    gladiator.DamagePoints += 3;
                    gladiator.Experience -= 80;
                };
            }

            return totalDamage;
        }
    }
}
