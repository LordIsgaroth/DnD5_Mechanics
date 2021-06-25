using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD5_Mechanics
{
    /// <summary>
    /// Результат броска с возможностью критического успеха/провала
    /// </summary>
    public class RollResultWithCriticals : RollResult
    {
        private bool criticalFail;
        private bool criticalSuccess;

        public bool CriticalFail => criticalFail;
        public bool CriticalSuccess => criticalSuccess;

        public RollResultWithCriticals(int value, string representation, bool criticalFail, bool criticalSuccess)
            : base(value, representation)
        {
            this.criticalFail = criticalFail;
            this.criticalSuccess = criticalSuccess;
        }
    }
}
