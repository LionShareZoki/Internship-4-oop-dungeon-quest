namespace Data.Models.Monsters
{
    public class Monster : Entity
    {
        public int ExperiencePrize { get; set; }
        public override Attack AttackAction()
        {
            throw new NotImplementedException();
        }
        public bool IsStunned { get; set; }
    }
}
