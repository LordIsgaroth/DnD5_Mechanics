using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD5_Mechanics
{
    /// <summary>
    /// Применяется для создания классов определения значений с помощью строителя
    /// </summary>
    public static class ValueDefinitionDirector
    {
        public static void ConstructValueDefinition(ValueDefinitionBuilder builder)
        {
            builder.Reset();
            builder.SetName();
            builder.SetRolls();
            builder.SetModifiers();
            builder.SetAdditionalRollsAndModifiers();
            builder.SetRollType();
            builder.SetValueCalculation();
        }
    }
}
