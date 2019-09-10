using System.Linq;
using Ash;
using Ash.Values;

namespace Tests
{
    public abstract class UnitTest
    {
        protected Value Evaluate(string src)
        {
            var env = new Environment();
            return Parser.Parse(src)
                .Select(x => x.Evaluate(env))
                .ToList()
                .Last();
        }
    }
}