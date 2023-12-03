using Data.Models.Heroes;
using Data.Models.Monsters;

namespace Domain.Repositories.Attacks
{
    public static class WitchAttack
    {
        public static void PerformWitchAttack(Hero hero, Witch witch, List<Monster> monsters, MonstersGenerator monstersGenerator)
        {
            var damage = new Random().Next(0, 100) >= 10 ? witch.DamagePoints : 0;
            hero.HealthPoints -= damage;
            Console.WriteLine($"Witch gave you {damage} damage");
            Console.ReadKey();
            if (damage == 0) PerformDumbus(hero, monsters);
            if (hero.HealthPoints <= 0) Console.WriteLine("You lost :(");

        }

        private static void PerformDumbus(Hero hero, List<Monster> monsters)
        {
            Console.WriteLine($"Witch performing dumbus...");
            Console.ReadKey();
            hero.HealthPoints = new Random().Next(20, 140);
            foreach (var monster in monsters)
            {
                monster.HealthPoints = new Random().Next(5, 100);
            }
        }
    }
}
