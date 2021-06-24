using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD5_Mechanics
{
    /// <summary>
    /// Абстрактный строитель, создающий экземпляры классов определения значений
    /// </summary>
    public abstract class ValueDefinitionBuilder
    {
        protected RollValueDefinition valueDefinition;
        protected IRollValueCalculation valueCalculation;
        protected List<DieRoll> additionalRolls;
        protected List<Modifier> additionalModifiers;

        public abstract void Reset();
        public abstract void SetName();
        public abstract void SetRolls();
        public abstract void SetModifiers();
        public abstract void SetRollType();
        public abstract void SetValueCalculation();        

        public void SetAdditionalRollsAndModifiers()
        {
            if (additionalRolls != null) valueDefinition.Rolls.AddRange(additionalRolls);
            if (additionalModifiers != null) valueDefinition.Modifiers.AddRange(additionalModifiers);
        }

        public RollValueDefinition GetResult()
        {
            return valueDefinition;
        }
    }
}
