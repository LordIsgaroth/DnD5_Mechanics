using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD5_Mechanics
{
    /// <summary>
    /// Результат броска урона с распределением по типам
    /// </summary>
    public class DamageRollResult : RollResult
    {
        private Dictionary<DamageType, int> damageByTypes;
        public Dictionary<DamageType, int> DamageByTypes { get => damageByTypes; }

        public DamageRollResult(int value, string representation, Dictionary<DamageType, int> damageByTypes)
            : base(value, representation)
        {
            this.damageByTypes = damageByTypes;
        }
    }

}
