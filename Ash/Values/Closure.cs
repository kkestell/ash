using System.Collections.Generic;
using System.Linq;
using Ash.Expressions;

namespace Ash.Values
{
    public class Closure : Value
    {
        public Lambda Lambda { get; set; }

        public Environment Environment { get; set; }

        public Closure(Lambda lambda, Environment env) : base(null)
        {
            Lambda = lambda;
            Environment = env;
        }

        public Value Evaluate(IEnumerable<Value> runtime)
        {
            var parameters = Lambda.Parameters.Zip(runtime, (p, arg) => (p, arg)).ToList();

            var env = new Environment(Environment);

            foreach (var (p, arg) in parameters)
            {
                env[p] = arg;
            }

            env["self"] = this;

            Value value = new Void();

            foreach (var expression in Lambda.Body)
                value = expression.Evaluate(env);

            return value;
        }

        public override string ToString()
        {
            return "λ";
        }
    }
}
