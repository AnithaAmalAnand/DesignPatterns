using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var singleObj1 = SingletonService.GetInstance();
            singleObj1.PrintPattern();

            var singleObj2 = SingletonService.GetInstance();
            singleObj2.PrintPattern();
        }
    }
}
