using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD5_Mechanics
{
    /// <summary>
    /// Определение урона
    /// </summary>
    public class DamageValueDefinition : RollValueDefinition
    {
        private Dictionary<DamageType, int> damageByTypes;
        public Dictionary<DamageType, int> DamageByTypes { get => damageByTypes; }

        internal DamageValueDefinition()
        {
            damageByTypes = new Dictionary<DamageType, int>();
        }

        public override void CalculateResult()
        {
            base.CalculateResult();
            damageByTypes = (result as DamageRollResult).DamageByTypes;
        }
    }
}
