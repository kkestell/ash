using System;
using Ash.Values;

namespace Ash.Expressions
{
    class Input : Expression
    {
        readonly Expression prompt;
        string memoized = string.Empty;

        public Input(Expression prompt)
        {
            this.prompt = prompt;
        }

        public override Value Evaluate(Environment env)
        {
            if (memoized != string.Empty)
            {
                return new Values.String(memoized);
            }

            var p = prompt.Evaluate(env).ToString();

            Console.WriteLine(p);
            memoized = Console.ReadLine();

            return new Values.String(memoized);
        }
    }
}
