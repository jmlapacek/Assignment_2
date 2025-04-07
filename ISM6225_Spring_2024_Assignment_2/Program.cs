using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                HashSet<int> seen = new HashSet<int>();
                List<int> result = new List<int>();

                // Step 1: Add all numbers from the array to the HashSet
                foreach (int num in nums)
                {
                    seen.Add(num);
                }

                // Step 2: Loop from 1 to n, check what's missing
                for (int i = 1; i <= nums.Length; i++)
                {
                    if (!seen.Contains(i))
                    {
                        result.Add(i);
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }

            // edge cases are test of the program by feeding potentially problematic inputs to the algorithm, such as
            // duplicate values, empty arrays, null values, or values outside the expected range.   These test cases
            // can be input to the algorithm to prove it is robust.
            // Edge cases for this method include:
            // - Duplicate values (e.g., [1, 1], also provided as a sample input and yielding the output [2])
            // - Empty array (e.g., [] gave an empty output)
            // - All numbers present (e.g., [1, 2, 3] yielded an empty output)
            // - Numbers outside the expected range (e.g., [100, 200] yielded [1, 2])
            // These tests ensure the method correctly identifies missing numbers from 1 to n.
        }



        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Write your code here
                //return new int[0]; // Placeholder
                int left = 0;
                int right = nums.Length - 1;

                while (left < right)
                {
                    if (nums[left] % 2 > nums[right] % 2)
                    {
                        int temp = nums[left];
                        nums[left] = nums[right];
                        nums[right] = temp;
                    }

                    if (nums[left] % 2 == 0) left++;
                    if (nums[right] % 2 == 1) right--;
                }

                return nums;
            }
            catch (Exception)
            {
                throw;
            }
            // Handles edge cases like all even numbers, all odd numbers, and empty arrays.
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Write your code here
                // return new int[0]; // Placeholder
                Dictionary<int, int> map = new Dictionary<int, int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];

                    if (map.ContainsKey(complement))
                    {
                        return new int[] { map[complement], i };
                    }

                    map[nums[i]] = i;
                }

                return new int[0]; // If no solution found
            }
            catch (Exception)
            {
                throw;
            }
            //solution worked with edge cases like negative numbers, duplicates, or an array with no valid pair. 
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Write your code here
                //return 0; // Placeholder
                Array.Sort(nums);  // Sort the array

                int n = nums.Length;

                // Compare product of 3 largest vs. 2 smallest times the largest
                int option1 = nums[n - 1] * nums[n - 2] * nums[n - 3];
                int option2 = nums[0] * nums[1] * nums[n - 1];

                return Math.Max(option1, option2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Write your code here
                //return "101010"; // Placeholder
                return Convert.ToString(decimalNumber, 2);
            }
            catch (Exception)
            {
                throw;
            }
            //works with edge cases 0 and 1.
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                // Write your code here
                //return 0; // Placeholder
                int left = 0;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int mid = left + (right - left) / 2;

                    if (nums[mid] > nums[right])
                    {
                        // The minimum is in the right half
                        left = mid + 1;
                    }
                    else
                    {
                        // The minimum is in the left half (including mid)
                        right = mid;
                    }
                }

                return nums[left];
            }
            catch (Exception)
            {
                throw;
            }
            //This solution was not robust to an empty array.  A simple "return nums.Min();" would work here and be
            //robust, but according to Copilot', would not take advantage of the sorted, rotated nature of the array.
            //Retaining this solution, though, because an empty array is by nature not a "sorted, rotated array."
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Write your code here
                //return false; // Placeholder

                //convert the number to a string and a character array
                string s = x.ToString();
                char[] arr = s.ToCharArray();
                //reverse the array
                Array.Reverse(arr);
                //converts the array back to a string
                string reversed = new string(arr);
                //compares the original string to the reversed string
                //if they match, it's a palindrome
                return s == reversed;
            }
            catch (Exception)
            {
                throw;
            }
            // runs with single digits, zero, negative numbers, and other non-palindromes (negative numbers
            // are not palindromes because of the "-" sign).
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Write your code here
                //return 0; // Placeholder
                // Validate input (provided by Copilot)
                if (n < 0 || n > 30)
                {
                    throw new ArgumentOutOfRangeException(nameof(n), "Input must be in the range 0 <= n <= 30.");
                }

                if (n == 0) return 0;
                if (n == 1) return 1;

                int prev1 = 1; // F(n-1)
                int prev2 = 0; // F(n-2)
                int result = 0;

                for (int i = 2; i <= n; i++)
                {
                    result = prev1 + prev2;
                    prev2 = prev1;
                    prev1 = result;
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
