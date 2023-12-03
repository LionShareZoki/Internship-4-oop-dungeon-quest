using Data.Models.Heros;
using Data.Models.Monsters;

namespace Domain.Repositories.Attacks
{
    public static class MarksmanAttack
    {
        public static void PerformMarksmanAttack(Marksman marksman, Monster monster)
        {
            int randomChance1 = new Random().Next(0, 100);

            bool isCritical = randomChance1 <= marksman.CriticalChance;

            int randomChance2 = new Random().Next(0, 100);


            bool isStun = randomChance2 <= marksman.StunChance;

            int damage = CalculateMarksmanDamage(marksman, isCritical);
            if (isCritical) Console.WriteLine("Critical strike!");
            Console.ReadKey();
            if (isStun) Console.WriteLine("You stunned the monster!");
            Console.ReadKey();
            Console.WriteLine($"You gave him {damage} damage");
            Console.ReadKey();
            monster.HealthPoints -= damage;

            if (isStun)
            {
                monster.IsStunned = true;
            }
            else if (monster.HealthPoints <= 0)
            {
                Console.WriteLine("You killed this one, Good Job!");
                Console.ReadKey();
                marksman.HealthPoints += marksman.HealthPoints * 0.05;
                marksman.Experience += monster.ExperiencePrize;
                if (marksman.Experience > 80)
                {
                    marksman.Level++;
                    marksman.HealthPoints += 10;
                    marksman.DamagePoints += 10;
                    marksman.Experience -= 80;
                }
            }
        }

        private static int CalculateMarksmanDamage(Marksman marksman, bool isCritical)
        {
            int baseDamage = marksman.DamagePoints;
            int totalDamage = isCritical ? baseDamage * 2 : baseDamage;

            return totalDamage;
        }
    }
}
