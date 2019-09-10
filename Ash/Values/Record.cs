using System;
using System.Collections.Generic;
using System.Linq;

namespace Ash.Values
{
    class Record : Value
    {
        public Record(Dictionary<string, Value> data) : base(data)
        {
        }

        public override string ToString()
        {
            var data = string.Join(
                ' ',
                GetValue<Dictionary<string, Value>>()
                    .Select(x => $"{x.Key} {x.Value}"));

            return $"({data})";
        }
    }
}
