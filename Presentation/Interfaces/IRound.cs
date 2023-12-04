using Data.Models.Monsters;

namespace Presentation.Interfaces
{
    public interface IRound
    {
        void RoundAction(List<Monster> monsters);
    }
}
