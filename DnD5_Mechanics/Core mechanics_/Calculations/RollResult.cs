
namespace DnD5_Mechanics
{
    /// <summary>
    /// Результаты броска кубов c применением модификаторов
    /// </summary>
    public class RollResult
    {
        protected int value;
        protected string representation;

        public int Value { get => value; }
        public string Representation { get => representation; }

        public RollResult(int value, string representation)
        {
            this.value = value;
            this.representation = representation;
        }

        public override string ToString()
        {
            return Representation;
        }
    }
}
