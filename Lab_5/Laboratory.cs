using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Lab_5
{
    class Program
    {
        static Random random = new Random();
        static FileInfo fileText = new FileInfo(@"..\..\files\Text.txt");
        static void Main(string[] args)
        {
            DoClasswork();
            DoHomework();
            Console.ReadKey();
        }
        static void DoClasswork() 
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
            double[,] matrix1, matrix2;
            Console.Write("1.2 рандомных матрицы, для которых операция произведения существует\n" +
                "2.Я сам заполню матрицы\nНажми цифру, которая тебе подходит: ");
            ConsoleKey consoleKey = Console.ReadKey().Key;
            Console.WriteLine();
            switch (consoleKey)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    int indEqlRnd = random.Next(3, 10);
                    matrix1 = new double[random.Next(2, 10), indEqlRnd];
                    matrix2 = new double[indEqlRnd, random.Next(2, 10)];
                    for (int i = 0; i < matrix1.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix1.GetLength(1); j++)
                        {
                            matrix1[i, j] = random.Next(5000) / 100.0;
                        }
                    }
                    for (int i = 0; i < matrix2.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix2.GetLength(1); j++)
                        {
                            matrix2[i, j] = random.Next(5000) / 100.0;
                        }
                    }
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    uint[] rowcol = new uint[2];
                    Console.Write("Введите для 1-ой матрицы количество строк и столбцов: ");
                    for (int i = 0; i < rowcol.Length; i++)
                    {
                        Console.WriteLine($"ColRow[{i}] = ");
                        if (!uint.TryParse(Console.ReadLine(), out rowcol[i]))
                        {
                            throw new FormatException("Wrong format for columns or row 1 matrix");
                        }
                    }
                    matrix1 = new double[rowcol[0], rowcol[1]];
                    for (int i = 0; i < matrix1.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix1.GetLength(1); j++)
                        {
                            Console.WriteLine($"M1[{i+1}][{j+1}] = ");
                            if (!double.TryParse(Console.ReadLine(), out matrix1[i, j]))
                            {
                                throw new FormatException("Wrong format input for element of 1 matrix");
                            }
                        }
                    }

                    Console.Write("Введите для 2-ой матрицы количество строк и столбцов: ");
                    for (int i = 0; i < rowcol.Length; i++)
                    {
                        Console.WriteLine($"ColRow[{i}] = ");
                        if (!uint.TryParse(Console.ReadLine(), out rowcol[i]))
                        {
                            throw new FormatException("Wrong format for columns or row 2 matrix");
                        }
                    }
                    matrix2 = new double[rowcol[0], rowcol[1]];
                    for (int i = 0; i < matrix2.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix2.GetLength(1); j++)
                        {
                            Console.WriteLine($"M2[{i + 1}][{j + 1}] = ");
                            if (!double.TryParse(Console.ReadLine(), out matrix2[i, j]))
                            {
                                throw new FormatException("Wrong format input for element of 2 matrix");
                            }
                        }
                    }
                    break;
                default:
                    throw new FormatException("There is no such choice");
            }
            Console.WriteLine("1-ая матрица: ");
            Print2DMatrix(matrix1);
            Console.WriteLine("2-ая матрица: ");
            Print2DMatrix(matrix2);
            Console.WriteLine("Результат умножения матриц: ");
            Print2DMatrix(MultiplyMatrix(matrix1, matrix2));

            Console.WriteLine("\nExercise 6.3");
            double[,] temperature = new double[12, 30];
            for (int i = 0; i < temperature.GetLength(0); i++)
            {
                for (int j = 0; j < temperature.GetLength(1); j++)
                {
                    temperature[i, j] = random.Next(600) / 10.0 - 30;
                }
            }
            double[] tAverage = GetArrayOFAverageTemperature(temperature);
            Array.Sort(tAverage);

        }
        static void DoHomework()
        {
            Console.WriteLine("Home Exercise 6.1");
            using (StreamReader fileTextRead = fileText.OpenText())
            {
                List<char> listCharFile = new List<char>();
                CountLetter(listCharFile, out uint countvolews, out uint countconsonants);
                Console.WriteLine($"Volews in the text {countvolews}");
                Console.WriteLine($"Consonants in the text {countconsonants}");
            }

            Console.WriteLine("Home Exercise 6.2");
        }
        static void CountLetter(char[] arrayChar, out uint volews, out uint consonants)
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
        static void CountLetter(List<char> arrayChar, out uint volews, out uint consonants)
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
        static double[,] MultiplyMatrix( double[,] m1, double[,] m2)
        {
            if (m1.GetLength(1) != m2.GetLength(0))
            {
                throw new FormatException("Wrong input for method MultiplyMatrix");
            }
            double[,] result = new double[m2.GetLength(1), m1.GetLength(0)];
            for (int i = 0; i < m2.GetLength(1); i++)
            {
                for (int j = 0; j < m1.GetLength(0); j++)
                {
                    for (int k = 0; k < m1.GetLength(1); k++)
                    {
                        result[i, j] += m1[j, k] * m2[k, i];
                    }
                }
            }
            return result;
        }
        static void Print2DMatrix(double[,] m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    Console.Write(m[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
        static double[] GetArrayOFAverageTemperature(double[,] temperature)
        {
            double[] temperatureAverage = new double[temperature.GetLength(0)];
            for (int i = 0; i < temperature.GetLength(0); i++)
            {
                for (int j = 0; j < temperature.GetLength(1); j++)
                {
                    temperatureAverage[i] += temperature[i, j];
                }
                temperatureAverage[i] /= 12;
            }
            return temperatureAverage;
        }
    }
}
