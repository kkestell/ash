namespace Ash
{
    class SExpAtom : SExp
    {
        public string Value { get; set; }

        public SExpAtom(string value)
        {
            Value = value;
        }
    }
}
