using System.Collections.Generic;

namespace Ash
{
    class SExpList : SExp
    {
        public Queue<SExp> Contents { get; set; } = new Queue<SExp>();
    }
}
