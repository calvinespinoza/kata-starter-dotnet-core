using System;
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

            var delimiter = "";
            var values = s;
            if (s.Contains("//"))
            {
                var parts = s.Split('\n');
                delimiter = parts[0].Replace("//", "");
                values = parts[1];
            }

            var delimiters = new[] {",", "\n"};
            if (!string.IsNullOrEmpty(delimiter))
                delimiters = new[] {",", "\n", delimiter};
            var numbers = values.Split(delimiters, StringSplitOptions.None).Select(int.Parse);
            return numbers.Sum();
        }
    }
}