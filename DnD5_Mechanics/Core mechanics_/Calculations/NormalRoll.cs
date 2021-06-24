using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD5_Mechanics
{
    public class NormalRoll : IRollValueCalculation
    {
        public RollResult Calculate(List<DieRoll> rolls, List<Modifier> modifiers, RollType rollType = RollType.Normal)
        {            
            int value = 0;
            string representation = "";

            foreach (DieRoll diceSet in rolls)
            {
                int roll = diceSet.Roll();
                value += roll;
                representation += $"{roll} ({diceSet}) + ";
            }

            foreach (Modifier modifier in modifiers)
            {
                if (modifier.Value != 0)
                {
                    value += modifier.Value;
                    representation += $"{modifier} + ";
                }
            }

            representation = $"{value} = {representation.Remove(representation.Length - 3)}";

            return new RollResult(value, representation);
        }
    }
}
