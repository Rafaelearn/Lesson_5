using System;
using System.IO;

namespace Lab_5
{
    class Program
    {
        static FileInfo fileText = new FileInfo(@"..\..\files\Text.txt");
        static void Main(string[] args)
        {
            Console.WriteLine("Exercise 6.1");
            using (StreamReader fileTextRead = fileText.OpenText())
            {
                char[] arrayOfCharFromFile = fileTextRead.ReadToEnd().ToLower().ToCharArray();
                CountLetter(arrayOfCharFromFile, out uint countvolews, out uint countconsonants);
                Console.WriteLine($"Volews in the text {countvolews}");
                Console.WriteLine($"Consonants in the text {countconsonants}");
            }


            Console.WriteLine("\nExercise 6.2");

            Console.ReadKey();
        }
        static void CountLetter (char[] arrayChar, out uint volews, out uint consonants)
        {
            volews = 0;
            consonants = 0;
            char[] volewsChar = "aeiouy".ToCharArray();
            char[] consantsChar = "bcdfghjklmnpqrstvwxyz".ToCharArray();
            foreach (var item in arrayChar)
            {
                if (Array.IndexOf(volewsChar, item) != -1)
                {
                    volews++;
                }
                if (Array.IndexOf(consantsChar, item) != -1)
                {
                    consonants++;
                }
            }
        }
    }
}
