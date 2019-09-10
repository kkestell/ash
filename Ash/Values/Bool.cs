namespace Ash.Values
{
    public class Bool : Value
    {
        public Bool(bool value) : base(value)
        {
        }

        public override string ToString()
        {
            return GetValue<bool>() ? "true" : "false";
        }
    }
}
