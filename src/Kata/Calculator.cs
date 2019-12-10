using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string number = "")
        {
            if (number == "")
            {
                return 0;
            }

            var nums = number.Split(",").Select(int.Parse).ToArray();
            if (nums.Length == 1)
                return nums[0];
            return nums[0] + nums[1];
        }
    }
}