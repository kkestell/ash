using System.Collections.Generic;
using Ash.Expressions;

namespace Ash
{
    public class Environment : Dictionary<string, Expression>
    {
        public Environment()
        {
        }

        public Environment(Environment env) : base(env)
        {
        }
    }
}
