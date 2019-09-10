using Ash.Values;

namespace Ash.Expressions.String
{
    class Replace : Expression
    {
        readonly Expression str;
        readonly Expression search;
        readonly Expression replace;

        public Replace(Expression str, Expression search, Expression replace)
        {
            this.str = str;
            this.search = search;
            this.replace = replace;
        }

        public override Value Evaluate(Environment env)
        {
            var str = this.str.Evaluate(env).GetValue<string>();
            var search = this.search.Evaluate(env).GetValue<string>();
            var replace = this.replace.Evaluate(env).GetValue<string>();

            return new Values.String(str.Replace(search, replace));
        }
    }
}
