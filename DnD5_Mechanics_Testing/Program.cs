using System;
using System.Collections.Generic;
using DnD5_Mechanics;

namespace DnD5_Mechanics_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Modifier strModifier = new Modifier(Ability.Strenght.Shortcut, 3);
            int difficulty = 15;

            List<DieRoll> additionalRolls = new List<DieRoll> { new DieRoll(DiceSet.GetByName("1d4")) };
            List<Modifier> additionalModifiers = new List<Modifier> { new Modifier("Fire", 2) };

            AbilityCheckBuilder builder = new AbilityCheckBuilder(
                Ability.Strenght,
                strModifier,
                difficulty,
                new NormalRoll(),
                RollType.Normal,
                additionalRolls,
                additionalModifiers);

            ValueDefinitionDirector.ConstructValueDefinition(builder);

            AbilityCheck strenghtCheck = builder.GetResult() as AbilityCheck;
            strenghtCheck.CalculateResult();

            Console.WriteLine(strenghtCheck);
        }
    }
}
