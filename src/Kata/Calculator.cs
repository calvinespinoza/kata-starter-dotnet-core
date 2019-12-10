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

            return nums.Sum();
        }
    }
}