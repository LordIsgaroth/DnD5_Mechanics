using System.Collections.Generic;

namespace DnD5_Mechanics
{
    public class DamageValueBuilder : ValueDefinitionBuilder
    {
        private DamageDieRoll roll;
        private Ability ability;
        private int abilityValue;
        private bool isCriticalHit;

        public DamageValueBuilder(
            DamageDieRoll roll,
            Ability ability = null,
            int abilityValue = 0,
            bool isCriticalHit = false,
            List<DieRoll> additionalRolls = null,
            List<Modifier> additionalModifiers = null)
        {
            this.roll = roll;
            this.ability = ability;
            this.abilityValue = abilityValue;
            this.isCriticalHit = isCriticalHit;
            this.additionalRolls = additionalRolls;
            this.additionalModifiers = additionalModifiers;
        }

        public override void Reset()
        {
            valueDefinition = new DamageValueDefinition();
        }

        public override void SetName()
        {
            valueDefinition.Name = "Damage";
        }

        public override void SetRolls()
        {
            valueDefinition.Rolls.Add(roll);
        }

        public override void SetModifiers()
        {
            if (ability != null && abilityValue != 0)
            {
                valueDefinition.Modifiers.Add(new DamageModifier(ability.Shortcut, Ability.GetAbilityModifier(abilityValue), roll.DamageType));
            } 
        }

        public override void SetRollType()
        {
            valueDefinition.RollType = RollType.Normal;
        }

        public override void SetValueCalculation()
        {
            valueDefinition.ValueCalculation = new DamageRoll(isCriticalHit);
        }
    }
}
