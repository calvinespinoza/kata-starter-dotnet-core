using System;

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

            return Convert.ToInt32(number);
        }
    }
}