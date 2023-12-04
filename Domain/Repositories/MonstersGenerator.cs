using Data.Enums;
using Data.Models.Monsters;

namespace Domain.Repositories
{
    public class MonstersGenerator
    {
        public List<Monster> Monsters { get; private set; }

        public MonstersGenerator()
        {
            Monsters = new List<Monster>();
        }

        public List<Monster> GenerateRandomMonsters(int count)
        {
            List<Monster> monsters = new List<Monster>();
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                MonstersType monsterType = DetermineMonsterType(random.Next(1, 101));

                Monster monster = GenerateMonster(monsterType);
                monsters.Insert(0, monster);
            }

            return monsters;
        }

        private MonstersType DetermineMonsterType(int randomNumber)
        {
            if (randomNumber <= 60)
            {
                return MonstersType.Goblin;
            }
            else if (randomNumber <= 90)
            {
                return MonstersType.Brute;
            }
            else
            {
                return MonstersType.Witch;
            }
        }

        private Monster GenerateMonster(MonstersType monsterType)
        {
            switch (monsterType)
            {
                case MonstersType.Brute:
                    return new Brute
                    {
                        Name = monsterType.ToString(),
                        PercentageAttackChance = 20,
                        DamagePoints = 22,
                        HealthPoints = 40,
                        ExperiencePrize = 15
                    };
                case MonstersType.Goblin:
                    return new Goblin
                    {
                        Name = monsterType.ToString(),
                        SpecialAbilityChance = 0,
                        DamagePoints = 17,
                        HealthPoints = 30,
                        ExperiencePrize = 10
                    };
                case MonstersType.Witch:
                    return new Witch
                    {
                        Name = monsterType.ToString(),
                        DamagePoints = 28,
                        HealthPoints = 40,
                        ExperiencePrize = 20,
                        HasDied = false,
                        SpecialAbilityChance = 10
                    };
                default:
                    throw new ArgumentException("Invalid monster type.");
            }
        }
    }
}
