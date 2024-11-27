using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp1
{
    internal static class PerfectNumber
    {
        public static bool IsPerfect(int number)
        {
            if (number < 2) return false;

            var divisors = GetDivisors(number);

            return divisors.Sum() == number;
        }

        public static List<int> FindPerfectNumbers(int limit) =>
            Enumerable.Range(2, limit - 1).Where(IsPerfect).ToList();

        public static List<int> GenerateEvenPerfectNumbers(int maxP)
        {
            var perfectNumbers = new List<int>();

            for (int p = 2; p <= maxP; p++)
            {
                if (IsPrime(p))
                {
                    int mersennePrime = (1 << p) - 1;
                    if (IsPrime(mersennePrime))
                    {
                        int perfectNumber = (1 << (p - 1)) * mersennePrime;
                        perfectNumbers.Add(perfectNumber);
                    }
                }
            }

            return perfectNumbers;
        }

        private static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number <= 3) return true;
            if (number % 2 == 0 || number % 3 == 0) return false;

            for (int i = 5; i * i <= number; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                    return false;
            }

            return true;
        }

        public static List<int> FindMersennePrimes(int limit)
        {
            var mersennePrimes = new List<int>();
            for (int p = 2; p <= limit; p++)
            {
                if (IsPrime(p))
                {
                    int mersennePrime = (1 << p) - 1;
                    if (IsPrime(mersennePrime))
                    {
                        mersennePrimes.Add(mersennePrime);
                    }
                }
            }
            return mersennePrimes;
        }

        public static List<int> FindDeficientNumbers(int limit)
        {
            return Enumerable.Range(1, limit).Where(n =>
            {
                var divisors = GetDivisors(n);
                return divisors.Sum() < n;
            }).ToList();
        }

        public static List<int> FindAbundantNumbers(int limit)
        {
            return Enumerable.Range(1, limit).Where(n =>
            {
                var divisors = GetDivisors(n);
                return divisors.Sum() > n;
            }).ToList();
        }

        private static List<int> GetDivisors(int number)
        {
            var divisors = new List<int> { 1 };

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    divisors.Add(i);
                    if (i != number / i)
                        divisors.Add(number / i);
                }
            }

            return divisors;
        }

        public static Dictionary<string, List<int>> HybridAnalysis(int limit)
        {
            var perfect = FindPerfectNumbers(limit);
            var deficient = FindDeficientNumbers(limit);
            var abundant = FindAbundantNumbers(limit);

            return new Dictionary<string, List<int>>
            {
                { "Perfect Numbers", perfect },
                { "Deficient Numbers", deficient },
                { "Abundant Numbers", abundant }
            };
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Number Analysis Program!");

            Console.Write("Enter the upper limit for number analysis (e.g., 1000): ");
            int limit = int.Parse(Console.ReadLine());

            int maxP = (int)Math.Log2(limit) - 1; 
            Console.WriteLine($"Automatically set maximum value for 'p' in even perfect numbers to: {maxP}");

            Console.WriteLine("\nStarting numerical analysis...\n");

            ExecuteAndDisplay("Perfect Numbers", () => PerfectNumber.FindPerfectNumbers(limit));
            ExecuteAndDisplay("Even Perfect Numbers", () => PerfectNumber.GenerateEvenPerfectNumbers(maxP));
            ExecuteAndDisplay("Mersenne Primes", () => PerfectNumber.FindMersennePrimes(maxP));
            ExecuteAndDisplay("Deficient Numbers", () => PerfectNumber.FindDeficientNumbers(limit));
            ExecuteAndDisplay("Abundant Numbers", () => PerfectNumber.FindAbundantNumbers(limit));

            Console.WriteLine("Hybrid Number Analysis");
            Console.WriteLine("===========================\n");
            var hybridResults = PerfectNumber.HybridAnalysis(limit);
            foreach (var (category, numbers) in hybridResults)
            {
                Console.WriteLine($"{category}:");
                if (numbers.Any())
                    Console.WriteLine(string.Join(", ", numbers));
                else
                    Console.WriteLine("No data.");
                Console.WriteLine();
            }

            Console.WriteLine("Analysis completed.");
        }

        private static void ExecuteAndDisplay(string title, Func<List<int>> method)
        {
            Console.WriteLine(title);
            Console.WriteLine(new string('-', title.Length));

            Stopwatch stopwatch = Stopwatch.StartNew();
            var results = method.Invoke();
            stopwatch.Stop();

            if (results.Any())
            {
                var resultString = string.Join(", ", results);
                Console.WriteLine(resultString);
            }
            else
            {
                Console.WriteLine("No data.");
            }

            var timeTaken = $"Execution time: {stopwatch.ElapsedMilliseconds} ms";
            Console.WriteLine(timeTaken);
            Console.WriteLine();
        }
    }
}
