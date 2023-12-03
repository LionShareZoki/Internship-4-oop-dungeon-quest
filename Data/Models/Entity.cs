namespace Data.Models;

public abstract class Entity
{
    public string Name { get; set; }
    public double HealthPoints { get; set; }
    public int DamagePoints { get; set; }
    public int SpecialAbilityChance { get; set; }

    public bool Win { get; set; }

    public abstract Attack AttackAction();

}
