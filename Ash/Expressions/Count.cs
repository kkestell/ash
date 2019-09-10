using System.Collections.Generic;
using System.Linq;
using Ash.Values;

namespace Ash.Expressions
{
    class Count : Expression
    {
        readonly Expression list;

        public Count(Expression list)
        {
            this.list = list;
        }

        public override Value Evaluate(Environment env)
        {
            return new Number(list.Evaluate(env).GetValue<IEnumerable<Value>>().Count());
        }
    }
}
