namespace Ash.Values
{
    public class Number : Value
    {
        public Number(double value) : base(value)
        {
        }

        public override string ToString()
        {
            return Boxed.ToString();
        }
    }
}
