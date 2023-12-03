﻿using Data.Enums;
using Data.Models.Heroes;
using Data.Models.Heros;
using Data.Models.Monsters;
using Data.Repositories;

using Domain.Repositories;
using Domain.Repositories.Attacks;
using Domain.Services;

namespace Presentation.Classes
{
    internal class Round
    {
        public static void RoundAction(List<Monster> monsters)
        {
            Console.Clear();
            Console.WriteLine($"hero hp {HeroGenerator.createdHeroes[0].HealthPoints}, \n this many monsters {monsters.Count}");

            while (HeroGenerator.createdHeroes[0].HealthPoints > 0 && monsters.Count > 0)
            {
                Console.WriteLine("It's your turn to play: Direct, Side, or Counter");
                var heroChoice = Console.ReadLine();

                if (Enum.TryParse<Attack>(heroChoice, ignoreCase: true, out var attackChoice))
                {
                    Console.WriteLine($"You chose: {attackChoice}");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose Direct, Side, or Counter.");
                    return;
                }

                Console.WriteLine("Monster's turn");

                Attack[] possibleMonsterChoices = { Attack.Direct, Attack.Side, Attack.Counter };
                Random random = new Random();
                var monsterChoice = possibleMonsterChoices[random.Next(possibleMonsterChoices.Length)];

                Console.WriteLine($"Monster chose: {monsterChoice}");
                bool heroOrMonster = false;
                if (attackChoice == monsterChoice)
                {
                    Console.WriteLine("Both of you choose the same attack... Let's do it again!");
                    Console.ReadKey();
                }
                else if ((attackChoice == Attack.Direct && monsterChoice == Attack.Side) || (attackChoice == Attack.Side && monsterChoice == Attack.Counter) || (attackChoice == Attack.Counter && monsterChoice == Attack.Direct))
                {
                    heroOrMonster = false;
                }
                else if ((monsterChoice == Attack.Direct && attackChoice == Attack.Side) || (monsterChoice == Attack.Side && attackChoice == Attack.Counter) || (monsterChoice == Attack.Counter && attackChoice == Attack.Direct))
                {
                    heroOrMonster = true;
                }
                var gameService = new GameService(HeroGenerator.createdHeroes[0], monsters, new MonstersGenerator(), heroOrMonster);
            }
        }
    }
}