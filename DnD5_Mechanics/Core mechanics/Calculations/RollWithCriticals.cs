using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD5_Mechanics
{
    /// <summary>
    /// Вычисление броска d20, в котором допускается критический успех/провал
    /// </summary>
    public class RollWithCriticals : IRollValueCalculation
    {
        private bool criticalFail;
        private bool criticalSuccess;

        public bool CriticalFail => criticalFail;
        public bool CriticalSuccess => criticalSuccess;

        public RollResult Calculate(List<DieRoll> rolls, List<Modifier> modifiers, RollType rollType)
        {
            if (rolls.Count == 0) throw new Exception("No rolls!");
            if (rolls[0].DiceSet.Name != "1d20") throw new Exception("First roll must be d20!");

            int value = 0;
            string representation = "";

            bool first = true;

            foreach (DieRoll dieRoll in rolls)
            {
                int roll = dieRoll.Roll();
                value += roll;

                if (first)
                {
                    if (value == 1)criticalFail = true;
                    else if (value == 20) criticalSuccess = true;
                }
                else representation += " + ";

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

            string critical = "";
            if (criticalFail) critical = "Critical Fail! ";
            else if (criticalSuccess) critical = "Critical Success! ";

            representation = $"{critical}{value} = {representation}";

            return new RollResultWithCriticals(value, representation, CriticalFail, CriticalSuccess);
        }
    }
}
