using Data.Models.Heros;
using Data.Models.Monsters;

namespace Domain.Repositories.Attack_Interfaces
{
    public interface IMarksmanAttack
    {
        void PerformMarksmanAttack(Marksman marksman, Monster monster);
    }
}
