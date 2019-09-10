using Ash.Values;

namespace Ash.Expressions
{
    class Let : Expression
    {
        readonly string name;
        readonly Expression expression;

        public Let(string name, Expression expression)
        {
            this.name = name;
            this.expression = expression;
        }

        public override Value Evaluate(Environment env)
        {
            var value = expression.Evaluate(env);

            env[name] = value;

            return value;
        }
    }
}
