using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace FastModTest
{
    public class modrunner
    {
        const int iterations = 1000000000;

        public modrunner()
        {
            //Console.WriteLine("Starting mod...");
            Modrun();
            //Console.WriteLine("Done mod.");

            //Console.WriteLine("Starting mod2...");
            Modrun2();
            //Console.WriteLine("Done mod2.");

            //Console.WriteLine("Starting mod3...");
            Modrun3();
            //Console.WriteLine("Done mod3.");
        }


        [Benchmark]
        public void Modrun()
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < iterations; i++)
            {
                numbers.Add(i);
                if (i % 100 == 0)
                {
                    //Console.WriteLine(i);
                }
            }
        }

        [Benchmark]
        public void Modrun2()
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < iterations; i++)
            {
                numbers.Add(i);
                if (BasicUtils.Math.FastModForLoop(i, 100))
                {
                    //Console.WriteLine(i);
                }
            }
        }

        [Benchmark]
        public void Modrun3()
        {
            int limit = 100;
            List<int> numbers = new List<int>();
            for (int i = 0; i < iterations; i++)
            {
                numbers.Add(i);
                if (i > (limit - 1))
                {
                    //Console.WriteLine(i);
                }
            }
        }

    }
}
