using System.Collections.Generic;

namespace DnD5_Mechanics
{
    /// <summary>
    /// Определение значения путём броска костей и применения модификаторов
    /// </summary>
    public abstract class RollValueDefinition
    {
        protected string name;
        protected List<DieRoll> rolls;
        protected List<Modifier> modifiers;
        protected RollResult result;
        protected RollType rollType;
        protected IRollValueCalculation valueCalculation;        

        internal RollType RollType { set { rollType = value; } }
        internal string Name { set { name = value; } }
        internal List<DieRoll> Rolls { get => rolls;  set { rolls = value; } }
        internal List<Modifier> Modifiers { get => modifiers;  set { modifiers = value; } }

        public IRollValueCalculation ValueCalculation { set { valueCalculation = value; } }

        public RollResult Result => result;

        internal RollValueDefinition()
        {
            rolls = new List<DieRoll>();
            modifiers = new List<Modifier>();
        }

        /// <summary>
        /// Подсчитывает результат проверки
        /// </summary>
        public virtual void CalculateResult()
        {
            result = valueCalculation.Calculate(rolls, modifiers, rollType);
        }

        public override string ToString()
        {
            return $"{name}: {result.Representation}";
        }
    }
}
