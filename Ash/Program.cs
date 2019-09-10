using System;
using System.IO;
using System.Linq;

namespace Ash
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: ash [filename]");
                return 1;
            }

            var source = File.ReadAllText(args[0]);

            var expressions = Parser.Parse(source);

            var env = new Environment();

            try
            {
                expressions.Select(x => x.Evaluate(env)).ToList();
            }
            catch (TypeException e)
            {
                Console.WriteLine($"Error: {e.Message}");

                return 1;
            }

            return 0;
        }
    }
}
