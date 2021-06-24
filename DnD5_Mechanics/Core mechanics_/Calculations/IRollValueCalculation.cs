using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD5_Mechanics
{
    /// <summary>
    /// Интерфейс для определения результатов бросков
    /// </summary>
    public interface IRollValueCalculation
    {
        RollResult Calculate(List<DieRoll> rolls, List<Modifier> modifiers, RollType rollType);
    }
}
