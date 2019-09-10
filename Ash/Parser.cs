using System;
using System.Collections.Generic;
using System.Linq;
using Ash.Expressions;

namespace Ash
{
    public static class Parser
    {
        public static IEnumerable<Expression> Parse(string input)
        {
            var chars = new Queue<char>(input.Trim());
            var tokens = new List<string>();

            string token;
            while ((token = ParseToken(chars)) != null)
            {
                if (!string.IsNullOrEmpty(token))
                    tokens.Add(token);
            }

            return SExp.Parse(new Queue<string>(tokens)).Select(Expression.From).ToList();
        }

        static string ParseToken(Queue<char> chars)
        {
            if (!chars.Any())
                return null;

            SkipWhitespace(chars);

            var next = chars.Peek();

            if (next == '#')
            {
                SkipComment(chars);
                return string.Empty;
            }

            if (next == '(' || next == ')')
                return chars.Dequeue().ToString();

            if (next == '"')
                return ParseString(chars);

            if (next == '-' || char.IsDigit(next))
                return ParseNumber(chars);

            return ParseSymbol(chars);
        }

        static void SkipComment(Queue<char> chars)
        {
            while (true)
            {
                var c = chars.Dequeue();

                if (c == '\n' || !chars.Any())
                    break;
            }
        }

        static void SkipWhitespace(Queue<char> chars)
        {
            if (IsWhitespace(chars.Peek()))
            {
                while (true)
                {
                    chars.Dequeue();

                    if (!IsWhitespace(chars.Peek()))
                        break;
                }
            }
        }

        static string ParseString(Queue<char> chars)
        {
            var str = string.Empty;

            str += chars.Dequeue();

            while (true)
            {
                var c = chars.Dequeue();

                str += c;

                if (c == '"')
                    break;
            }

            return str.Replace("\\n", "\n");
        }

        static string ParseNumber(Queue<char> chars)
        {
            var str = string.Empty;

            while (true)
            {
                if (IsDone(chars.Peek()))
                    break;

                var c = chars.Dequeue();

                if (!char.IsDigit(c) && c != '.' && c != '-')
                    throw new Exception($"Unexpected character in number: {c}");

                str += c;
            }

            return str;
        }

        static string ParseSymbol(Queue<char> chars)
        {
            var str = string.Empty;

            if (chars.Peek() == ':')
                str += chars.Dequeue();

            while (!IsDone(chars.Peek()))
            {
                var c = chars.Dequeue();

                if (!IsSymbolCharacter(c))
                    throw new Exception($"Unexpected character in symbol: {c}");

                str += c;
            }

            return str;
        }

        static bool IsDone(char c)
        {
            var chars = new char[] 
            {
                ' ', '\n', ')', '#'
            };

            return chars.Contains(c);
        }

        static bool IsWhitespace(char c)
        {
            var chars = new char[] 
            {
                ' ', '\t', '\n'
            };

            return chars.Contains(c);
        }

        static bool IsSymbolCharacter(char c)
        {
            var chars = new char[] 
            {
                '-', '!', '?', '>', '<', '+', '-', '*', '/', '=', '%'
            };

            return char.IsDigit(c) || char.IsLetter(c) || chars.Contains(c);
        }
    }
}
