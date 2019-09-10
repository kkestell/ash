using System.Collections.Generic;
using System.Linq;
using Ash.Values;

namespace Ash.Expressions
{
    class Last : Expression
    {
        readonly Expression list;

        public Last(Expression list)
        {
            this.list = list;
        }

        public override Value Evaluate(Environment env)
        {
            var theList = list.Evaluate<Values.List>(env).GetValue<IEnumerable<Value>>();

            return theList.Last();
        }
    }
}
