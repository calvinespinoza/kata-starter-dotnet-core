using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s = null)
        {
            if(string.IsNullOrEmpty(s))
                return 0;

            var delimiters = new[] {",", "\n"};
            var content = s;
            if (s.StartsWith("//"))
            {
                var parts = s.Split("\n");
                delimiters = new[] {parts[0].Replace("//", "")};
                content = parts[1];
            }
            var numbers = content.Split(delimiters, StringSplitOptions.None).Select(int.Parse);
            var negatives = numbers.Where(x => x < 0);
            if (negatives.Count() > 0)
            {
                throw new Exception($"negatives not allowed: {string.Join(", ",negatives)}");
            }
                
            return numbers.Where(x => x < 1001).Sum();
        }
    }
}