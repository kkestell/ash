using System.Collections.Generic;
using Ash.Values;

namespace Ash.Expressions
{
    public class Lambda : Expression
    {
        public IEnumerable<Expression> Body { get; private set; }
        public IEnumerable<string> Parameters { get; private set; }

        public Lambda(IEnumerable<Expression> body, IEnumerable<string> parameters)
        {
            Body = body;
            Parameters = parameters;
        }

        public override Value Evaluate(Environment env)
        {
            return new Closure(this, new Environment(env));
        }
    }
}
