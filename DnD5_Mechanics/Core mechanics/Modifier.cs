using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD5_Mechanics
{
    /// <summary>
    /// Модификатор при броске кубов
    /// </summary>
    public class Modifier
    {
        private string source;
        private int value;

        public string Source { get => source; }
        public int Value { get => value; }

        /// <summary>
        /// Создание модификатора
        /// </summary>
        /// <param name="source">Источник модификатора для отображения в логе (название характеристика, способности, заклинания)</param>
        /// <param name="value">Значение модификатора</param>
        public Modifier(string source, int value)
        {
            this.source = source;
            this.value = value;
        }

        public override string ToString()
        {
            return $"{value} ({source})";
        }
    }
}
