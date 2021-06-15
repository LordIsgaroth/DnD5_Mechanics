using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected IRollValueCalculation valueCalculation;

        public RollResult Result { get => result; }

        public RollValueDefinition()
        {
            rolls = new List<DieRoll>();
            modifiers = new List<Modifier>();
        }

        /// <summary>
        /// Устанавливает для экземпляра класса переданные в конструктор броски и модификаторы
        /// </summary>
        /// <param name="additionalRolls">Дополнительные броски</param>
        /// <param name="additionalModifiers">Дополнительные модификаторы</param>
        protected void SetRollsAndModifiers(List<DieRoll> additionalRolls = null, List<Modifier> additionalModifiers = null)
        {
            SetMainRollsAndModifier();

            if (additionalRolls != null) rolls.AddRange(additionalRolls);
            if (additionalModifiers != null) modifiers.AddRange(additionalModifiers);
        }

        /// <summary>
        /// Устанавливает основные броски и модификаторы для проверки
        /// </summary>
        protected abstract void SetMainRollsAndModifier();

        /// <summary>
        /// Подсчитывает результат проверки
        /// </summary>
        public virtual void CalculateResult()
        {
            result = valueCalculation.Calculate(rolls, modifiers);
        }

        public override string ToString()
        {
            return result.Representation;
        }
    }
}
