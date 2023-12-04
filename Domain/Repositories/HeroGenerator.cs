
using Data.Enums;
using Data.Models.Heroes;
using Data.Models.Heros;

namespace Data.Repositories
{
    public class HeroGenerator(HerosType selectedHeroType, int HPInput, int DMGInput, string Name)
    {
        public static List<Hero> createdHeroes = new List<Hero>();
        public Hero GenerateHero(HerosType selectedHeroType, int HPInput, int DMGInput, string Name)
        {

            switch (selectedHeroType)
            {
                case HerosType.Gladiator:
                    Gladiator heroG;
                    heroG = new Gladiator();
                    heroG.Name = Name;
                    heroG.RageChance = 10;
                    if (HPInput != 0)
                    {
                        heroG.HealthPoints = HPInput;
                        heroG.MaxHealthPoints = HPInput;
                    }
                    else
                    {
                        var hp = new Random().Next(120, 130);
                        heroG.HealthPoints = hp;
                        heroG.MaxHealthPoints = hp;
                    }
                    if (DMGInput != 0) heroG.DamagePoints = DMGInput;
                    else heroG.DamagePoints = new Random().Next(5, 15);
                    heroG.SpecialAbilityChance = 10;
                    heroG.Experience = 0;
                    heroG.Level = 1;
                    createdHeroes.Add(heroG);
                    return heroG;
                case HerosType.Enchanter:
                    Enchanter heroE;
                    heroE = new Enchanter();
                    heroE.Name = Name;
                    if (HPInput != 0)
                    {
                        heroE.HealthPoints = HPInput;
                        heroE.MaxHealthPoints = HPInput;
                    }
                    else
                    {
                        var hp = new Random().Next(80, 90);
                        heroE.HealthPoints = hp;
                        heroE.MaxHealthPoints = hp;
                    }
                    if (DMGInput != 0) heroE.DamagePoints = DMGInput;
                    else heroE.DamagePoints = new Random().Next(25, 35);
                    heroE.SpecialAbilityChance = 10;
                    heroE.HasDied = false;
                    heroE.Mana = 100;
                    heroE.Experience = 0;
                    heroE.Level = 1;
                    createdHeroes.Add(heroE);
                    return heroE;
                case HerosType.Marksman:
                    Marksman heroM;
                    heroM = new Marksman();
                    heroM.Name = Name;
                    if (HPInput != 0)
                    {
                        heroM.HealthPoints = HPInput;
                        heroM.MaxHealthPoints = HPInput;
                    }
                    else
                    {
                        var hp = new Random().Next(100, 105);
                        heroM.HealthPoints = hp;
                        heroM.MaxHealthPoints = hp;
                    }
                    if (DMGInput != 0) heroM.DamagePoints = DMGInput;
                    else heroM.DamagePoints = new Random().Next(15, 20);
                    heroM.SpecialAbilityChance = 10;
                    heroM.Experience = 0;
                    heroM.CriticalChance = 10;
                    heroM.StunChance = 10;
                    heroM.Level = 1;
                    createdHeroes.Add(heroM);
                    return heroM;
                default:
                    throw new ArgumentException("Invalid hero type.");
            }
        }
    }
}
