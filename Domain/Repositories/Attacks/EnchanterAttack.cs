using Data.Models.Heros;
using Data.Models.Monsters;

namespace Domain.Repositories.Attacks
{
    public class EnchanterAttack : IEnchanterAttack
    {
        public void PerformEnchanterAttack(Enchanter enchanter, Monster monster)
        {
            {
                int randomChance = new Random().Next(0, 100);

                if (enchanter.Mana >= 6 && randomChance > 10)
                {
                    enchanter.Mana -= 6;

                    int damage = CalculateEnchanterDamage(enchanter);
                    monster.HealthPoints -= damage;
                    Console.WriteLine($"You gave him {damage} damage");
                    Console.ReadKey();

                    if (monster.HealthPoints <= 0)
                    {
                        Console.WriteLine("You killed this one, Good Job!");
                        Console.ReadKey();
                        enchanter.HealthPoints = Math.Round(enchanter.HealthPoints + enchanter.MaxHealthPoints * 0.25, 2);
                        enchanter.Mana += 50;
                        enchanter.Experience += monster.ExperiencePrize;
                        if (enchanter.Experience > 80)
                        {
                            enchanter.Level++;
                            enchanter.HealthPoints += 10;
                            enchanter.MaxHealthPoints += 10;
                            enchanter.DamagePoints += 6;
                            enchanter.Experience -= 80;
                            enchanter.Mana += 10;
                        }
                    }
                }
                else
                {
                    if (enchanter.HealthPoints < 30 && enchanter.Mana >= 3 && randomChance <= 10)
                    {
                        enchanter.Mana -= 10;
                        enchanter.HealthPoints += 15;
                        Console.WriteLine("Since you were with health, you were recharged for some mana");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Not enough mana. You will be able to play next one.");
                        enchanter.Mana += 20;
                    }
                }
            }

            int CalculateEnchanterDamage(Enchanter enchanter)
            {
                int baseDamage = enchanter.DamagePoints;
                int totalDamage = baseDamage;

                return totalDamage;
            }
        }
    }
}
