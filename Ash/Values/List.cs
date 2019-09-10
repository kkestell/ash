using System.Collections.Generic;
using System.Linq;

namespace Ash.Values
{
    public class List : Value
    {
        public List(List<Value> value) : base(value)
        {
        }

        public override string ToString()
        {
            var values = string.Join(
                ' ',
                GetValue<List<Value>>().Select(x => x.ToString()));

            return $"({values})";
        }
    }
}
