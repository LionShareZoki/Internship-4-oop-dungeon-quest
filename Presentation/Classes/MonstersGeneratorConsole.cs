using Data.Models.Monsters;

using Domain.Repositories;

using Presentation.Repositories;

public class MonsterConsole
{
    private readonly ConsoleHelper consoleHelper;
    private readonly MonstersGenerator monstersGenerator;

    public MonsterConsole()
    {
        consoleHelper = new ConsoleHelper();
        monstersGenerator = new MonstersGenerator();
    }

    public List<Monster> RunMonsterConsole()
    {
        Console.WriteLine("Are you ready to see who you are fighting against? (Y/N)");
        if (Console.ReadLine()?.ToUpper() == "Y")
        {
           return GenerateMonsters();
        }
        return new List<Monster>();
    }

    private List<Monster> GenerateMonsters()
    {
        List<Monster> monsters = monstersGenerator.GenerateRandomMonsters(10);

        Console.WriteLine("Generated 10 monsters:");

        int bruteCount = 0;
        int goblinCount = 0;
        int witchCount = 0;

        foreach (var monster in monsters)
        {
            if (monster is Brute)
            {
                bruteCount++;
            }
            else if (monster is Goblin)
            {
                goblinCount++;
            }
            else if (monster is Witch)
            {
                witchCount++;
            }
        }

        Console.WriteLine($"Brute Count: {bruteCount}");
        Console.WriteLine($"Goblin Count: {goblinCount}");
        Console.WriteLine($"Witch Count: {witchCount}");

        return monsters;
    }
}
