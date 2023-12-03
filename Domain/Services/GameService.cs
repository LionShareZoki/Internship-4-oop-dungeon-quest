using System.Collections.Generic;

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

        public GameService(Hero hero, List<Monster> monsters, MonstersGenerator monstersGenerator)
        {
            this.monsters = monsters;
            this.monstersGenerator = monstersGenerator;

            if (monsters.Count > 0)
            {
                Monster firstMonster = monsters[0];

                if (hero is Gladiator gladiator)
                {
                    GladiatorAttack.GetGladiatorAttackDamage(gladiator, firstMonster);
                    if (firstMonster.HealthPoints <= 0)
                    {
                        monsters.Remove(firstMonster);
                        if (firstMonster is Witch witch && !witch.HasDied)
                        {
                            monstersGenerator.GenerateRandomMonsters(2);
                            witch.HasDied = true;
                        }
                    }
                }

                if (hero is Enchanter enchanter)
                {
                    EnchanterAttack.PerformEnchanterAttack(enchanter, firstMonster);
                    if (firstMonster.HealthPoints <= 0)
                    {
                        monsters.Remove(firstMonster);
                        if (firstMonster is Witch witch && !witch.HasDied)
                        {
                            monstersGenerator.GenerateRandomMonsters(2);
                            witch.HasDied = true;
                        }
                    }
                }

                if (hero is Marksman marksman)
                {
                    MarksmanAttack.PerformMarksmanAttack(marksman, firstMonster);
                    if (firstMonster.HealthPoints <= 0)
                    {
                        monsters.Remove(firstMonster);
                        if (firstMonster is Witch witch && !witch.HasDied)
                        {
                            monstersGenerator.GenerateRandomMonsters(2);
                            witch.HasDied = true;
                        }
                    }
                }
            }
            else { Console.WriteLine("You won! Congratulations!"); }
        }
    }
}
