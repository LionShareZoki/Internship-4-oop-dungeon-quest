using Data.Enums;
using Data.Models.Heroes;
using Data.Models.Heros;
using Data.Models.Monsters;
using Data.Repositories;

using Presentation.Classes;
using Presentation.Repositories;

namespace HeroGeneratorConsole
{
    internal partial class Program
    {
        private static void Main()
        {
            ConsoleHelper consoleHelper = new ConsoleHelper();
            Round round = new Round();

            var mainMenuOptions = new Dictionary<int, Action>
            {
                { 1, () => CreateHeroAndGenerateMonsters(consoleHelper) },
                { 2, ExitGame }
            };

            while (true)
            {
                consoleHelper.PrintMenu(mainMenuOptions, "Are you ready to create your hero? (1-yes/2-no)");
            }
        }

        private static void CreateHeroAndGenerateMonsters(ConsoleHelper consoleHelper)
        {
            GenerateHero(consoleHelper);

            MonsterConsole monsterConsole = new MonsterConsole();
            List<Monster> monsters = monsterConsole.RunMonsterConsole();
            Round.RoundAction(monsters);
        }

        private static void GenerateHero(ConsoleHelper consoleHelper)
        {
            Console.Clear();
            Console.WriteLine("What would you like to be called?");
            string name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Choose a hero type:");
            Dictionary<int, Action> heroTypeMenu = new Dictionary<int, Action>
            {
                { 1, () => GenerateHero(HerosType.Gladiator, consoleHelper, name) },
                { 2, () => GenerateHero(HerosType.Enchanter, consoleHelper, name) },
                { 3, () => GenerateHero(HerosType.Marksman, consoleHelper, name) }
            };

            consoleHelper.PrintMenu(heroTypeMenu, "1 => Gladiator, 2 => Enchanter, 3 => Marksman");
        }

        private static void GenerateHero(HerosType selectedHeroType, ConsoleHelper consoleHelper, string name)
        {
            Console.Clear();
            Console.WriteLine("Do you want to customize HealthPoints? (Y/N)");
            int HPInput = Console.ReadLine()?.ToUpper() == "Y" ? consoleHelper.UserInput() : 0;

            Console.Clear();
            Console.WriteLine("Do you want to customize DamagePoints? (Y/N)");
            int DMGInput = Console.ReadLine()?.ToUpper() == "Y" ? consoleHelper.UserInput() : 0;

            HeroGenerator heroGenerator = new HeroGenerator(selectedHeroType, HPInput, DMGInput, name);
            Hero hero = heroGenerator.GenerateHero(selectedHeroType, HPInput, DMGInput, name);

            Console.Clear();
            DisplayHeroInfo(hero);
        }

        private static void ExitGame()
        {
            Console.WriteLine("Exiting the game. Goodbye!");
            Environment.Exit(0);
        }

        private static void DisplayHeroInfo(Hero hero)
        {
            Console.WriteLine($"Hero Type: {hero.GetType().Name}");
            Console.WriteLine($"HealthPoints: {hero.HealthPoints}");
            Console.WriteLine($"DamagePoints: {hero.DamagePoints}");

            if (hero is Gladiator gladiator)
            {
                Console.WriteLine($"RageChance: {gladiator.RageChance}");
            }
            else if (hero is Enchanter enchanter)
            {
                Console.WriteLine($"Mana: {enchanter.Mana}");
            }
            else if (hero is Marksman marksman)
            {
                Console.WriteLine($"CriticalChance: {marksman.CriticalChance}");
                Console.WriteLine($"StunChance: {marksman.StunChance}");
            }

            Console.ReadKey();
        }
    }
}
