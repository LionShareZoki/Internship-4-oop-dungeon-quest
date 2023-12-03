using Data.Models.Heroes;
using Data.Models.Monsters;
using Data.Repositories;

using Domain.Repositories;

namespace Presentation.Classes
{
    internal class GameMonitor
    {
        public static void GameDataMonitor(Hero hero, List<Monster> monsters)
        {
            Console.WriteLine($"{hero.Name}:");
            Console.WriteLine($"Health points: {hero.HealthPoints}");
            Console.WriteLine($"Experience: {hero.Experience}");
            Console.WriteLine($"Level: {hero.Level}");

            Console.WriteLine($"{monsters[0].Name}:");
            Console.WriteLine($"Health points: {monsters[0].HealthPoints}");

            Console.WriteLine($"There is {monsters.Count} left to fight against.");
        }
    }
}
