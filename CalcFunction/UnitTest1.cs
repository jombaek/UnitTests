using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testing_and_Verification_2;

namespace CalcFunction
{
    [TestClass]
    public class UnitTest1
    {
        // Правильные тесты
        // Классы эквивалентности
        [TestMethod]
        public void TestMethod1()
        {
            double x = 1;
            double a = -9;
            double b = 5;
            double result = Program.CalcFunction(x, a, b);
            Assert.AreEqual(3.7911, Math.Round(result, 4), 0.0001);
        }

        // Граничные значения
        [TestMethod]
        public void TestMethod2()
        {
            double x = 1;
            double a = -9.9999;
            double b = -1.0001;
            double result = Program.CalcFunction(x, a, b);
            Assert.AreEqual(478.6483, Math.Round(result, 4), 0.0001);
        }

        [TestMethod]
        public void TestMethod3()
        {
            double x = 1;
            double a = -9.9999;
            double b = 3.9999;
            double result = Program.CalcFunction(x, a, b);
            Assert.AreEqual(-478.6675, Math.Round(result, 4), 0.0001);
        }

        // Неправильные тесты
        // Классы эквивалентности
        [TestMethod]
        public void TestMethod4()
        {
            double x = 1;
            double a = -11;
            double b = 5;
            double result = Program.CalcFunction(x, a, b);
            Assert.AreEqual(double.NaN, result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void TestMethod5()
        {
            double x = 1;
            double a = -9;
            double b = -1;
            double result = Program.CalcFunction(x, a, b);
            if (result == double.PositiveInfinity) throw new DivideByZeroException("Деление на 0!");
        }

        [TestMethod]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void TestMethod6()
        {
            double x = 1;
            double a = -9;
            double b = 4;
            double result = Program.CalcFunction(x, a, b);
            if (result == double.PositiveInfinity) throw new DivideByZeroException("Деление на 0!");
        }

        // Граничные значения
        [TestMethod]
        public void TestMethod7()
        {
            double x = 1;
            double a = -10.0001;
            double b = -1.0001;
            double result = Program.CalcFunction(x, a, b);
            Assert.AreEqual(double.NaN, result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void TestMethod8()
        {
            double x = 1;
            double a = -9.9999;
            double b = -1;
            double result = Program.CalcFunction(x, a, b);
            if (result == double.PositiveInfinity) throw new DivideByZeroException("Деление на 0!");
        }

        [TestMethod]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void TestMethod9()
        {
            double x = 1;
            double a = -9.9999;
            double b = 4;
            double result = Program.CalcFunction(x, a, b);
            if (result == double.PositiveInfinity) throw new DivideByZeroException("Деление на 0!");
        }
    }
}
