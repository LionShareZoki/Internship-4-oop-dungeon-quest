using Data.Enums;
using Data.Models.Monsters;
using Data.Repositories;

using Domain.Repositories;
using Domain.Services;

using Presentation.Interfaces;

namespace Presentation.Classes
{
    internal class Round : IRound
    {
        public void RoundAction(List<Monster> monsters)
        {
            var hero = HeroGenerator.createdHeroes[0];
            Console.Clear();
            while (HeroGenerator.createdHeroes[0].HealthPoints > 0 && monsters.Count > 0)
            {
                if (hero.Experience >= 20 && hero.MaxHealthPoints < hero.MaxHealthPoints * 0.5)
                {
                    Console.WriteLine("Do you want to buy your full HP for half of your XP?(Y/N)");
                    var answer = Console.ReadLine().ToUpper();
                    BuyHP buyHp = new BuyHP(hero);
                    if (answer is "Y")
                    {
                        buyHp.BuyHealthPoints(hero);
                    }
                }
                Console.Clear();
                var gameMonitor = new GameMonitor();
                gameMonitor.GameDataMonitor(hero, monsters);
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
                    Console.WriteLine("You are attacking...");
                    Console.ReadKey();
                    heroOrMonster = false;
                    var gameService = new GameService();
                    gameService.PlayGame(hero, monsters, new MonstersGenerator(), heroOrMonster);
                }
                else if ((monsterChoice == Attack.Direct && attackChoice == Attack.Side) || (monsterChoice == Attack.Side && attackChoice == Attack.Counter) || (monsterChoice == Attack.Counter && attackChoice == Attack.Direct))
                {
                    Console.WriteLine($"{monsters[0].Name} attacking...");
                    heroOrMonster = true;
                    var gameService = new GameService();
                    gameService.PlayGame(hero, monsters, new MonstersGenerator(), heroOrMonster);
                }
            }
        }
    }
}