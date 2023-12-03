
using Data.Models.Heroes;
using Data.Models.Monsters;

namespace Domain.Repositories.Attacks
{
    public static class GoblinAttack
    {
        public static void PerformGoblinAttack(Hero hero, Goblin goblin)
        {
            hero.HealthPoints -= goblin.DamagePoints;
            if (hero.HealthPoints <= 0) Console.WriteLine("You lost :(");

        }
    }
}
