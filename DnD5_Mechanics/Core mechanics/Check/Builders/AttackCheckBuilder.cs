
using System.Collections.Generic;

namespace DnD5_Mechanics
{
    /// <summary>
    /// Строитель, создающий бросок атаки
    /// </summary>
    public class AttackCheckBuilder : AbilityCheckBuilder
    {
        private Modifier masteryBonus;

        public AttackCheckBuilder(
            Ability ability,
            Modifier abilityModifier,
            int armorClass,
            Modifier masteryBonus,
            IRollValueCalculation valueCalculation,
            RollType rollType = RollType.Normal,
            List<DieRoll> additionalRolls = null, 
            List<Modifier> additionalModifiers = null) 
            : base(ability, abilityModifier, armorClass, valueCalculation, rollType, additionalRolls, additionalModifiers)
        {
            this.masteryBonus = masteryBonus;
        }

        public override void Reset()
        {
            valueDefinition = new AttackCheck(difficulty);
        }

        public override void SetName()
        {
            valueDefinition.Name = "Attack";
        }

        public override void SetModifiers()
        {
            base.SetModifiers();
            valueDefinition.Modifiers.Add(masteryBonus);
        }
    }
}
