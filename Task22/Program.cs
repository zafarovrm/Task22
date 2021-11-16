using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task22
{
    class Program
    {
        static int[] Array(int n)
        {
            int[] mas = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                mas[i] = rnd.Next(0, 101);
                Console.Write(mas[i] + " ");
            }
            return mas;
        }
        static int SumArray(int[] mas)
        {
            //int n = mas.Length;
            //Console.WriteLine("Метод SumArray начал работу");
            //int sum = 0;
            //for (int i = 0; i < n; i++)
            //{
            //    sum += mas[i];
            //    Console.WriteLine(sum);
            //    Thread.Sleep(1000);
            //}
            //Console.WriteLine("Метод SumArray закончил работу");
            //return sum;
            return mas.Sum();
        }
        static int MaxArray(int[] mas)
        {
            //int n = mas.Length;
            //Console.WriteLine("Метод MaxArray начал работу");
            //int maxInt = mas[0];
            //for (int i = 0; i < n; i++)
            //{
            //    if (mas[i] > maxInt)
            //        maxInt = mas[i];
            //    Thread.Sleep(1000);
            //}
            //Console.WriteLine("Метод MaxArray закончил работу");
            //return maxInt;
            return mas.Max();
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива");
            int n = Convert.ToInt32(Console.ReadLine());

            Task<int[]> task1 = new Task<int[]>(() => Array(n));

            Task<int> task2 = task1.ContinueWith((mas) => SumArray(mas.Result));

            Task<int> task3 = task1.ContinueWith((mas) => MaxArray(mas.Result));

            task1.Start();

            Task.WaitAll(task2, task3);
            Console.WriteLine();
            Console.WriteLine("Сумма значений массива: {0}", task2.Result);
            Console.WriteLine("Макс значение в массиве: {0}", task3.Result);

            Console.ReadKey();
        }
    }
}