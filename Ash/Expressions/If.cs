using Ash.Values;

namespace Ash.Expressions
{
    class If : Expression
    {
        readonly Expression test;
        readonly Expression trueBranch;
        readonly Expression elseBranch;

        public If(Expression test, Expression trueBranch, Expression elseBranch)
        {
            this.test = test;
            this.trueBranch = trueBranch;
            this.elseBranch = elseBranch;
        }

        public override Value Evaluate(Environment env)
        {
            if (test.Evaluate(env).GetValue<bool>())
                return trueBranch.Evaluate(env);

            return elseBranch.Evaluate(env);
        }
    }
}
