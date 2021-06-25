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

            bool first = true;

            foreach (DieRoll dieRoll in rolls)
            {
                int roll = dieRoll.Roll();
                value += roll;

                if (!first) representation += " + ";

                representation += $"{roll} ({dieRoll})";

                first = false;
            }

            foreach (Modifier modifier in modifiers)
            {
                if (modifier.Value != 0)
                {
                    value += modifier.Value;
                    if (modifier.Value > 0) representation += $" + {modifier}";
                    else representation += $" {modifier.ToString().Replace("-", "- ")}";
                }
            }

            representation = $"{value} = {representation}";

            return new RollResult(value, representation);
        }
    }
}
