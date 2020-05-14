using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data.HashFunction;
using System.Data.HashFunction.MurmurHash;
using System.Data.HashFunction.xxHash;
using System.Data.HashFunction.CityHash;
using System.Data.HashFunction.BernsteinHash;
 
namespace Count
{
    public class Program
    {
        public static readonly IMurmurHash1 hashMurMur = MurmurHash1Factory.Instance.Create();
        public static readonly IxxHash hashXx = xxHashFactory.Instance.Create();
        public static readonly ICityHash hashCity = CityHashFactory.Instance.Create();
        public static readonly IBernsteinHash hashBernstein = BernsteinHashFactory.Instance.Create();
        public static readonly NewSHA1 sha = new NewSHA1();
        public static readonly NewMD5 md5 = new NewMD5();

        public static void RealCount(string file)
        {
            Dictionary<string, int> wordsDictionary = new Dictionary<string, int>();
            int totalWords = 0;

            using (StreamReader sr = new StreamReader(file))
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    string[] words = line.Split();
                    foreach (string word in words)
                    {
                        if (string.IsNullOrWhiteSpace(word)) continue;

                        try
                        {
                            wordsDictionary.Add(word, 1);
                        }
                        catch (ArgumentException)
                        {
                            wordsDictionary[word]++;
                        }

                        totalWords++;
                        //Console.WriteLine(word);                        
                    }
                }
            }

            Console.WriteLine($"Total: {totalWords}; Distinct words: {wordsDictionary.Count()}");

        }

        public static UInt64 TruncateBytes(UInt64 bytes, int bitLength)
        {
            if (bitLength == 64) return bytes;
            var bitMask = (1UL << bitLength) - 1UL;
            return bytes & bitMask;
        }

        public static UInt64 TruncateBytes(byte[] fullHashBytes, int bitLength)
        {
            byte[] newArray = new byte[8];
            Array.Copy(fullHashBytes, newArray, (fullHashBytes.Length <= newArray.Length ? fullHashBytes.Length : newArray.Length));
            UInt64 bytes = BitConverter.ToUInt64(newArray, 0);
            return TruncateBytes(bytes, bitLength);
        }

        public static UInt64 PosLSB(UInt64 hashBytes)
        {
            // 0000010101011000[0] ->
            UInt32 pos = 0;
            while ((hashBytes & 1) == 0)
            {
                hashBytes >>= 1;
                ++pos;
            }
            return pos;
        }

        /* Implementation of Flajolet-Martin algorithm. */
        private static void ProbCount(string file, IHashFunction hashFunction)
        {
            const int L = 32;
            int[] bitmap = new int[L]; // 111111100000000 (log2 N)

            #region Read word from a file and...
            using (StreamReader sr = new StreamReader(file))
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    string[] words = line.Split();
                    foreach (string word in words)
                    {                        
                        if (string.IsNullOrWhiteSpace(word)) continue;
                        #endregion

                        byte[] hashBytes = hashFunction.ComputeHash(word).Hash;
                        UInt64 hash = TruncateBytes(hashBytes, L);
                        UInt64 index = PosLSB(hash);

                        if (bitmap[index] == 0) bitmap[index] = 1;
                    }
                }
            }

            int i = FindMagicBitPosition(bitmap);

            #region Print it out..
            Console.Write($"ProbCount;[");
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{string.Join(",", bitmap.Take(i))}");
            Console.ForegroundColor = oldColor;
            Console.Write($",{string.Join(",", bitmap.Skip(i))}");
            Console.WriteLine($"], {i}, {Math.Pow(2,i)}, {hashFunction.GetType().Name}");
            #endregion
        }

        /* Implementation of Adaptive Sampling algorithm (Flajolet-Chesnay). */
        private static void AdaptiveSampling(string file, IHashFunction hashFunction)
        {
            const int m = 64;
            List<String> list = new List<string>();
            int depth = 0;

            #region Read word from a file and...
            using (StreamReader sr = new StreamReader(file))
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    string[] words = line.Split();
                    foreach (string word in words)
                    {
                        #endregion
                        if (string.IsNullOrWhiteSpace(word)) continue;

                        string hash = hashFunction.ComputeHash(word).AsBase64String();

                        if (HasProperty(hash, depth))
                            if (!list.Contains(hash)) list.Add(hash);

                        while (list.Count >= m)
                        {
                            depth++;
                            List<String> tempList = new List<string>();
                            foreach (string h in list)
                                if (HasProperty(h, depth))
                                        if (!tempList.Contains(h)) 
                                            tempList.Add(h);
                            list = tempList;
                        }                        
                    }
                }
            }

            double distCount = Math.Pow(2, depth) * list.Count; 
            Console.WriteLine($"AdaptiveSampling;{distCount}, (Depth:{depth},List:{list.Count}), {hashFunction.GetType().Name}");
        }

        private static bool HasProperty(string base64string, int depth)
        {
            byte[] bytes =  Convert.FromBase64String(base64string);
            UInt64 a = TruncateBytes(bytes, 32);

            var bitMask = (1UL << depth) - 1UL; // xxxx xxx1 xx11 x111 111 ...
            return (a & bitMask) == 0;
        }

        private static int FindMagicBitPosition(int[] bitmap)
        {
            int i = 0;
            while (bitmap[i] != 0 && i < bitmap.Length) i++;
            return i;
        }


        static void Main(string[] args)
        {
            string file = args.Length>0 ? args[0] : "alice.txt";

            RealCount(file);

            ProbCount(file, hashMurMur);
            ProbCount(file, hashXx);
            ProbCount(file, hashCity);
            ProbCount(file, hashBernstein);
            ProbCount(file, sha);
            ProbCount(file, md5);

            AdaptiveSampling(file, hashMurMur);
            AdaptiveSampling(file, hashXx);
            AdaptiveSampling(file, hashCity);
            AdaptiveSampling(file, hashBernstein);
            AdaptiveSampling(file, sha);
            AdaptiveSampling(file, md5);

        }

    }
}
