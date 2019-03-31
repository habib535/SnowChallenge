using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility
{
    public class Functions
    {
        /// <summary>
        /// Reverses a string.
        /// </summary>
        /// <param name="value">String to reverse.</param>
        /// <returns>Reversed string.</returns>
        public static string ReverseString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return value;
            }
            char[] output = new char[value.Length];

            for (int start = 0, end = value.Length - 1; start <= end; ++start, --end)
            {
                output[start] = value[end];
                output[end] = value[start];
            }

            return new String(output);
        }

        /// <summary>
        /// Calculates the Nth fibonacci number.
        /// </summary>
        /// <param name="n">Fibonacci number to calculate.</param>
        /// <returns>The nth fibonacci number.</returns>
        public static int CalculateNthFibonacciNumber(int n)
        {
            if (n <= 0)
            {
                return 0;
            }
            if (n == 1 || n == 2)
            {
                return 1;
            }


            int first = 1;
            int second = 1;
            int next = 1;

            for (int i = 3; i <= n; i++)
            {
                next = second + first;
                first = second;
                second = next;
            }
            return next;
        }

        /// <summary>
        /// Pads a number with up to four zeroes, returning a string with a total length of five numerical characters.
        /// </summary>
        /// <param name="number">Number to pad.</param>
        /// <returns>Zero-padded number.</returns>
        /// <remarks>Can only pad unsigned numbers up to 99999.</remarks>
        public static string PadNumberWithZeroes(int number)
        {
            if (number >= 0 && number <= 99999)
            {
                return number.ToString().PadLeft(5, '0');
            }
            else
            {
                return number.ToString();
            }
        }

        /// <summary>
        /// Determines if a year is a leap year.
        /// </summary>
        /// <param name="year">Year to determine.</param>
        /// <returns>True if leap year, false if not.</returns>
        public static bool IsLeapYear(int year)
        {
            return DateTime.IsLeapYear(year);
        }

        /// <summary>
        /// Find the N:th largest number in a range of numbers.
        /// </summary>
        /// <param name="numbers">List of integers.</param>
        /// <returns>The third largest number in list.</returns>
        public static int FindNthLargestNumber(List<int> numbers, int nthLargestNumber)
        {
            if (numbers.Count < nthLargestNumber)
            {
                throw new IndexOutOfRangeException("nthLargestNumber index is greater than list size");
            }
            numbers.Sort();
            return numbers[nthLargestNumber];
        }

        /// <summary>
        /// Selects all prime numbers from an enumerable with numbers.
        /// </summary>
        /// <param name="numbers">Enumerable with numbers.</param>
        /// <returns>An enumerable with only prime numbers.</returns>
        public static IEnumerable<int> SelectPrimeNumbers(IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
            {
                if (isPrime(number))
                {
                    yield return number;
                }
            }
        }

        private static bool isPrime(int number)
        {
            //convert to absolute
            number = Math.Abs(number);
            if (number == 0 || number == 1) return false;
            if (number == 2) return true;

            for (int i = 3; i <= number / 2; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        /// <summary>
        /// Determines if the bit pattern of value the same if you reverse it.
        /// </summary>
        /// <param name="value">Value to inspect.</param>
        /// <returns>True if the bit value is a palindrome otherwise false.</returns>
        public static bool IsPalindrome(int value)
        {
            int existing = Math.Abs(value);
            int generated = 0;
            while (existing > 0)
            {
                int remainder = existing % 10;
                generated = generated * 10 + remainder;
                existing = existing / 10;
            }

            return generated == value;
        }

        /// <summary>
        /// Counts all set bits in an int value.
        /// </summary>
        /// <param name="value">Integer value to count bits in.</param>
        /// <returns>Number of set bits in integer value.</returns>
        public static int CountSetBits(int value)
        {
            //I am not good at bitwise operations, probably need to spend some time learning and practicing it
            throw new NotImplementedException();
        }
    }
}
