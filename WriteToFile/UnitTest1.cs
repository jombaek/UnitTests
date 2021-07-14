using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testing_and_Verification_2;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace WriteToFile
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
            var valsList = new List<double> { 0 };
            Program.WriteToFile(valsList);
            string[] expected = { "0" };
            string[] result = File.ReadAllLines("out.txt").ToArray();
            CollectionAssert.AreEqual(expected, result);
        }

        // Граничные значения
        public void TestMethod2()
        {
            var valsList = new List<double> { 0 };
            Program.WriteToFile(valsList);
            string[] expected = { "0" };
            string[] result = File.ReadAllLines("out.txt").ToArray();
            CollectionAssert.AreEqual(expected, result);
        }

        // Неравильные тесты
        // Классы эквивалентности
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestMethod3()
        {
            var valsList = new List<double> { };
            Program.WriteToFile(valsList);
        }

        // Граничные значения
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestMethod4()
        {
            var valsList = new List<double> { };
            Program.WriteToFile(valsList);
        }

        // Белый ящик
        [TestMethod]
        public void TestMethod5()
        {
            var valsList = new List<double> { 0 };
            Program.WriteToFile(valsList);
            string[] expected = { "0" };
            string[] result = File.ReadAllLines("out.txt").ToArray();
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestMethod6()
        {
            var valsList = new List<double> { };
            Program.WriteToFile(valsList);
        }
    }
}
