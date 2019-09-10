namespace Ash.Values
{
    class Symbol : Value
    {
        public Symbol(string value) : base(value)
        {
        }

        public override string ToString()
        {
            return GetValue<string>();
        }
    }
}
