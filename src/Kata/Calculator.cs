using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s = null)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            var separators = new[] {",", "\n"};
            if (s.StartsWith("//"))
            {
                var parts = s.Split("\n");
                separators = new[] {parts[0].Replace("//", "")};
                s = parts[1];
            }

            var numbers = s.Split(separators, StringSplitOptions.None).Select(int.Parse);
            var negatives = numbers.Where(x => x < 0);
            if (negatives.Any())
                throw new Exception($"negatives not allowed: {string.Join(", ", negatives)}");
            return numbers.Sum();
        }
    }
}