using Data.Models.Heroes;

namespace Domain.Repositories
{
    public class BuyHP(Hero hero)
    {
        public void BuyHealthPoints(Hero hero)
        {
            hero.Experience /= 2;
            hero.HealthPoints = hero.MaxHealthPoints;
            Console.WriteLine("Successful transaction.");
            Console.ReadKey();
        }
    }
}
