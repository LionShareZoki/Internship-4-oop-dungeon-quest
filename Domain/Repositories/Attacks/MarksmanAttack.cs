using Data.Models.Heros;
using Data.Models.Monsters;

using Domain.Repositories.Attack_Interfaces;

namespace Domain.Repositories.Attacks
{
    public class MarksmanAttack : IMarksmanAttack
    {
        public void PerformMarksmanAttack(Marksman marksman, Monster monster)
        {
            int randomChance1 = new Random().Next(0, 100);

            bool isCritical = randomChance1 <= marksman.CriticalChance;

            int randomChance2 = new Random().Next(0, 100);


            bool isStun = randomChance2 <= marksman.StunChance;

            int damage = CalculateMarksmanDamage(marksman, isCritical);
            if (isCritical)
            {
                Console.WriteLine("Critical strike!");
                Console.ReadLine();
            }
            if (isStun)
            {
                Console.WriteLine("You stunned the monster!");
                Console.ReadKey();
                monster.IsStunned = true;
            }
            Console.WriteLine($"You gave him {damage} damage");
            Console.ReadKey();
            monster.HealthPoints -= damage;


            if (monster.HealthPoints <= 0)
            {
                Console.WriteLine("You killed this one, Good Job!");
                Console.ReadKey();
                marksman.HealthPoints = Math.Round(marksman.HealthPoints + marksman.MaxHealthPoints * 0.25, 2);
                marksman.Experience += monster.ExperiencePrize;
                if (marksman.Experience > 80)
                {
                    marksman.Level++;
                    marksman.HealthPoints += 10;
                    marksman.MaxHealthPoints += 10;
                    marksman.DamagePoints += 10;
                    marksman.Experience -= 80;
                    marksman.CriticalChance += 5;
                    marksman.StunChance += 5;
                }
            }
            if (isStun && monster.HealthPoints > 0)
            {
                monster.IsStunned = true;
                Console.WriteLine("Since the monster is stunned, you are attacking again!");
                PerformMarksmanAttack(marksman, monster);
                monster.IsStunned = false;
            }

        }

        private int CalculateMarksmanDamage(Marksman marksman, bool isCritical)
        {
            int baseDamage = marksman.DamagePoints;
            int totalDamage = isCritical ? baseDamage * 2 : baseDamage;

            return totalDamage;
        }
    }
}
