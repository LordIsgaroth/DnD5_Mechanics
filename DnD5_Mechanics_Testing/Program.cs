using System;
using DnD5_Mechanics;

namespace DnD5_Mechanics_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Modifier strModifier = new Modifier(Ability.Strenght.Shortcut, 3);
            int difficulty = 15;

            AbilityCheck strenghtCheck = new AbilityCheck(Ability.Strenght, strModifier, difficulty);
            strenghtCheck.CalculateResult();

            Console.WriteLine(strenghtCheck);
        }
    }
}
