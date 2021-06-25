using System.Collections.Generic;

namespace DnD5_Mechanics
{
    /// <summary>
    /// Тип наносимого урона
    /// </summary>
    public class DamageType
    {
        private static List<DamageType> damageTypes;

        private string name;
        public string Name { get => name; }

        public static DamageType Slashing { get => GetByName("Slashing"); }
        public static DamageType Piercing { get => GetByName("Piercing"); }
        public static DamageType Bludgeoning { get => GetByName("Bludgeoning"); }
        public static DamageType Poison { get => GetByName("Poison"); }
        public static DamageType Acid { get => GetByName("Acid"); }
        public static DamageType Fire { get => GetByName("Fire"); }
        public static DamageType Cold { get => GetByName("Cold"); }
        public static DamageType Radiant { get => GetByName("Radiant"); }
        public static DamageType Necrotic { get => GetByName("Necrotic"); }
        public static DamageType Lightning { get => GetByName("Lightning"); }
        public static DamageType Thunder { get => GetByName("Thunder"); }
        public static DamageType Force { get => GetByName("Force"); }
        public static DamageType Psychic { get => GetByName("Psychic"); }

        static DamageType()
        {
            damageTypes = new List<DamageType>
            {
                new DamageType("Slashing"),
                new DamageType("Piercing"),
                new DamageType("Bludgeoning"),
                new DamageType("Poison"),
                new DamageType("Acid"),
                new DamageType("Fire"),
                new DamageType("Cold"),
                new DamageType("Radiant"),
                new DamageType("Necrotic"),
                new DamageType("Lightning"),
                new DamageType("Thunder"),
                new DamageType("Force"),
                new DamageType("Psychic")
            };
        }

        public static DamageType GetByName(string name)
        {
            return damageTypes.Find(ability => ability.name == name);
        }

        private DamageType(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
