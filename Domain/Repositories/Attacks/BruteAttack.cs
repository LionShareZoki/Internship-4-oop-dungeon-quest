
using Data.Models.Heroes;
using Data.Models.Monsters;

namespace Domain.Repositories.Attacks
{
    public static class BruteAttack
    {
        public static void PerformBruteAttack(Hero hero, Brute brute)
        {
            var damage = new Random().Next(0, 100) >= 10 ? brute.DamagePoints : hero.HealthPoints * (brute.DamagePoints / 100);
            hero.HealthPoints -= damage;
            Console.WriteLine($"Brute gave you {damage} damage");
            Console.ReadKey();
            if (hero.HealthPoints <= 0)
            {
                Console.WriteLine("You lost :(");
                Console.ReadKey();
            }
        }
    }
}
