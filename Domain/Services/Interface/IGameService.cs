using Data.Models.Heroes;
using Data.Models.Monsters;

using Domain.Repositories;

namespace Domain.Services
{
    public interface IGameService
    {
        void PlayGame(Hero hero, List<Monster> monsters, MonstersGenerator monstersGenerator, bool hasWon);
    }
}
