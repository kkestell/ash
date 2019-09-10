namespace Ash.Values
{
    class Void : Value
    {
        public Void() : base(null)
        {
        }

        public override string ToString()
        {
            return "None";
        }
    }
}
