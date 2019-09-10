using System.Collections.Generic;
using System.Linq;
using Ash.Values;

namespace Ash.Expressions
{
    class Reduce : Expression
    {
        readonly Expression function;
        readonly Expression list;

        public Reduce(Expression function, Expression list)
        {
            this.function = function;
            this.list = list;
        }

        public override Value Evaluate(Environment env)
        {
            var closure = function.Evaluate<Closure>(env);
            var evaluatedList = list.Evaluate<Values.List>(env);

            var aggregate = evaluatedList
                .GetValue<IEnumerable<Expression>>()
                .Aggregate(
                    (x, y) => closure.Evaluate(
                        new List<Value> { x.Evaluate(env), y.Evaluate(env) }))
                .Evaluate(env);

            return aggregate;
        }
    }
}
