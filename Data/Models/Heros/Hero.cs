namespace Data.Models.Heroes;

public abstract class Hero : Entity
{
    public int MaxHealthPoints { get; set; }
    public int Experience { get; set; }
    public int Level { get; set; }
}
