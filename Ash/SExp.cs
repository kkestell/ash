using System.Collections.Generic;
using System.Linq;

namespace Ash
{
    public abstract class SExp
    {
        public static IEnumerable<SExp> Parse(Queue<string> tokens)
        {
            var expressions = new List<SExp>();

            while (tokens.Any())
            {
                expressions.Add(Next(tokens));
            }

            return expressions;
        }

        private static SExp Next(Queue<string> tokens)
        {
            var token = tokens.Dequeue();

            if (token != "(")
                return new SExpAtom(token);

            var list = new SExpList();

            while (tokens.First() != ")")
                list.Contents.Enqueue(Next(tokens));

            tokens.Dequeue();

            return list;
        }
    }
}
