using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD5_Mechanics
{
    /// <summary>
    /// Проверка характеристики
    /// </summary>
    public class AbilityCheck : RollValueDefinition
    {
        protected int difficulty;
        protected bool success;

        public bool Success => success;

        internal AbilityCheck(int difficulty) 
        {
            this.difficulty = difficulty;
        }

        /// <summary>
        /// Необходимо определить, успешна ли проверка, сравнив значение со сложностью
        /// </summary>
        public override void CalculateResult()
        {
            base.CalculateResult();
            if (result.Value >= difficulty) success = true;
        }
    }
}
