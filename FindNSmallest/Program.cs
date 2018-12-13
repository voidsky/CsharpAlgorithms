using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sort;

namespace FindNSmallest
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 100000;
            int k = 10;

            Console.WriteLine($"Sukurti efektyvų algoritmą ir parašyti programą, kuri iš n skaičių surastų k mažiausių.");
            Console.WriteLine($"Generuojame {n} atsitiktiniu skaiciu...");

            Random rand = new Random();
            List<int> randomBytes = new List<int>();
            for (int i = 1; i <= n; i++)
                randomBytes.Add(rand.Next());

            NSmallestUsingBST nsm = new NSmallestUsingBST();
            nsm.SetNumbers(randomBytes);

            Console.WriteLine($"Randame {k} maziausiu naudojant BST.");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<int> smallest = nsm.FindSmallest(k);
            stopwatch.Stop();

            Console.WriteLine("Užtruko: {0}", stopwatch.Elapsed);
            Console.ReadLine();

            Console.WriteLine($"Randame {k} maziausiu naudojant Selection sort (rusiavimas paieska).");
            List<int> randomBytes2 = new List<int>(randomBytes);
            stopwatch.Start();
            Selection<int>.FindSmallest(randomBytes2.ToArray(),k);
            stopwatch.Stop();

            Console.WriteLine("Užtruko: {0}", stopwatch.Elapsed);
            Console.ReadLine();
            
            // ------------------------------------------------- 

            Console.WriteLine($"Randame {k} maziausiu naudojant Insertion sort (rusiavimas sukeitimu).");
            List<int> randomBytes3 = new List<int>(randomBytes);
            stopwatch.Start();
            Insertion<int>.FindSmallest(randomBytes3.ToArray(), k);
            stopwatch.Stop();

            Console.WriteLine("Užtruko: {0}", stopwatch.Elapsed);
            Console.ReadLine();

            // ------------------------------------------------- 

            Console.WriteLine($"Randame {k} maziausiu naudojant Shell sort.");
            List<int> randomBytes4 = new List<int>(randomBytes);
            stopwatch.Start();
            Shell<int>.FindSmallest(randomBytes4.ToArray(), k);
            stopwatch.Stop();

            Console.WriteLine("Užtruko: {0}", stopwatch.Elapsed);
            Console.ReadLine();


        }
    }
}
