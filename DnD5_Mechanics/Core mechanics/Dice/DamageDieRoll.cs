
namespace DnD5_Mechanics
{
    /// <summary>
    /// Бросок костей, определяющий урон
    /// </summary>
    public class DamageDieRoll : DieRoll
    {
        private DamageType damageType;
        public DamageType DamageType => damageType;

        public DamageDieRoll(DiceSet diceSet, DamageType damageType, bool decrease = false)
            : base(diceSet, decrease)
        {
            this.damageType = damageType;
        }
    }
}
