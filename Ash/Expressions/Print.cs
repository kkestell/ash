using System;
using System.Collections.Generic;
using System.Linq;
using Ash.Values;

namespace Ash.Expressions
{
    class Print : Expression
    {
        readonly IEnumerable<Expression> expressions;

        public Print(IEnumerable<Expression> expressions)
        {
            this.expressions = expressions;
        }

        public override Value Evaluate(Environment env)
        {
            Console.WriteLine(string.Join("", expressions.Select(x => x.Evaluate(env))));
            return new Values.Void();
        }
    }
}
