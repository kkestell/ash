using System;
using System.Linq;
using Ash.Expressions.String;
using Ash.Values;

namespace Ash.Expressions
{
    public abstract class Expression
    {
        public abstract Value Evaluate(Environment env);

        public T Evaluate<T>(Environment env)
        {
            return (T)(object)Evaluate(env);
        }

        public static Expression From(SExp exp)
        {
            if (exp is SExpAtom a)
                return From(a);

            if (exp is SExpList l)
                return From(l);

            throw new NotImplementedException();
        }

        static Expression From(SExpAtom atom)
        {
            if (double.TryParse(atom.Value, out double x))
                return new Number(x);

            if (atom.Value == "true")
                return new Bool(true);

            if (atom.Value == "false")
                return new Bool(false);

            if (atom.Value.First() == '"')
                return new Values.String(atom.Value.Replace("\"", ""));

            if (atom.Value.First() == ':')
                return new Values.Symbol(atom.Value);

            return new Symbol(atom.Value);
        }

        private static Expression From(SExpList root)
        {
            var head = root.Contents.Dequeue();
            if (head is SExpList h)
                return new Call(From(h), root.Contents.Select(From).ToList());

            var cast = head as SExpAtom;

            switch (cast.Value)
            {
                case ">":
                case "<":
                case "<=":
                case ">=":
                case "=":
                case "+":
                case "-":
                case "*":
                case "/":
                case "%":
                    Require(
                        root.Contents.Count == 2,
                        $"\"{cast.Value}\" operators should be followed by two expressions");

                    return new Infix(
                        cast.Value,
                        From(root.Contents.Dequeue()),
                        From(root.Contents.Dequeue()));
                
                case "count":
                    Require(
                        root.Contents.Count == 1,
                        "\"count\" statements should be followed by an expression");

                    return new Count(From(root.Contents.Dequeue()));

                case "let":
                    Require(
                        root.Contents.First() is SExpAtom,
                        "\"let\" statements should be followed by symbol");

                    var atom = (SExpAtom)root.Contents.Dequeue();

                    return new Let(atom.Value, From(root.Contents.Dequeue()));

                case "filter":
                    Require(
                        root.Contents.Count == 2,
                        "\"filter\" statements should be followed by two expressions");

                    return new Filter(
                        From(root.Contents.Dequeue()),
                        From(root.Contents.Dequeue()));

                case "first":
                    Require(
                        root.Contents.Count == 1,
                        "\"first\" statements should be followed by an expression");

                    return new First(From(root.Contents.Dequeue()));

                case "if":
                    Require(
                        root.Contents.Count == 3,
                        "\"if\" statements should be followed by three expressions");

                    return new If(
                        From(root.Contents.Dequeue()),
                        From(root.Contents.Dequeue()),
                        From(root.Contents.Dequeue()));

                case "input":
                    Require(
                        root.Contents.Count == 1,
                        "\"input\" statements should be followed by an expression");

                    return new Input(From(root.Contents.Dequeue()));

                case "lambda":
                case "λ":
                    Require(
                        root.Contents.First() is SExpList,
                        "\"lambda\" statements should be followed by list of parameters");

                    var parameters = (SExpList) root.Contents.Dequeue();

                    Require(
                        parameters.Contents.All(x => x is SExpAtom),
                        "\"lambda\" statements should be followed by list of parameters");
                        
                    return new Lambda(
                        root.Contents.Select(From).ToList(),
                        parameters.Contents.Select(x => (x as SExpAtom).Value));
                
                case "last":
                    Require(
                        root.Contents.Count == 1,
                        "\"last\" statements should be followed by an expression");

                    return new Last(From(root.Contents.Dequeue()));

                case "list":
                    return new List(root.Contents.Select(From).ToList());

                case "map":
                    Require(
                        root.Contents.Count == 2,
                        "\"map\" statements should be followed by two expressions");

                    return new Map(
                        From(root.Contents.Dequeue()),
                        From(root.Contents.Dequeue()));

                case "print":
                    Require(
                        root.Contents.Count > 0,
                        "\"print\" statements should be followed by one or more expressions");

                    return new Print(root.Contents.Select(From));

                case "random":
                    return new Random();

                case "range":
                    Require(
                        root.Contents.Count == 1,
                        "\"range\" expressions should be followed by an expression");

                    return new Range(From(root.Contents.Dequeue()));

                case "record":
                    Require(
                        root.Contents.All(x => x is SExpAtom),
                        "\"record\" statements should be followed by one or more slot/expression pairs");

                    var slots = root.Contents.ToList().Where((c, i) => i % 2 != 0);
                    var values = root.Contents.ToList().Where((c, i) => i % 2 == 0);

                    return new Record(
                        values
                            .Zip(slots, (k, v) => (k, v))
                            .ToDictionary(x => (x.k as SExpAtom).Value, x => From(x.v)));

                case "reduce":
                    Require(
                        root.Contents.Count == 2,
                        "\"reduce\" statements should be followed by two expressions");

                    return new Reduce(
                        From(root.Contents.Dequeue()),
                        From(root.Contents.Dequeue()));

                case "string-replace":
                    Require(
                        root.Contents.Count == 3,
                        "\"map\" statements should be followed by three expressions");

                    return new Replace(
                        From(root.Contents.Dequeue()),
                        From(root.Contents.Dequeue()),
                        From(root.Contents.Dequeue()));
                        
                default:
                    return new Call(From(cast), root.Contents.Select(From).ToList());
            }
        }

        private static void Require(bool assertion, string error)
        {
            if (!assertion)
                throw new Exception(error);
        }
    }
}
