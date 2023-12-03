using Data.Models.Heroes;

namespace Data.Models.Heros
{
    public class Enchanter : Hero
    {
        public int Mana { get; set; }
        public bool HasDied { get; set; }

        public override Attack AttackAction()
        {
            throw new NotImplementedException();
        }
    }
}
