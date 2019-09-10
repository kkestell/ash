using System.Collections.Generic;
using System.Linq;
using Ash.Values;

namespace Ash.Expressions
{
    class Filter : Expression
    {
        readonly Expression function;
        readonly Expression list;

        public Filter(Expression function, Expression list)
        {
            this.function = function;
            this.list = list;
        }

        public override Value Evaluate(Environment env)
        {
            var closure = function.Evaluate<Closure>(env);
            var evaluatedList = list.Evaluate<Values.List>(env);

            var newValues = evaluatedList
                .GetValue<IEnumerable<Expression>>()
                .Where(x => closure.Evaluate(new List<Value> { x.Evaluate(env) }).GetValue<bool>())
                .Select(x => x.Evaluate(env))
                .ToList();

            return new Values.List(newValues);
        }
    }
}
