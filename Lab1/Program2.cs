//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;
//using static System.Math;

//namespace Lab1
//{
//    class Program
//    {
//        public static double Solve1(double b, double d, double x)
//        {
//            return Sqrt(d - 125) / 10 * x * Exp(125 / Sqrt(Pow(b, 2) + 25 * b - 150));
//        }
//        static double[] Solve2(int n, double b, double d, double x1, double x2)
//        {
//            double step, x = x1;
//            double[] array = new double[n];

//            step = (x2 - x1 + 1) / n;

//            for (int i = 0; i < n; i++)
//            {
//                try
//                {
//                    array[i] = Solve1(b, d, x);
//                    x += step;
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine(ex.Message);
//                }
//            }
//            return array;
//        }
//        static void Write(double[] array, int n)
//        {
//            string[] lines = new string[n];
//            for (int i = 0; i < n; i++)
//            {
//                lines[i] = array[i].ToString();
//            }

//            File.WriteAllLines("output.txt", lines);
//        }
//        static void Main(string[] args)
//        {
//            int n, x1, x2, b, d;

//            Console.WriteLine("Введите значение n: ");
//            n = Convert.ToInt32(Console.ReadLine());
//            Console.WriteLine("Введите значение x1: ");
//            x1 = Convert.ToInt32(Console.ReadLine());
//            Console.WriteLine("Введите значение x2: ");
//            x2 = Convert.ToInt32(Console.ReadLine());
//            Console.WriteLine("Введите значение b: ");
//            b = Convert.ToInt32(Console.ReadLine());
//            Console.WriteLine("Введите значение d: ");
//            d = Convert.ToInt32(Console.ReadLine());

//            //double[] arr = new double[n];

//            if ((d >= 125) && ((b > 5) || (b < -35)))
//            {
//                //Solve2(n, b, d, x1, x2);
//                Write(Solve2(n, b, d, x1, x2), n);
//            }
//            else
//            {
//                Console.WriteLine("Не соответствует области определения функции");
//            }
//            Console.ReadKey();
//        }
//    }
//}
