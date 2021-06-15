using System;
using DnD5_Mechanics;

namespace DnD5_Mechanics_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Modifier strModifier = new Modifier(Ability.Strenght.Shortcut, 3);

            AbilityCheck strenghtCheck = new AbilityCheck(Ability.Strenght, strModifier);
            strenghtCheck.CalculateResult();

            Console.WriteLine(strenghtCheck);
        }
    }
}
