using Data.Models.Heroes;

namespace Data.Models.Heros
{
    public class Marksman : Hero
    {
        public int CriticalChance { get; set; }
        public int StunChance { get; set; }

        public override Attack AttackAction()
        {
            throw new NotImplementedException();
        }
    }
}
