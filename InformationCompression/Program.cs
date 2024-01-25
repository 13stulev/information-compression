using System;
using System.Collections.Generic;

namespace InformationCompression
{
    class Program
    {
        public static string line = "AABCACCBBB";
        public static List<Character> list = new List<Character>();
        public static List<char> chars = new List<char>();
        static void Main(string[] args)
        {
            findChars();
            fillList();
            Console.WriteLine("кодирование");
            double code = encode();
            Console.WriteLine("Результат: " + code);
            Console.WriteLine("Декодирование");
            string s = decode(code);
            Console.WriteLine(s);
            Console.WriteLine("Результат: " + s);
        }

        static void findChars()
        {
            foreach (char ch in line)
            {
                if (!chars.Contains(ch))
                {
                    chars.Add(ch);
                }
            }
        }
        static void fillList()
        {
            double start = 0;
            foreach (char ch in chars)
            {
                int count = line.Length - line.Replace(ch.ToString(), "").Length;
                double delta = Math.Round((double)count / (double)line.Length, 1);
                list.Add(new Character(ch, start, start + delta));
                start += delta;
            }
            list.Sort((x, y) => (y.delta).CompareTo(x.delta));
            start = 0;
            foreach (Character ch in list) {
                ch.min = start;
                ch.max = start + ch.delta;
                start += ch.delta;

            }
        }
        static double encode()
        {
            double min = 0;
            double max = 1;
            double res = 0;
            Console.WriteLine("Буква   дельта   мин   макс");
            for (int i = 0; i < line.Length; i++)
            {
                Character character = list.Find(x => x.ch.Equals(line[i]));
                double delta = max - min;
                max = min + delta * character.max;
                min = min + delta * character.min;
                Console.WriteLine(character.ch + "   " + Math.Round(delta, 6) + "   " + Math.Round(min, 8) + "   " + Math.Round(max, 8));
                res = (min + max) / 2;
            }
            return res;
        }
        static string decode(double c)
        {
            double n = c;
            string res = "";
            bool key = true;
            double delta = 0;
            Console.WriteLine("N                   Буква   Дельта");
            for (int j = 0; j < 10; j++)
            {
                Character ch = new Character();
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].min <= n && list[i].max >= n)
                    {
                        ch = list[i];
                    }
                }
                res += ch.ch;
                delta = ch.max - ch.min;
                delta = Math.Round(delta, 6);
                Console.WriteLine(n + "   " + ch.ch + "   " + delta);
                if (Math.Abs(delta + n - 1) < 0.0001)
                {
                    key = false;
                }
                n = (n - ch.min) / delta;
            }
            return res;
        }

    }
}