namespace Ash.Values
{
    public class String : Value
    {
        public String(string value) : base(value)
        {
        }

        public override string ToString()
        {
            return GetValue<string>();
        }
    }
}
