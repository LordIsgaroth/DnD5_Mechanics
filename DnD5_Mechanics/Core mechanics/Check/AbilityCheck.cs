using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD5_Mechanics
{
    /// <summary>
    /// Проверка характеристики
    /// </summary>
    public class AbilityCheck : RollValueDefinition
    {
        protected int difficulty;
        protected bool success;

        protected Modifier abilityModifier;

        public bool Success { get => success; }

        public AbilityCheck(Ability ability, Modifier abilityModifier, int difficulty, RollType rollType = RollType.Normal, List<DieRoll> additionalDice = null, List<Modifier> additionalModifiers = null)
        {
            name = ability.Name;
            this.abilityModifier = abilityModifier;
            this.difficulty = difficulty;

            valueCalculation = new NormalRoll();

            SetRollsAndModifiers();
        }

        protected override void SetMainRollsAndModifier()
        {
            rolls.Add(new DieRoll(DiceSet.GetByName("1d20")));
            modifiers.Add(abilityModifier);
        }

        //public AbilityCheck(int difficulty, Modifier abilityModifier, RollType rollType = RollType.Normal, List<DieRoll> additionalDice = null, List<Modifier> additionalModifiers = null)
        //    : base(new List<DieRoll>() { new D20Roll(rollType) }, new List<Modifier>() { abilityModifier }, additionalDice, additionalModifiers)
        //{


        //    this.difficulty = difficulty;
        //}
    }
}
