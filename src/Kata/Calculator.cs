using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s = null)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;                
            }

            var numbers = s.Split(',', '\n').Select(int.Parse);
            return numbers.Sum();
        }
    }
}