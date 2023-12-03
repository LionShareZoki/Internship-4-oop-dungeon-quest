using Data.Models.Heros;
using Data.Models.Monsters;

namespace Domain.Repositories.Attacks
{
    public static class EnchanterAttack
    {
        public static void PerformEnchanterAttack(Enchanter enchanter, Monster monster)
        {
            int randomChance = new Random().Next(0, 100);

            if (enchanter.Mana >= 6 && randomChance > 10)
            {
                enchanter.Mana -= 6;

                int damage = CalculateEnchanterDamage(enchanter);
                monster.HealthPoints -= damage;

                if (monster.HealthPoints <= 0)
                {
                    Console.WriteLine("You killed this one, Good Job!");
                    Console.ReadKey();
                    enchanter.HealthPoints += enchanter.HealthPoints * 0.05;
                    enchanter.Mana += 100;
                    enchanter.Experience += monster.ExperiencePrize;
                    if (enchanter.Experience > 80)
                    {
                        enchanter.Level++;
                        enchanter.HealthPoints += 10;
                        enchanter.DamagePoints += 6;
                        enchanter.Experience -= 80;
                    }
                }
            }
            else
            {
                if (enchanter.HealthPoints < 30 && enchanter.Mana >= 3 && randomChance <= 10)
                {
                    enchanter.Mana -= 10;
                    enchanter.HealthPoints += 15;
                }
                else
                {
                    enchanter.Mana += 20;
                }
            }
        }

        private static int CalculateEnchanterDamage(Enchanter enchanter)
        {
            int baseDamage = enchanter.DamagePoints;
            int totalDamage = baseDamage;

            return totalDamage;
        }
    }
}
