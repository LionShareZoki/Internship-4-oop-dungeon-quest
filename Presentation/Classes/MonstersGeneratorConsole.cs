using Data.Models.Monsters;

using Domain.Repositories;

using Presentation.Interfaces;
using Presentation.Repositories;

public class MonsterConsole : IMonstersGeneratorConsole
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
        Console.Clear();
        Console.WriteLine("Are you ready to fight? (Y/N)");
        if (Console.ReadLine()?.ToUpper() == "Y")
        {
            return GenerateMonsters();
        }
        return new List<Monster>();
    }

    private List<Monster> GenerateMonsters()
    {
        List<Monster> monsters = monstersGenerator.GenerateRandomMonsters(10);


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
        Console.Clear();
        Console.WriteLine("You are fighting against:");
        Console.WriteLine($"{bruteCount} brutes");
        Console.WriteLine($"{goblinCount} goblins");
        Console.WriteLine($"{witchCount} witches");
        Console.ReadLine();

        return monsters;
    }
}
