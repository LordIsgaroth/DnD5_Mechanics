using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD5_Mechanics
{
    /// <summary>
    /// Модификатор урона
    /// </summary>
    public class DamageModifier : Modifier
    {
        private DamageType damageType;
        public DamageType DamageType => damageType;

        public DamageModifier(string source, int value, DamageType damageType) : base(source, value)
        {
            this.damageType = damageType;
        }

        public override string ToString()
        {
            return $"{value} ({source}, {damageType})";
        }
    }
}
