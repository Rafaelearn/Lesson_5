using System;
using System.Collections.Generic;
using System.Drawing;

namespace Classwork
{
    class Classwork
    {
        static void Main(string[] args)
        {
            DoTask1();
            DoTask2();
            DoTask3();
            DoTask4();
            DoTask5();
            Console.ReadKey();
        }
        static void DoTask1()
        {
            byte[] arrayBavarian, arrayScandin;
            Console.Write("Введите количество цифр команды  Bavarian Beer Bears: ");
            if (!uint.TryParse(Console.ReadLine(), out uint nArray) || nArray == 0)
            {
                throw new FormatException("Task1. wrong format nArray of  Bavarian Beer Bears");
            }
            arrayBavarian = new byte[nArray];
            for (int i = 0; i < arrayBavarian.Length; i++)
            {
                Console.Write($"{i} цифра команды  Bavarian Beer Bears: ");
                if (!byte.TryParse(Console.ReadLine(), out arrayBavarian[i]) || arrayBavarian[i] == 0 || arrayBavarian[i] > 9)
                {
                    Console.WriteLine("Рефери, Бьорг, объявляет, что это не цифра и \"вежливо\" просит переходить!");
                    i--;
                }
            }
            Console.Write("Введите количество цифр команды  Scandinavian Schöllers: ");
            if (!uint.TryParse(Console.ReadLine(), out  nArray) || nArray == 0)
            {
                throw new FormatException("Task1. wrong format nArray of  Scandinavian Schöllers");
            }
            arrayScandin = new byte[nArray];
            for (int i = 0; i < arrayScandin.Length; i++)
            {
                Console.Write($"{i} цифра команды Scandinavian Schöllers: ");
                if (!byte.TryParse(Console.ReadLine(), out arrayScandin[i]) || arrayScandin[i] == 0 || arrayScandin[i] > 9)
                {
                    Console.WriteLine("Рефери, Бьорг, объявляет, что это не цифра и \"вежливо\" просит переходить!");
                    i--;
                }
            }
            Console.Write(GetResultOfGameVikings(arrayBavarian, arrayScandin));
        }
        static void DoTask2()
        {

        }
        static void DoTask3()
        {

        }
        static void DoTask4()
        {

        }
        static void DoTask5()
        {

        }
        static string GetResultOfGameVikings(byte[] a, byte[] b)
        {
            uint count5InA = 0, count5InB = 0;
            foreach (var item in a)
            {
                if (item == 5)
                {
                    count5InA ++;
                }
            }
            foreach (var item in b)
            {
                if (item == 5)
                {
                    count5InB++;
                }
            }
            if (count5InA == count5InB)
            {
                return "Drinks All Round! Free Beers on Bjorg!\n";
            }
            else
            {
                Console.WriteLine("Ой, Бьорг - пончик! Ни для кого пива!");
                return "";
            }
        } 
    }
}
