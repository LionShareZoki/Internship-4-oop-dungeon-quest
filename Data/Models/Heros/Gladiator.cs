using Data.Models.Heroes;

namespace Data.Models.Heros
{
    public class Gladiator : Hero
    {
        public int RageChance { get; set; }
        public override Attack AttackAction()
        {
            throw new NotImplementedException();
        }
    }
}
