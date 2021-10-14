using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;

namespace Classwork
{
    class Classwork
    {
        private const double WIDTH = 1.5;
        private const string PathToListStudent = @"..\..\files\ListStudents.txt";

        struct Student
        {
            public string name;
            public string lastName;
            public string subjectBase;
            public ushort yearOFBirth;
            public ushort scores;
        }

        static void Main(string[] args)
        {
            //DoTask1();
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
            List<Student> studentsList = new List<Student>();
            using (StreamReader fileTextRead = new StreamReader(PathToListStudent, System.Text.Encoding.Default))
            {
                string stringfromfile;
                int numberString = 1;
                while ((stringfromfile = fileTextRead.ReadLine()) != null)
                {
                    string[] dateStudent = stringfromfile.Split();
                    if (dateStudent.Length != 5)
                    {
                        Console.WriteLine($"Длина {numberString} строки не соответсвует формату");
                    }
                    else
                    {
                        Student studentNew;
                        studentNew.lastName = dateStudent[0];
                        studentNew.name = dateStudent[1];
                        if (!ushort.TryParse(dateStudent[2], out studentNew.yearOFBirth))
                        {
                            throw new FormatException($"fileListStudents. Wrong format the year of Birth. String {numberString}");
                        }

                        studentNew.subjectBase = dateStudent[3];
                        if (!ushort.TryParse(dateStudent[4], out studentNew.scores) || studentNew.scores > 310)
                        {
                            throw new FormatException($"fileListStudents. Wrong format of scorces. String {numberString}");
                        }
                        studentsList.Add(studentNew);
                    }
                    numberString++;
                }
            }
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1.Добавить нового студента\n2.Удалить студента по имени и фамилии\n3. Сортировать по баллам" +
                "\nДругой: Закончить программу");
                Console.Write("Выберите действие. Нажми цифру: ");
                ConsoleKey choise = Console.ReadKey().Key;
                Console.WriteLine();
                switch (choise)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Student studentNew;
                        Console.Write("Введите фамилию студента: ");
                        studentNew.lastName = Console.ReadLine();
                        Console.Write("Введите имя студента: ");
                        studentNew.name = Console.ReadLine();
                        Console.Write("Введите год рождения студента: ");
                        if (!ushort.TryParse(Console.ReadLine(), out studentNew.yearOFBirth))
                        {
                            Console.WriteLine("Wrong format the year of Birth. New student of user");
                            break;
                        }
                        Console.Write("Введите основной предмет студента: ");
                        studentNew.subjectBase = Console.ReadLine();
                        Console.Write("Введите количество баллов студента: ");
                        if (!ushort.TryParse(Console.ReadLine(), out studentNew.scores) || studentNew.scores > 310)
                        {
                            Console.WriteLine("Wrong format of scores. New student of user");
                            break;
                        }
                        studentsList.Add(studentNew);
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.Write("Введите фамилию студента: ");
                        string lastNameRemofe = Console.ReadLine();
                        Console.Write("Введите имя студента: ");
                        string nameRemofe = Console.ReadLine();
                        foreach (Student student in studentsList)
                        {
                            if (student.name.Equals(nameRemofe) && student.lastName.Equals(lastNameRemofe))
                            {
                               studentsList.Remove(student); 
                            }
                            else
                            {
                                Console.WriteLine("Такого студента не сущетсвует");
                            }
                        }
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        QuickSortListStruct(studentsList);
                        break;
                    default:
                        flag = false;
                        break;
                }
            }
            
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
        static void PrintImage(Bitmap bitmap)
        {

        }
        static Bitmap ResizeBitmap(Bitmap bitmap)
        {
            int maxWidth = 100;
            double newHeight = bitmap.Height / WIDTH * maxWidth / bitmap.Width;
            if (bitmap.Width > maxWidth || bitmap.Height > newHeight)
            {
                bitmap = new Bitmap(bitmap, new Size(maxWidth, (int)newHeight));
            }
            return bitmap;
        }
        static void Swap(ref Student x, ref Student y)
        {
            var t = x;
            x = y;
            y = t;
        }
        static List<Student> QuickSortListStruct(List<Student> list, int left, int right)
        {
            Student a, b;
            if (left >= right)
            {
                return list;
            }
            var fundation = left - 1;
            for (var i = left; i < right; i++)
            {
                if (list[i].scores < list[right].scores)
                {
                    fundation++;
                    a = list[fundation];
                    b = list[i];
                    Swap(ref a, ref b);
                }
            }

            fundation++;
            a = list[fundation];
            b = list[right];
            Swap(ref a, ref b);
            QuickSortListStruct(list, left, fundation - 1);
            QuickSortListStruct(list, fundation + 1, right);

            return list;
        }
        static List<Student> QuickSortListStruct(List<Student> list)
        {
            int left = 0, right = list.Count() - 1;
            Student a, b;
            if (left >= right)
            {
                return list;
            }
            var fundation = left - 1;
            for (var i = left; i < right; i++)
            {
                if (list[i].scores < list[right].scores)
                {
                    fundation++;
                    a = list[fundation];
                    b = list[i];
                    Swap(ref a, ref b);
                }
            }

            fundation++;
            a = list[fundation];
            b = list[right];
            Swap(ref a, ref b);
            QuickSortListStruct(list, left, fundation - 1);
            QuickSortListStruct(list, fundation + 1, right);

            return list;
        }

    }
}
