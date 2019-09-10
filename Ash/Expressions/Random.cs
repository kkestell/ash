using Ash.Values;

namespace Ash.Expressions
{
    class Random : Expression
    {
        static System.Random rng = new System.Random();

        public override Value Evaluate(Environment env)
        {
            return new Number(rng.NextDouble());
        }
    }
}
