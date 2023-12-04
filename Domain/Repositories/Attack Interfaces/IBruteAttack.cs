using Data.Models.Heroes;
using Data.Models.Monsters;

namespace Domain.Repositories.Attack_Interfaces
{
    public interface IBruteAttack
    {
        void PerformBruteAttack(Hero hero, Brute brute);
    }
}
