using Data.Models.Heroes;
using Data.Models.Monsters;

namespace Presentation.Interfaces
{
    public interface IGameMonitor
    {
        void GameDataMonitor(Hero hero, List<Monster> monsters);
    }
}
