using System.Linq;
using Ash.Values;

namespace Ash.Expressions
{
    class Range : Expression
    {
        readonly Expression count;

        public Range(Expression count)
        {
            this.count = count;
        }

        public override Value Evaluate(Environment env)
        {
            var cnt = (int) count.Evaluate<Number>(env).GetValue<double>();
            var numbers = Enumerable.Range(0, cnt).Select(x => new Number(x));

            return new Values.List(numbers.Select(x => x.Evaluate(env)).ToList());
        }
    }
}
