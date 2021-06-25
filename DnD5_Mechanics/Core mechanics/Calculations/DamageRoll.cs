using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD5_Mechanics
{
    /// <summary>
    /// Вычисление результата броска урона. Поддерживает критические удары
    /// </summary>
    public class DamageRoll : IRollValueCalculation
    {
        private bool isCriticalHit;
        private Dictionary<DamageType, int> damageByTypes;

        public DamageRoll(bool isCriticalHit = false)
        {
            this.isCriticalHit = isCriticalHit;
            damageByTypes = new Dictionary<DamageType, int>();
        }

        public RollResult Calculate(List<DieRoll> rolls, List<Modifier> modifiers, RollType rollType)
        {
            int value = 0;
            string representation = "";
             
            //При критическом попадании количество всех костей удваивается
            if (isCriticalHit)
            {
                foreach (DieRoll dieRoll in rolls)
                {
                    dieRoll.DiceSet.DoubleForCrit();
                }
            }

            bool first = true;

            foreach (DieRoll dieRoll in rolls)
            {
                int roll = dieRoll.Roll();
                value += roll;

                if (!first) representation += " + ";

                representation += $"{roll} ({dieRoll}";

                if (dieRoll is DamageDieRoll)
                {
                    DamageType type = (dieRoll as DamageDieRoll).DamageType;
                    AddToDamageByTypes(type, roll);
                    representation += $", {type.Name})";
                }
                else representation += ")";

                first = false;
            }

            foreach (Modifier modifier in modifiers)
            {
                if (modifier.Value != 0)
                {
                    value += modifier.Value;
                    if (modifier.Value > 0) representation += $" + {modifier}";
                    else representation += $" {modifier.ToString().Replace("-", "- ")}";

                    if (modifier is DamageModifier)
                    {
                        DamageType type = (modifier as DamageModifier).DamageType;
                        AddToDamageByTypes(type, modifier.Value);
                    }
                }
            }

            string critical = isCriticalHit ? "Critical hit! " : "";

            representation = $"{critical}{value} = {representation}";

            return new DamageRollResult(value, representation, damageByTypes);
        }

        private void AddToDamageByTypes(DamageType type, int value)
        {
            if (damageByTypes.ContainsKey(type)) damageByTypes[type] += value;
            else damageByTypes.Add(type, value);
        }
    }
}
