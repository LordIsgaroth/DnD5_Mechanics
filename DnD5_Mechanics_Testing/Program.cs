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
            int strenght = 16;
            int difficulty = 15;

            List<DieRoll> additionalRolls = new List<DieRoll> { new DieRoll(DiceSet.GetByName("1d6")) };
            List<Modifier> additionalModifiers = new List<Modifier> { new Modifier("Luck", 2) };

            AbilityCheckBuilder abilityBuilder = new AbilityCheckBuilder(
                Ability.Strenght,
                strenght,
                difficulty,
                new RollWithCriticals(),
                RollType.Normal,
                additionalRolls,
                additionalModifiers);

            ValueDefinitionDirector.ConstructValueDefinition(abilityBuilder);

            AbilityCheck strenghtCheck = abilityBuilder.GetResult() as AbilityCheck;
            strenghtCheck.CalculateResult();

            Console.WriteLine(strenghtCheck);

            //Тестирование атаки
            int targetArmorClass = 18;
            int masteryBonus = 3;
            //Modifier masteryBonus = new Modifier("Mastery", 3);

            AttackCheckBuilder attackBuilder = new AttackCheckBuilder(
                Ability.Strenght,
                strenght,
                targetArmorClass,
                masteryBonus,
                new RollWithCriticals(),
                RollType.Normal,
                additionalRolls,
                additionalModifiers);

            ValueDefinitionDirector.ConstructValueDefinition(attackBuilder);

            AttackCheck attack = attackBuilder.GetResult() as AttackCheck;
            attack.CalculateResult();

            Console.WriteLine(attack);

            //Тестирование броска инициативы
            int dexterity = 8;

            InitiativeCheckBuilder initiativeCheckBuilder = new InitiativeCheckBuilder(
                dexterity,
                RollType.Normal,
                additionalRolls,
                additionalModifiers);

            ValueDefinitionDirector.ConstructValueDefinition(initiativeCheckBuilder);

            InitiativeCheck initiative = initiativeCheckBuilder.GetResult() as InitiativeCheck;
            initiative.CalculateResult();

            Console.WriteLine(initiative);

            //Тестирование броска урона
            DamageDieRoll damageDice = new DamageDieRoll(DiceSet.GetByName("1d10"), DamageType.Slashing);
            List<DieRoll> additionalDamageRolls = new List<DieRoll> { new DamageDieRoll(DiceSet.GetByName("1d6"), DamageType.Necrotic) };
            List<Modifier> additionalDamageModifiers = new List<Modifier> { new DamageModifier("Fiery soul", 2, DamageType.Fire) };

            DamageValueBuilder damageValueBuilder = new DamageValueBuilder(
                damageDice,
                Ability.Strenght,
                6,
                false,
                additionalDamageRolls,
                additionalDamageModifiers);

            ValueDefinitionDirector.ConstructValueDefinition(damageValueBuilder);

            DamageValueDefinition damageValueDefinition = damageValueBuilder.GetResult() as DamageValueDefinition;
            damageValueDefinition.CalculateResult();

            Console.WriteLine(damageValueDefinition);
        }
    }
}
