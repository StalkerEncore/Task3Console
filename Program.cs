using System;
using System.IO;
using System.Collections.Generic;

namespace Task3Console
{
    /*11. Реализовать функцию, которая определяет количество слов в тексте, у которых первый и
последний символы совпадают.При этом каждое слово должно быть выведено ровно
один раз.
*/
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                List<string> words = FindWordsAlter("D:/VS Projects/Task3Console/text.txt");
                foreach (string word in words)
                {
                    Console.WriteLine(word);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }

        private static List<string> FindWords(string filename)
        {
            var fin = new StreamReader(filename);
            string str = fin.ReadToEnd();
            fin.Close();
            int k = 0;
            string wrd;

            List<string> words = new List<string>();
            SkipNonLetter(str, ref k);
            while (k < str.Length)
            {
                wrd = ReadWord(str, ref k);
                SkipNonLetter(str, ref k);
                if (CheckAlmostPalindrome(wrd))
                {
                    if (!words.Contains(wrd.ToLower()))
                    {
                        words.Add(wrd);
                    }
                }
            }
            return words;
        }

        private static List<string> FindWordsAlter(string filename)
        {
            var fin = new StreamReader(filename);
            string str = fin.ReadToEnd();
            fin.Close();
            int k = 0;
            string wrd;

            Dictionary<string,int> dict = new Dictionary<string, int>();
            List<string> words = new List<string>();
            SkipNonLetter(str, ref k);
            while (k < str.Length)
            {
                wrd = ReadWord(str, ref k);
                SkipNonLetter(str, ref k);
                if (CheckAlmostPalindrome(wrd))
                {
                    dict.Add(wrd.ToLower(),0);
                }
            }
            foreach(KeyValuePair<string,int> a in dict)
            {
                words.Add(a.Key); 
            }
            return words;
        }

        private static string ReadWord(string str, ref int index)
        {
            if (index >= str.Length) return "";
            string wrd = "";
            int i;
            for (i = index; i < str.Length && Char.IsLetter(str[i]); i++)
            {
                wrd += str[i];
            }
            index = i;
            return wrd;
        }
        private static string SkipNonLetter(string str, ref int index)
        {
            if (index >= str.Length) return "";
            string wrd = "";
            int i;
            for (i = index; i < str.Length && !Char.IsLetter(str[i]); i++)
            {
                wrd += str[i];
            }
            index = i;
            return wrd;
        }

        private static bool CheckAlmostPalindrome(string wrd)
        {
            wrd = wrd.ToLower();
            return wrd[0] == wrd[wrd.Length - 1];
        }
    }
}
