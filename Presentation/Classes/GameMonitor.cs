using Data.Models.Heroes;
using Data.Models.Heros;
using Data.Models.Monsters;

using Presentation.Interfaces;

namespace Presentation.Classes
{
    internal class GameMonitor : IGameMonitor
    {
        public void GameDataMonitor(Hero hero, List<Monster> monsters)
        {
            Console.WriteLine($"{hero.Name}:");
            Console.WriteLine("");
            Console.WriteLine($"HP: {hero.HealthPoints}");
            Console.WriteLine($"Damage: {hero.DamagePoints}");
            if (hero is Enchanter enchanter) Console.WriteLine($"Mana: {enchanter.Mana}");
            if (hero is Marksman marksman)
            {
                Console.WriteLine($"Critical chance: {marksman.CriticalChance}");
                Console.WriteLine($"Critical chance: {marksman.CriticalChance}");
            }
            Console.WriteLine($"XP: {hero.Experience}");
            Console.WriteLine($"Level: {hero.Level}");
            Console.WriteLine("------------------");
            Console.WriteLine($"{monsters[0].Name}:");
            Console.WriteLine("");
            Console.WriteLine($"HP: {monsters[0].HealthPoints}");
            Console.WriteLine($"Damage: {monsters[0].DamagePoints}");
            Console.WriteLine($"There is {monsters.Count} left to fight against.");
            Console.WriteLine("");
        }
    }
}
