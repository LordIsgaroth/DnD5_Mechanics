using System;
using System.Collections.Generic;
using DnD5_Mechanics;

namespace DnD5_Mechanics_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Тестирование проверки характеристики
            Modifier strModifier = new Modifier(Ability.Strenght.Shortcut, 3);
            int difficulty = 15;

            List<DieRoll> additionalRolls = new List<DieRoll> { new DieRoll(DiceSet.GetByName("1d6")) };
            List<Modifier> additionalModifiers = new List<Modifier> { new Modifier("Luck", 2) };

            AbilityCheckBuilder abilityBuilder = new AbilityCheckBuilder(
                Ability.Strenght,
                strModifier,
                difficulty,
                new NormalRoll(),
                RollType.Normal,
                additionalRolls,
                additionalModifiers);

            ValueDefinitionDirector.ConstructValueDefinition(abilityBuilder);

            AbilityCheck strenghtCheck = abilityBuilder.GetResult() as AbilityCheck;
            strenghtCheck.CalculateResult();

            Console.WriteLine(strenghtCheck);

            //Тестирование атаки
            int targetArmorClass = 18;
            Modifier masteryBonus = new Modifier("Mastery", 3);

            AttackCheckBuilder attackBuilder = new AttackCheckBuilder(
                Ability.Strenght,
                strModifier,
                targetArmorClass,
                masteryBonus,
                new NormalRoll(),
                RollType.Normal,
                additionalRolls,
                additionalModifiers);

            ValueDefinitionDirector.ConstructValueDefinition(attackBuilder);

            AttackCheck attack = attackBuilder.GetResult() as AttackCheck;
            attack.CalculateResult();

            Console.WriteLine(attack);

            //Тестирование броска инициативы
            int dexterity = 16;

            InitiativeCheckBuilder initiativeCheckBuilder = new InitiativeCheckBuilder(
                new Modifier(Ability.Dexterity.Shortcut, Ability.GetAbilityModifier(dexterity)),
                RollType.Normal,
                additionalRolls,
                additionalModifiers);

            ValueDefinitionDirector.ConstructValueDefinition(initiativeCheckBuilder);

            InitiativeCheck initiative = initiativeCheckBuilder.GetResult() as InitiativeCheck;
            initiative.CalculateResult();

            Console.WriteLine(initiative);
        }
    }
}
