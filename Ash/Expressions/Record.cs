using System.Collections.Generic;
using System.Linq;
using Ash.Values;

namespace Ash.Expressions
{
    class Record : Expression
    {
        readonly Dictionary<string, Expression> fields;

        public Record(Dictionary<string, Expression> fields)
        {
            this.fields = fields;
        }

        public override Value Evaluate(Environment env)
        {
            return new Values.Record(fields.ToDictionary(x => x.Key, x => x.Value.Evaluate(env)));
        }
    }
}
