using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenges
{
    public class Program1stAug2016
    {
        public static void Main(string[] args)
        {
            Program1stAug2016 program = new Program1stAug2016();
            string[] tokens = Console.ReadLine().Split(',');
            int[] values = Array.ConvertAll(tokens, Int32.Parse);
            bool result =program.isSame(values);
            Console.WriteLine(result ? "YES" : "NO");
        }

        public bool isSame(int[] values)
        {
            int rightIndex = values.Length - 1;
            int leftIndex = 0;
            int leftSum = values[leftIndex];
            int rightSum = values[rightIndex];
            while (leftIndex != rightIndex)
            {
                if (leftSum < rightSum)
                {
                    leftIndex++;
                    leftSum += values[leftIndex];

                }
                else
                {
                    rightIndex--;
                    rightSum += values[rightIndex];
                }
            }
            if (leftSum == rightSum)
            {
                return true;
            }
            return false;
        }
    }
}
