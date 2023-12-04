
using Data.Models.Heroes;
using Data.Models.Monsters;

using Domain.Repositories.Attack_Interfaces;

namespace Domain.Repositories.Attacks
{
    public class GoblinAttack : IGoblinAttack
    {
        public void PerformGoblinAttack(Hero hero, Goblin goblin)
        {
            hero.HealthPoints -= goblin.DamagePoints;
            Console.WriteLine($"Goblin gave you {goblin.DamagePoints} damage");
            Console.ReadKey();
            if (hero.HealthPoints <= 0) Console.WriteLine("You lost :(");
        }
    }
}
