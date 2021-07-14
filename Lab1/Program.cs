using System;
using System.Collections.Generic;

namespace Testing_and_Verification_2
{
    public class Program
    {
        // ============================= Функции лабораторной 2 =============================
        // 1 Вычисление значения функции
        public static double CalcFunction(double x, double a, double b)
        {
            return Math.Sqrt(a * a * a + 1000) / (b * b - 3 * b - 4) * (Math.Sin(x) + Math.Cos(x));
        }
        // 2 Вычисление в массив значений функций от х1 до х2
        public static List<double> CalcFunctionValues(double a, double b, int n, double x1, double x2)
        {
            if (x1 > x2) throw new Exception("x1 должен быть строго больше x2!");
            List<double> functionVals = new List<double>();
            double step = (x2 - x1) / (n - 1);
            double x = x1;
            for (double i = 0; i < n; i++)
            {
                functionVals.Add(CalcFunction(x, a, b));
                x += step;
            }
            return functionVals;
        }
        // 3 Сохранение заданного массива в заданный файл
        public static void WriteToFile(List<double> valsList)
        {
            if (valsList.Count <= 0) throw new Exception("valsList.Count должен быть строго больше 0!");
            List<string> output = new List<string>();

            valsList.ForEach(value =>
            {
                output.Add(value.ToString());
            });

            System.IO.File.WriteAllLines(@".\out.txt", output.ToArray());
        }

        // ==================================================================================
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            double a, b, x1, x2; int n;
            // Ввод данных

            try
            {
                Console.Write("Введите коэффициент a: ");
                a = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите коэффициент b: ");
                b = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите число итераций n: ");
                n = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите начальное значение аргумента x1: ");
                x1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите конечное значение аргумента x2: ");
                x2 = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка в вводе! a, b, x1 и x2 должны быть вещественными числами, а n - целым!\n");
                return;
            }

            // Тестовые значения по условию задачи
            //x1 = 8; x2 = 81; n = 39;

            // Проверка входных данных
            if ((x2 <= x1) || (n <= 0))
            {
                Console.WriteLine("x1 должен быть строго больше x2, а n больше нуля!");
                Environment.Exit(0);
            }
            if ((b == -1) || (b == 4) || (a < -10))
            {
                Console.WriteLine("Значения a или b не лежат в области доступных значений!");
                Environment.Exit(0);
            }

            // Вычисление массива значений функций от x1 до x2
            List<double> funcVals = CalcFunctionValues(a, b, n, x1, x2);
            // Вывод в файл
            WriteToFile(funcVals);
        }
    }
}
