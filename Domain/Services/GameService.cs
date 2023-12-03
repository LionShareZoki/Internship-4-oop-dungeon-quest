using Data.Models.Heroes;
using Data.Models.Heros;
using Data.Models.Monsters;

using Domain.Repositories;
using Domain.Repositories.Attacks;

namespace Domain.Services
{
    public class GameService
    {
        private List<Monster> monsters;
        private MonstersGenerator monstersGenerator;

        public GameService(Hero hero, List<Monster> monsters, MonstersGenerator monstersGenerator, bool hasWon)
        {
            this.monsters = monsters;
            this.monstersGenerator = monstersGenerator;

            if (monsters.Count > 0)
            {
                Monster firstMonster = monsters[0];

                if (hero is Gladiator gladiator && !hasWon)
                {
                    GladiatorAttack.GetGladiatorAttackDamage(gladiator, firstMonster);
                    if (firstMonster.HealthPoints <= 0)
                    {
                        monsters.Remove(firstMonster);
                        if (firstMonster is Witch innerWitch && !innerWitch.HasDied)
                        {
                            monstersGenerator.GenerateRandomMonsters(2);
                            innerWitch.HasDied = true;
                        }
                    }
                }

                if (hero is Enchanter enchanter && !hasWon)
                {
                    EnchanterAttack.PerformEnchanterAttack(enchanter, firstMonster);
                    if (firstMonster.HealthPoints <= 0)
                    {
                        monsters.Remove(firstMonster);
                        if (firstMonster is Witch innerWitch && !innerWitch.HasDied)
                        {
                            monstersGenerator.GenerateRandomMonsters(2);
                            innerWitch.HasDied = true;
                        }
                    }
                }

                if (hero is Marksman marksman && !hasWon)
                {
                    MarksmanAttack.PerformMarksmanAttack(marksman, firstMonster);
                    if (firstMonster.HealthPoints <= 0)
                    {
                        monsters.Remove(firstMonster);
                        if (firstMonster is Witch gameWitch && !gameWitch.HasDied)
                        {
                            monstersGenerator.GenerateRandomMonsters(2);
                            gameWitch.HasDied = true;
                        }
                    }
                }

                if (firstMonster is Goblin goblin && hasWon)
                {
                    GoblinAttack.PerformGoblinAttack(hero, goblin);
                    if (hero is not Enchanter && hero.HealthPoints <= 0) Console.WriteLine("You lost");
                    if (hero is Enchanter someEnchanter && hero.HealthPoints <= 0)
                    {
                        if (someEnchanter.HasDied != true)
                        {
                            someEnchanter.HealthPoints += new Random().Next(50, 70);
                            someEnchanter.HasDied = true;
                        }
                        else if (someEnchanter.HasDied) Console.WriteLine("You lost");
                    }
                }

                if (firstMonster is Brute brute && hasWon)
                {
                    BruteAttack.PerformBruteAttack(hero, brute);
                    if (hero is not Enchanter && hero.HealthPoints <= 0) Console.WriteLine("You lost");
                    if (hero is Enchanter someEnchanter && hero.HealthPoints <= 0)
                    {
                        if (someEnchanter.HasDied != true)
                        {
                            someEnchanter.HealthPoints += new Random().Next(50, 70);
                            someEnchanter.HasDied = true;
                        }
                        else if (someEnchanter.HasDied) Console.WriteLine("You lost");
                    }

                }

                if (firstMonster is Witch witch && hasWon)
                {
                    WitchAttack.PerformWitchAttack(hero, witch, monsters);
                    if (hero is not Enchanter && hero.HealthPoints <= 0) Console.WriteLine("You lost");
                    if (hero is Enchanter someEnchanter && hero.HealthPoints <= 0)
                    {
                        if (someEnchanter.HasDied != true)
                        {
                            someEnchanter.HealthPoints += new Random().Next(50, 70);
                            someEnchanter.HasDied = true;
                        }
                        else if (someEnchanter.HasDied) Console.WriteLine("You lost");
                    }
                }

            }
            else { Console.WriteLine("You won! Congratulations!"); }
        }
    }
}
