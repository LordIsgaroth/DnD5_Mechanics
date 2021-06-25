using System.Collections.Generic;

namespace DnD5_Mechanics
{
    /// <summary>
    /// Характеристика персонажа
    /// </summary>
    public class Ability
    {
        private static List<Ability> abilities;

        private string name;
        private string shortcut;

        public string Name { get => name; }
        public string Shortcut { get => shortcut; }

        public static Ability Strenght { get => GetByShortcut("STR"); }
        public static Ability Dexterity { get => GetByShortcut("DEX"); }
        public static Ability Constitution { get => GetByShortcut("CON"); }
        public static Ability Intelligence { get => GetByShortcut("INT"); }
        public static Ability Wisdom { get => GetByShortcut("WIS"); }
        public static Ability Charisma { get => GetByShortcut("CHA"); }

        static Ability()
        {
            abilities = new List<Ability>
            {
                new Ability("Strenght", "STR"),
                new Ability("Dexterity", "DEX"),
                new Ability("Constitution", "CON"),
                new Ability("Intelligence", "INT"),
                new Ability("Wisdom", "WIS"),
                new Ability("Charisma", "CHA")
            };
        }

        private Ability(string name, string shortcut)
        {
            this.name = name;
            this.shortcut = shortcut;
        }

        public static Ability GetByShortcut(string shortcut)
        {
            return abilities.Find(ability => ability.shortcut == shortcut);
        }

        /// <summary>
        /// Определяет модификатор характеристики
        /// </summary>
        /// <param name="abilityValue">Значение характеристики</param>        
        public static int GetAbilityModifier(int abilityValue)
        {
            return (abilityValue - 10) / 2;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
