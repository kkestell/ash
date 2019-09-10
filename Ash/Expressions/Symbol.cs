using Ash.Values;

namespace Ash.Expressions
{
    class Symbol : Expression
    {
        readonly string name;

        public Symbol(string name)
        {
            this.name = name;
        }

        public override Value Evaluate(Environment env)
        {
            return env[name].Evaluate(env);
        }
    }
}
