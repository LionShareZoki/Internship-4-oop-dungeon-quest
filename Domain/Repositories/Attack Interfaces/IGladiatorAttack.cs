using Data.Models.Heros;
using Data.Models.Monsters;

namespace Domain.Repositories.Attack_Interfaces
{
    public interface IGladiatorAttack
    {
        int GetGladiatorAttackDamage(Gladiator gladiator, Monster monster);
    }
}
