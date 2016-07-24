using System;
using System.Diagnostics;
using MoonSharp.Interpreter;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            var testcode = @"
t = {}
for i = 1, n do
	t[i] = true
end
";
            for (var i = 1; i <= 50; i++)
            {
                var n = i * 100;
                GC.Collect(2, GCCollectionMode.Forced);
                var script = new MoonSharp.Interpreter.Script();
                script.Globals["n"] = DynValue.NewNumber(n);

                sw.Restart();
                script.DoString(testcode);
                sw.Stop();

                Console.WriteLine("{0},{1}", n, sw.Elapsed.TotalSeconds);
            }

            Console.ReadKey();
        }
    }
}
