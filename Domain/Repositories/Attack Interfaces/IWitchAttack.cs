using Data.Models.Heroes;
using Data.Models.Monsters;

namespace Domain.Repositories.Attacks
{
    public interface IWitchAttack
    {
        void PerformWitchAttack(Hero hero, Witch witch, List<Monster> monsters, MonstersGenerator monstersGenerator);
    }
}
