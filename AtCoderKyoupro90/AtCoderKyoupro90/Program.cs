using System;

namespace AtCoderKyoupro90
{
    class Program
    {
        static void Main(string[] args)
        {
            var current = new _007_CPClasses();
            while(true)
            {
                var sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                current.Run();
                sw.Stop();
                TimeSpan ts = sw.Elapsed;
                Console.WriteLine($"Time span: {ts.Milliseconds}ms");
                Console.WriteLine("Continue?(y/n)");
                if (Console.ReadLine() == "n") break;
            }
        }

    }
}
