using BasicUtils;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;
using Console = System.Console;

namespace FastModTest
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<modrunner>();

        }

        
    }

    
}
