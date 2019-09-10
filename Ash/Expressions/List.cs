using System.Collections.Generic;
using System.Linq;
using Ash.Values;

namespace Ash.Expressions
{
    class List : Expression
    {
        readonly List<Expression> expressions;

        public List(List<Expression> expressions)
        {
            this.expressions = expressions;
        }

        public override Value Evaluate(Environment env)
        {
            return new Values.List(expressions.Select(x => x.Evaluate(env)).ToList());
        }
    }
}
