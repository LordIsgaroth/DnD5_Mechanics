using System;

namespace DnD5_Mechanics
{
    /// <summary>
    /// Бросок костей
    /// </summary>
    public class DieRoll
    {
        private static Random random = new Random();

        private DiceSet diceSet;
        private bool decrease;

        internal DiceSet DiceSet => diceSet;

        /// <summary>
        /// Определение данных для броска костей
        /// </summary>
        /// <param name="diceSet">Набор костей</param>
        /// <param name="decrease">Определяет, что результат броска нужно вычесть из итоговой суммы</param>
        public DieRoll(DiceSet diceSet, bool decrease = false)
        {
            this.diceSet = diceSet;
            this.decrease = decrease;
        }

        /// <summary>
        /// Возвращает результат броска набора костей
        /// </summary>
        /// <returns></returns>
        public virtual int Roll()
        {
            int result = 0;

            for (int i = 1; i <= diceSet.Quantity; i++)
            {
                result += random.Next(1, diceSet.Edges + 1);
            }

            return decrease ? -1 * result : result;
        }

        public override string ToString()
        {
            return diceSet.Name;
        }

        //public static int Roll(DiceSet dice)
        //{
        //    int result = 0;

        //    for (int i = 1; i <= dice.Quantity; i++)
        //    {
        //        result += Random.Range(1, dice.Edges + 1);
        //    }

        //    return result;
        //}

        ///// <summary>
        ///// Результат броска d20
        ///// </summary>
        ///// <param name="type"></param>    
        //public static int RollD20(Roll20Type type)
        //{
        //    DiceSet d20 = DiceSet.GetByName("1d20");

        //    switch (type)
        //    {
        //        case Roll20Type.Normal:
        //            return Roll(d20);
        //        case Roll20Type.Advantage:
        //            return Mathf.Max(Roll(d20), Roll(d20));
        //        case Roll20Type.Disadvantage:
        //            return Mathf.Min(Roll(d20), Roll(d20));
        //        default:
        //            return 0;
        //    }        
        //}
    }
}
