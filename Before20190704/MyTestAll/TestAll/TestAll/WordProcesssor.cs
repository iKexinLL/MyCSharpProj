using System;
using System.Collections.Generic;
using System.Text;

namespace TestAll
{
    static class WordProcesssor
    {
        private static List<string> GetWords(
            string sentence, 
            bool capitalizeWords = false,
            bool reverseOrder = false,
            bool reverseWords = false)
        {
            List<string> words = new List<string>(sentence.Split(' '));

            if (capitalizeWords)
                words = CapitalizeWords(words);
            if (reverseOrder)
                words = ReverseOrder(words);
            if (reverseWords)
                words = ReverseWords(words);

            return words;
        }

        private static List<string> ReverseWords(List<string> words)
        {
            List<string> reverseWords = new List<string>();

            foreach (var word in words)
            {
                reverseWords.Add(ReverseWord(word));
            }

            return reverseWords;
        }

        private static string ReverseWord(string word)
        {
            StringBuilder sb = new StringBuilder();

            for (int characterIndex = word.Length - 1; characterIndex >= 0; characterIndex--)
            {
                sb.Append(word[characterIndex]);
            }

            return sb.ToString();
        }


        private static List<string> ReverseOrder(List<string> words)
        {
            List<string> reversedWords = new List<string>();

            for (int wordIndex = words.Count - 1; wordIndex >= 0; wordIndex--)
            {
                reversedWords.Add(words[wordIndex]);
            }

            return reversedWords;
        }

        private static List<string> CapitalizeWords(List<string> words)
        {
            List<string> capitallizeWords = new List<string>();

            foreach (var word in words)
            {
                if (word.Length == 0)
                    continue;;
                if (word.Length == 1)
                    capitallizeWords.Add(
                        word[0].ToString().ToUpper());
                else
                    capitallizeWords.Add(
                        word[0].ToString().ToUpper()
                        + word.Substring(1));
            }

            return capitallizeWords;
        }

        public static void TestAll()
        {
            string sentence = "this is a test sentence";

            List<string> words;
            
            words = WordProcesssor.GetWords(sentence);
            Console.WriteLine("Original sentence");
            
            foreach (var word in words)
            {
                Console.Write(word);
                Console.Write(' ');
            }
            Console.WriteLine("\n");

            Console.WriteLine("CapitalizeWords sentence");
            words = WordProcesssor.GetWords(sentence, capitalizeWords : true);

            foreach (var word in words)
            {
                Console.Write(word);
                Console.Write(' ');
            }
            Console.WriteLine("\n");

            Console.WriteLine("ReverseOrder sentence");
            words = WordProcesssor.GetWords(sentence, reverseOrder: true);

            foreach (var word in words)
            {
                Console.Write(word);
                Console.Write(' ');
            }
            Console.WriteLine("\n");

            Console.WriteLine("ReverseWords sentence");
            words = WordProcesssor.GetWords(sentence, reverseWords: true);

            foreach (var word in words)
            {
                Console.Write(word);
                Console.Write(' ');
            }
            Console.WriteLine("\n");
        }
    }
}
