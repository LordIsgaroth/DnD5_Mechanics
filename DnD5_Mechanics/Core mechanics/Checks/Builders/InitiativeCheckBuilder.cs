using System.Collections.Generic;

namespace DnD5_Mechanics
{
    public class InitiativeCheckBuilder : ValueDefinitionBuilder
    {
        protected Ability ability = Ability.Dexterity;
        protected Modifier dexterityModifier;
        protected RollType rollType;

        public InitiativeCheckBuilder(
            Modifier dexterityModifier,
            RollType rollType = RollType.Normal,
            List<DieRoll> additionalRolls = null,
            List<Modifier> additionalModifiers = null)
        {
            this.dexterityModifier = dexterityModifier;
            this.rollType = rollType;
            this.additionalRolls = additionalRolls;
            this.additionalModifiers = additionalModifiers;
        }

        public override void Reset()
        {
            valueDefinition = new InitiativeCheck();
        }

        public override void SetName()
        {
            valueDefinition.Name = "Initiative check";
        }

        public override void SetRolls()
        {
            valueDefinition.Rolls.Add(new DieRoll(DiceSet.GetByName("1d20")));
        }

        public override void SetModifiers()
        {
            valueDefinition.Modifiers.Add(dexterityModifier);
        }

        public override void SetRollType()
        {
            valueDefinition.RollType = rollType;
        }

        public override void SetValueCalculation()
        {
            valueDefinition.ValueCalculation = new NormalRoll();
        }
    }
}
