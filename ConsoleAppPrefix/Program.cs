using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppPrefix
{
    class Program
    {
        public static IEnumerable<string> AllPrefixesAnt(int prefixLength, IEnumerable<string> words)
        {
            var result = new List<string>();

            foreach (var word in words)
            {
                if (word.Length >= prefixLength)
                {
                    var wordPart = word.Substring(0, prefixLength);
                    if (!result.Any(x => x.Equals(wordPart)))
                        result.Add(wordPart);
                }
            }

            return result;
        }

        public static IEnumerable<string> AllPrefixes(int prefixLength, IEnumerable<string> words)
        {
            var result =
                from word in 
                    from word in
                        from word in words
                        where word.Length >= prefixLength
                        select word.Substring(0, prefixLength)
                group word by word
                select word.Key;

            return result;
        }

        public static void Main(string[] args)
        {
            foreach (var p in AllPrefixes(3, new string[] { "flow", "flowers", "flew", "flag", "fm" }))
                Console.WriteLine(p);
            Console.ReadLine();
        }
    }
}