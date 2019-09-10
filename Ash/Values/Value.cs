using System;
using System.Collections.Generic;
using Ash.Expressions;

namespace Ash.Values
{
    public abstract class Value : Expression
    {
        protected object Boxed { get; private set; }

        protected Value(object value)
        {
            Boxed = value;
        }

        public T GetValue<T>()
        {
            var fromType = TypeName(Boxed.GetType());
            var toType = TypeName(typeof(T));

            try
            {
                return (T)Boxed;
            }
            catch (InvalidCastException)
            {
                throw new TypeException($"Expected {toType}, got {fromType}");
            }
        }

        public override Value Evaluate(Environment env)
        {
            return this;
        }

        private string TypeName(Type t)
        {
            if (t == typeof(double))
                return "Number";

            if (t == typeof(string))
                return "String";

            if (t == typeof(bool))
                return "Bool";

            if (t == typeof(IEnumerable<Value>))
                return "List";

            if (t == typeof(Closure))
                return "Closure";

            if (t == typeof(Void))
                return "Void";

            return "Unknown";
        }
    }
}
