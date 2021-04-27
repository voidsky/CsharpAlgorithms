using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariousAlgorithms
{
    class Program
    {
        static void CountChangePerformanceTest()
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 100; i < 2000; i += 100)
            {
                stopwatch.Start();
                VariousAlgorithms.CountChange(i, new int[] { 50, 25, 10, 5, 1 });
                stopwatch.Stop();
                Console.WriteLine($"{i} užtruko: {stopwatch.Elapsed}");
            }
        }
        static void Main(string[] args)
        {
            //CountChangePerformanceTest();

            Console.ReadLine();
        }
    }
}
