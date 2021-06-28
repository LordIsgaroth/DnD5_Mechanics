
using System.Collections.Generic;

namespace DnD5_Mechanics
{
    /// <summary>
    /// Строитель, создающий бросок атаки
    /// </summary>
    public class AttackCheckBuilder : AbilityCheckBuilder
    {
        private int masteryBonus;

        public AttackCheckBuilder(
            Ability ability,
            int abilityValue,
            int armorClass,
            int masteryBonus,
            IRollValueCalculation valueCalculation,
            RollType rollType = RollType.Normal,
            List<DieRoll> additionalRolls = null, 
            List<Modifier> additionalModifiers = null) 
            : base(ability, abilityValue, armorClass, valueCalculation, rollType, additionalRolls, additionalModifiers)
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
            valueDefinition.Modifiers.Add(new Modifier("Mastery", masteryBonus));
        }
    }
}
