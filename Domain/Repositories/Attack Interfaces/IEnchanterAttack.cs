using Data.Models.Heros;
using Data.Models.Monsters;

namespace Domain.Repositories.Attacks
{
    public interface IEnchanterAttack
    {
        void PerformEnchanterAttack(Enchanter enchanter, Monster monster);
    }
}
