using System.Collections.Generic;
using System.Linq;
using Ash.Values;

namespace Ash.Expressions
{
    class Call : Expression
    {
        readonly Expression body;
        readonly IEnumerable<Expression> arguments;

        public Call(Expression body, IEnumerable<Expression> arguments)
        {
            this.body = body;
            this.arguments = arguments;
        }

        public override Value Evaluate(Environment env)
        {
            var closure = body.Evaluate<Closure>(env);
            var runtime = arguments.Select(x => x.Evaluate(env));

            return closure.Evaluate(runtime);
        }
    }
}
