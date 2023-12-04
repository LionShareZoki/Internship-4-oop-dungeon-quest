using Data.Models.Heroes;
using Data.Models.Heros;
using Data.Models.Monsters;

using Domain.Repositories;
using Domain.Repositories.Attacks;

namespace Domain.Services
{
    public class GameService : IGameService
    {
        private List<Monster> monsters;
        private MonstersGenerator monstersGenerator;

        public void PlayGame(Hero hero, List<Monster> monsters, MonstersGenerator monstersGenerator, bool hasWon)
        {
            this.monsters = monsters;
            this.monstersGenerator = monstersGenerator;

            if (monsters.Count > 0)
            {
                Monster firstMonster = monsters[0];
                var gladiatorAttack = new GladiatorAttack();
                var enchanterAttack = new EnchanterAttack();
                var marksmanAttack = new MarksmanAttack();

                var goblinAttack = new GoblinAttack();
                var bruteAttack = new BruteAttack();
                var witchAttack = new WitchAttack();



                if (hero is Gladiator gladiator && !hasWon)
                {
                    gladiatorAttack.GetGladiatorAttackDamage(gladiator, firstMonster);
                    if (firstMonster.HealthPoints <= 0)
                    {
                        monsters.Remove(firstMonster);
                    }
                    if (firstMonster is Witch && firstMonster.HealthPoints <= 0)
                    {
                        var newMonsters = monstersGenerator.GenerateRandomMonsters(2);
                        monsters.AddRange(newMonsters);
                        Console.WriteLine("Witch died, but 2 more monsters have spawned");
                        Console.ReadKey();
                    }
                }

                if (hero is Enchanter enchanter && !hasWon)
                {
                    enchanterAttack.PerformEnchanterAttack(enchanter, firstMonster);
                    if (firstMonster.HealthPoints <= 0)
                    {
                        monsters.Remove(firstMonster);
                    }
                    if (firstMonster is Witch && firstMonster.HealthPoints <= 0)
                    {
                        var newMonsters = monstersGenerator.GenerateRandomMonsters(2);
                        monsters.AddRange(newMonsters);
                        Console.WriteLine("Witch died, but 2 more monsters have spawned");
                        Console.ReadKey();
                    }
                }

                if (hero is Marksman marksman && !hasWon)
                {
                    marksmanAttack.PerformMarksmanAttack(marksman, firstMonster);
                    if (firstMonster.HealthPoints <= 0)
                    {
                        monsters.Remove(firstMonster);
                    }
                    if (firstMonster is Witch && firstMonster.HealthPoints <= 0)
                    {
                        var newMonsters = monstersGenerator.GenerateRandomMonsters(2);
                        monsters.AddRange(newMonsters);
                        Console.WriteLine("Witch died, but 2 more monsters have spawned");
                        Console.ReadKey();
                    }
                }

                if (firstMonster is Goblin goblin && hasWon)
                {
                    goblinAttack.PerformGoblinAttack(hero, goblin);
                    if (hero is not Enchanter && hero.HealthPoints <= 0) Console.WriteLine("You lost");
                    if (hero is Enchanter someEnchanter && hero.HealthPoints <= 0)
                    {
                        Console.WriteLine("RIP");
                        Console.ReadKey();
                        if (someEnchanter.HasDied != true)
                        {
                            someEnchanter.HealthPoints += new Random().Next(50, 70);
                            Console.WriteLine("Welcome back!");
                            Console.ReadKey();
                            someEnchanter.HasDied = true;
                        }
                    }
                }

                if (firstMonster is Brute brute && hasWon)
                {
                    bruteAttack.PerformBruteAttack(hero, brute);
                    if (hero is not Enchanter && hero.HealthPoints <= 0) Console.WriteLine("You lost");
                    if (hero is Enchanter someEnchanter && hero.HealthPoints <= 0)
                    {
                        Console.WriteLine("RIP");
                        Console.ReadKey();
                        if (someEnchanter.HasDied != true)
                        {
                            Console.WriteLine("Welcome back!");
                            Console.ReadKey();
                            someEnchanter.HealthPoints += new Random().Next(50, 70);
                            someEnchanter.HasDied = true;
                        }
                    }

                }

                if (firstMonster is Witch witch && hasWon)
                {
                    witchAttack.PerformWitchAttack(hero, witch, monsters, monstersGenerator);
                    if (hero is not Enchanter && hero.HealthPoints <= 0) Console.WriteLine("You lost");
                    if (hero is Enchanter someEnchanter && hero.HealthPoints <= 0)
                    {
                        Console.WriteLine("RIP");
                        Console.ReadKey();
                        if (someEnchanter.HasDied != true)
                        {
                            Console.WriteLine("Welcome back!");
                            Console.ReadKey();
                            someEnchanter.HealthPoints += new Random().Next(50, 70);
                            someEnchanter.HasDied = true;
                        }
                    }
                }

            }
            if (monsters.Count == 0)
                Console.WriteLine("You won! Congratulations!");
        }
    }
}
