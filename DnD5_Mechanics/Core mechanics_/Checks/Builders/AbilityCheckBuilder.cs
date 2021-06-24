using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD5_Mechanics
{
    /// <summary>
    /// Строитель, создающий проверку характеристики
    /// </summary>
    public class AbilityCheckBuilder : ValueDefinitionBuilder
    {
        protected Ability ability;
        protected Modifier abilityModifier;
        protected int difficulty;
        protected RollType rollType;

        public AbilityCheckBuilder(
            Ability ability, 
            Modifier abilityModifier, 
            int difficulty,
            IRollValueCalculation valueCalculation,
            RollType rollType = RollType.Normal, 
            List<DieRoll> additionalRolls = null, 
            List<Modifier> additionalModifiers = null)
        {
            this.ability = ability;
            this.abilityModifier = abilityModifier;
            this.difficulty = difficulty;
            this.valueCalculation = valueCalculation;
            this.rollType = rollType;
            this.additionalRolls = additionalRolls;
            this.additionalModifiers = additionalModifiers;
        }

        public override void Reset()
        {
            valueDefinition = new AbilityCheck(difficulty);
        }

        public override void SetName()
        {
            valueDefinition.Name = $"{ability.Name} check";
        }

        public override void SetRolls()
        {
            valueDefinition.Rolls.Add(new DieRoll(DiceSet.GetByName("1d20")));
        }

        public override void SetModifiers()
        {
            valueDefinition.Modifiers.Add(abilityModifier);
        }

        public override void SetRollType()
        {
            valueDefinition.RollType = rollType;
        }

        public override void SetValueCalculation()
        {
            valueDefinition.ValueCalculation = valueCalculation;
        }
    }
}
