using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNSmallest
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1000_000;
            int k = 1000;

            Console.WriteLine($"Sukurti efektyvų algoritmą ir parašyti programą, kuri iš n skaičių surastų k mažiausių.");
            Console.WriteLine($"Generuojame {n} atsitiktiniu skaiciu...");
            NSmallestUsingBST nsm = new NSmallestUsingBST();
            nsm.Randomize(n);

            Console.WriteLine($"Randame {k} maziausiu.");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<int> smallest = nsm.FindSmallest(k);
            stopwatch.Stop();

            Console.WriteLine("Užtruko: {0}", stopwatch.Elapsed);
            Console.ReadLine();
        }
    }
}
