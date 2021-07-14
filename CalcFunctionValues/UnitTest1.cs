using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testing_and_Verification_2;
using System.Collections.Generic;

namespace CalcFunctionValues
{
    [TestClass]
    public class UnitTest1
    {
        // Черный ящик
        // Правильные тесты
        // Классы эквивалентности
        [TestMethod]
        public void TestMethod1()
        {
            double a = -9;
            double b = 5;
            int n = 2;
            double x1 = 0;
            double x2 = 1;
            var result = Program.CalcFunctionValues(a, b, n, x1, x2);

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = Math.Round(result[i], 4);
            }

            var expected = new List<double> {2.7437, 3.7911};
            CollectionAssert.AreEqual(expected, result);
        }

        // Граничные значения
        [TestMethod]
        public void TestMethod2()
        {
            double a = -9.9999;
            double b = -1.0001;
            int n = 2;
            double x1 = 0.9999;
            double x2 = 1.0000;
            var result = Program.CalcFunctionValues(a, b, n, x1, x2);

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = Math.Round(result[i], 4);
            }

            var expected = new List<double> { 478.6588, 478.6483 };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            double a = -9.9999;
            double b = 3.9999;
            int n = 2;
            double x1 = 0.9999;
            double x2 = 1;
            var result = Program.CalcFunctionValues(a, b, n, x1, x2);

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = Math.Round(result[i], 4);
            }

            var expected = new List<double> { -478.6779, -478.6675 };
            CollectionAssert.AreEqual(expected, result);
        }

        // Неправильные тесты
        // Классы эквивалентности
        [TestMethod]
        public void TestMethod4()
        {
            double a = -11;
            double b = 5;
            int n = 2;
            double x1 = 0;
            double x2 = 1;
            var result = Program.CalcFunctionValues(a, b, n, x1, x2);

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = Math.Round(result[i], 4);
            }

            var expected = new List<double> { double.NaN, double.NaN };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod5()
        {
            double a = -9;
            double b = -1;
            int n = 2;
            double x1 = 0;
            double x2 = 1;
            var result = Program.CalcFunctionValues(a, b, n, x1, x2);

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = Math.Round(result[i], 4);
            }

            var expected = new List<double> { double.PositiveInfinity, double.PositiveInfinity };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod6()
        {
            double a = -9;
            double b = 4;
            int n = 2;
            double x1 = 0;
            double x2 = 1;
            var result = Program.CalcFunctionValues(a, b, n, x1, x2);

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = Math.Round(result[i], 4);
            }

            var expected = new List<double> { double.PositiveInfinity, double.PositiveInfinity };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestMethod7()
        {
            double a = -9;
            double b = 5;
            int n = 2;
            double x1 = 1;
            double x2 = 0;
            var result = Program.CalcFunctionValues(a, b, n, x1, x2);
        }

        // Граничные значения
        [TestMethod]
        public void TestMethod8()
        {
            double a = -10.0001;
            double b = -1.0001;
            int n = 2;
            double x1 = 0.9999;
            double x2 = 1;
            var result = Program.CalcFunctionValues(a, b, n, x1, x2);

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = Math.Round(result[i], 4);
            }

            var expected = new List<double> { double.NaN, double.NaN };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod9()
        {
            double a = -9;
            double b = -1;
            int n = 2;
            double x1 = 0.9999;
            double x2 = 1;
            var result = Program.CalcFunctionValues(a, b, n, x1, x2);

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = Math.Round(result[i], 4);
            }

            var expected = new List<double> { double.PositiveInfinity, double.PositiveInfinity };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod10()
        {
            double a = -9;
            double b = 4;
            int n = 2;
            double x1 = 0.9999;
            double x2 = 1;
            var result = Program.CalcFunctionValues(a, b, n, x1, x2);

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = Math.Round(result[i], 4);
            }

            var expected = new List<double> { double.PositiveInfinity, double.PositiveInfinity };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestMethod11()
        {
            double a = -9;
            double b = -1.0001;
            int n = 2;
            double x1 = 1.0001;
            double x2 = 1;
            var result = Program.CalcFunctionValues(a, b, n, x1, x2);
        }

        // Белый ящик
        [TestMethod]
        public void TestMethod12()
        {
            double a = -9;
            double b = 5;
            int n = 2;
            double x1 = 0;
            double x2 = 1;
            var result = Program.CalcFunctionValues(a, b, n, x1, x2);

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = Math.Round(result[i], 4);
            }

            var expected = new List<double> { 2.7437, 3.7911 };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestMethod13()
        {
            double a = -9;
            double b = 5;
            int n = 2;
            double x1 = 1;
            double x2 = 0;
            var result = Program.CalcFunctionValues(a, b, n, x1, x2);
        }

        [TestMethod]
        public void TestMethod14()
        {
            double a = -9;
            double b = 5;
            int n = 2;
            double x1 = 0;
            double x2 = 1;
            var result = Program.CalcFunctionValues(a, b, n, x1, x2);

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = Math.Round(result[i], 4);
            }

            var expected = new List<double> { 2.7437, 3.7911 };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod15()
        {
            double a = -9;
            double b = 5;
            int n = 0;
            double x1 = 0;
            double x2 = 1;
            var result = Program.CalcFunctionValues(a, b, n, x1, x2);
            var expected = new List<double> { };
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
