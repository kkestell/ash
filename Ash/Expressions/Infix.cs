using System;
using Ash.Values;

namespace Ash.Expressions
{
    class Infix : Expression
    {
        readonly string op;
        readonly Expression left;
        readonly Expression right;

        public Infix(string op, Expression left, Expression right)
        {
            this.op = op;
            this.left = left;
            this.right = right;
        }

        public override Value Evaluate(Environment env)
        {
            var l = left.Evaluate(env).GetValue<double>();
            var r = right.Evaluate(env).GetValue<double>();

            switch (op)
            {
                case ">":
                    return new Bool(l > r);
                case "<":
                    return new Bool(l < r);
                case "<=":
                    return new Bool(l <= r);
                case ">=":
                    return new Bool(l >= r);
                case "=":
                    return new Bool(NearlyEqual(l, r, double.Epsilon));
                case "+":
                    return new Number(l + r);
                case "*":
                    return new Number(l * r);
                case "/":
                    return new Number(l / r);
                case "-":
                    return new Number(l - r);
                case "%":
                    return new Number(l % r);
                default:
                    throw new NotImplementedException();
            }
        }

        private static bool NearlyEqual(double a, double b, double epsilon)
        {
            const double MinNormal = 2.2250738585072014E-308d;

            var absA = Math.Abs(a);
            var absB = Math.Abs(b);
            var diff = Math.Abs(a - b);

            if (a.Equals(b))
            {
                // Shortcut, handles infinities
                return true;
            }

            if (a == 0 || b == 0 || diff < MinNormal)
            {
                // a or b is zero or both are extremely close to it
                // so relative error is less meaningful
                return diff < (epsilon * MinNormal);
            }

            // Use relative error
            return diff / (absA + absB) < epsilon;
        }
    }
}
