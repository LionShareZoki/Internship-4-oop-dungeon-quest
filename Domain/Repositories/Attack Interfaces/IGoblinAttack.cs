using Data.Models.Heroes;
using Data.Models.Monsters;

namespace Domain.Repositories.Attack_Interfaces
{
    public interface IGoblinAttack
    {
        void PerformGoblinAttack(Hero hero, Goblin goblin);
    }
}
