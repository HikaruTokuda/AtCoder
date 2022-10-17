using System;

namespace AtCoderKyoupro90
{
    class Program
    {
        static void Main(string[] args)
        {
            var current = new _084_ThereAreTwoTypesOfCharacters();
            while(true)
            {
                current.Run();
                Console.WriteLine("Continue?(y/n)");
                if (Console.ReadLine() == "n") break;
            }
            
            Console.ReadKey();
        }
    }
}
