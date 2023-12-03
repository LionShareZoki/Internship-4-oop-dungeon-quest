using Data.Enums;
using Data.Models.Monsters;
using Data.Repositories;

using Domain.Repositories;
using Domain.Services;

namespace Presentation.Classes
{
    internal class Round
    {
        public static void RoundAction(List<Monster> monsters)
        {
            Console.Clear();
            while (HeroGenerator.createdHeroes[0].HealthPoints > 0 && monsters.Count > 0)
            {
                Console.Clear();
                GameMonitor.GameDataMonitor(HeroGenerator.createdHeroes[0], monsters);
                Console.WriteLine("It's your turn to play: Direct, Side, or Counter");
                var heroChoice = Console.ReadLine();

                if (Enum.TryParse<Attack>(heroChoice, ignoreCase: true, out var attackChoice))
                {
                    Console.WriteLine($"You have chosen: {attackChoice}");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose Direct, Side, or Counter.");
                    Console.ReadKey();
                }

                Attack[] possibleMonsterChoices = { Attack.Direct, Attack.Side, Attack.Counter };
                Random random = new Random();
                var monsterChoice = possibleMonsterChoices[random.Next(possibleMonsterChoices.Length)];

                Console.WriteLine($"{monsters[0].Name} has chosen: {monsterChoice}");
                Console.ReadKey();
                bool heroOrMonster = false;
                if (attackChoice == monsterChoice)
                {
                    Console.WriteLine("Both of you choose the same attack... Let's do it again!");
                    Console.ReadKey();
                }
                else if ((attackChoice == Attack.Direct && monsterChoice == Attack.Side) || (attackChoice == Attack.Side && monsterChoice == Attack.Counter) || (attackChoice == Attack.Counter && monsterChoice == Attack.Direct))
                {
                    heroOrMonster = false;
                    Console.WriteLine($"{HeroGenerator.createdHeroes[0].Name} attacking...");
                    Console.ReadKey();
                    var gameService = new GameService(HeroGenerator.createdHeroes[0], monsters, new MonstersGenerator(), heroOrMonster);
                }
                else if ((monsterChoice == Attack.Direct && attackChoice == Attack.Side) || (monsterChoice == Attack.Side && attackChoice == Attack.Counter) || (monsterChoice == Attack.Counter && attackChoice == Attack.Direct))
                {
                    heroOrMonster = true;
                    Console.WriteLine($"{monsters[0].Name} attacking...");
                    Console.ReadKey();
                    var gameService = new GameService(HeroGenerator.createdHeroes[0], monsters, new MonstersGenerator(), heroOrMonster);
                }
            }
        }
    }
}
