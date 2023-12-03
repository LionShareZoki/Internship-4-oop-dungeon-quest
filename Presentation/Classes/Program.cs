using Data.Enums;
using Data.Models.Heroes;
using Data.Models.Heros;
using Data.Repositories;

using Presentation.Repositories;

namespace HeroGeneratorConsole
{
    internal partial class Program
    {
        private static void Main()
        {
            ConsoleHelper consoleHelper = new ConsoleHelper();

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

            // After hero creation, automatically generate monsters
            MonsterConsole monsterConsole = new MonsterConsole();
            monsterConsole.RunMonsterConsole();
        }

        private static void GenerateHero(ConsoleHelper consoleHelper)
        {
            Console.WriteLine("Choose a hero type:");
            Dictionary<int, Action> heroTypeMenu = new Dictionary<int, Action>
            {
                { 1, () => GenerateHero(HerosType.Gladiator, consoleHelper) },
                { 2, () => GenerateHero(HerosType.Enchanter, consoleHelper) },
                { 3, () => GenerateHero(HerosType.Marksman, consoleHelper) }
            };

            consoleHelper.PrintMenu(heroTypeMenu, "");
        }

        private static void GenerateHero(HerosType selectedHeroType, ConsoleHelper consoleHelper)
        {
            Console.WriteLine("Do you want to customize HealthPoints? (Y/N)");
            int HPInput = Console.ReadLine()?.ToUpper() == "Y" ? consoleHelper.UserInput() : 0;

            Console.WriteLine("Do you want to customize DamagePoints? (Y/N)");
            int DMGInput = Console.ReadLine()?.ToUpper() == "Y" ? consoleHelper.UserInput() : 0;

            HeroGenerator heroGenerator = new HeroGenerator(selectedHeroType, HPInput, DMGInput);
            Hero hero = heroGenerator.GenerateHero(selectedHeroType, HPInput, DMGInput);

            Console.WriteLine($"Generated {selectedHeroType} hero:");
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
            Console.WriteLine($"SpecialAbilityChance: {hero.SpecialAbilityChance}");
            Console.WriteLine($"Experience: {hero.Experience}");

            if (hero is Gladiator gladiator)
            {
                Console.WriteLine($"RageChance: {gladiator.RageChance}");
            }
            else if (hero is Enchanter enchanter)
            {
                Console.WriteLine($"Mana: {enchanter.Mana}");
                Console.WriteLine($"HasDied: {enchanter.HasDied}");
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
