using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Main
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
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();

            p.StandardInput.WriteLine("-9"); // a
            p.StandardInput.WriteLine("5"); // b
            p.StandardInput.WriteLine("2"); // n
            p.StandardInput.WriteLine("0"); // x1
            p.StandardInput.WriteLine("1"); // x2

            var result = File.ReadAllLines("out.txt");
            var first = Math.Round(Convert.ToDouble(result[0]), 4).ToString();
            var second = Math.Round(Convert.ToDouble(result[1]), 4).ToString();
            p.Close();
            Assert.AreEqual("2,7437, 3,7911", first + ", " + second);
        }

        // Граничные значения
        [TestMethod]
        public void TestMethod2()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();

            p.StandardInput.WriteLine("-9,9999"); // a
            p.StandardInput.WriteLine("-1,0001"); // b
            p.StandardInput.WriteLine("1"); // n
            p.StandardInput.WriteLine("0,9999"); // x1
            p.StandardInput.WriteLine("1"); // x2

            var result = File.ReadAllLines("out.txt");
            var first = Math.Round(Convert.ToDouble(result[0]), 4).ToString();
            p.Close();
            Assert.AreEqual("478,6588", first);                
        }

        [TestMethod]
        public void TestMethod3()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();

            p.StandardInput.WriteLine("-9,9999"); // a
            p.StandardInput.WriteLine("3,9999"); // b
            p.StandardInput.WriteLine("1"); // n
            p.StandardInput.WriteLine("0,9999"); // x1
            p.StandardInput.WriteLine("1"); // x2

            var result = File.ReadAllLines("out.txt");
            var first = Math.Round(Convert.ToDouble(result[0]), 4).ToString();
            p.Close();
            Assert.AreEqual("-478,6779", first);
        }

        [TestMethod]
        public void TestMethod4()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();

            p.StandardInput.WriteLine("-9,9999"); // a
            p.StandardInput.WriteLine("3,9999"); // b
            p.StandardInput.WriteLine("2"); // n
            p.StandardInput.WriteLine("0,7853975"); // x1
            p.StandardInput.WriteLine("3,9269875"); // x2

            var result = File.ReadAllLines("out.txt");
            var first = Math.Round(Convert.ToDouble(result[0]), 4).ToString();
            var second = Math.Round(Convert.ToDouble(result[1]), 4).ToString();
            p.Close();
            Assert.AreEqual("-489,9053, 489,9053", first + ", " + second);
        }

        // Неправильные тесты
        // Классы эквивалентности
        [TestMethod]
        public void TestMethod5()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("-9"); // a
            p.StandardInput.WriteLine("5"); // b
            p.StandardInput.WriteLine("0"); // n
            p.StandardInput.WriteLine("0"); // x1
            p.StandardInput.WriteLine("1"); // x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            Assert.AreEqual("x1 должен быть строго больше x2, а n больше нуля!", result);
            p.Close();
        }

        [TestMethod]
        public void TestMethod6()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("-9"); // a
            p.StandardInput.WriteLine("5"); // b
            p.StandardInput.WriteLine("2"); // n
            p.StandardInput.WriteLine("1"); // x1
            p.StandardInput.WriteLine("0"); // x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            Assert.AreEqual("x1 должен быть строго больше x2, а n больше нуля!", result);
            p.Close();
        }

        [TestMethod]
        public void TestMethod7()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("-11"); // a
            p.StandardInput.WriteLine("5"); // b
            p.StandardInput.WriteLine("2"); // n
            p.StandardInput.WriteLine("0"); // x1
            p.StandardInput.WriteLine("1"); // x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            Assert.AreEqual("Значения a или b не лежат в области доступных значений!", result);
            p.Close();
        }

        [TestMethod]
        public void TestMethod8()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("-9"); // a
            p.StandardInput.WriteLine("-1"); // b
            p.StandardInput.WriteLine("2"); // n
            p.StandardInput.WriteLine("0"); // x1
            p.StandardInput.WriteLine("1"); // x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            Assert.AreEqual("Значения a или b не лежат в области доступных значений!", result);
            p.Close();
        }

        [TestMethod]
        public void TestMethod9()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("-9"); // a
            p.StandardInput.WriteLine("4"); // b
            p.StandardInput.WriteLine("2"); // n
            p.StandardInput.WriteLine("0"); // x1
            p.StandardInput.WriteLine("1"); // x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            Assert.AreEqual("Значения a или b не лежат в области доступных значений!", result);
            p.Close();
        }

        // Граничные значения
        [TestMethod]
        public void TestMethod10()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("-9"); // a
            p.StandardInput.WriteLine("5"); // b
            p.StandardInput.WriteLine("0"); // n
            p.StandardInput.WriteLine("0"); // x1
            p.StandardInput.WriteLine("1"); // x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            Assert.AreEqual("x1 должен быть строго больше x2, а n больше нуля!", result);
            p.Close();
        }

        [TestMethod]
        public void TestMethod11()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("-9"); // a
            p.StandardInput.WriteLine("5"); // b
            p.StandardInput.WriteLine("1"); // n
            p.StandardInput.WriteLine("1,0001"); // x1
            p.StandardInput.WriteLine("1"); // x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            Assert.AreEqual("x1 должен быть строго больше x2, а n больше нуля!", result);
            p.Close();
        }

        [TestMethod]
        public void TestMethod12()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("-10,0001"); // a
            p.StandardInput.WriteLine("5"); // b
            p.StandardInput.WriteLine("1"); // n
            p.StandardInput.WriteLine("0"); // x1
            p.StandardInput.WriteLine("1"); // x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            Assert.AreEqual("Значения a или b не лежат в области доступных значений!", result);
            p.Close();
        }

        [TestMethod]
        public void TestMethod13()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("-9"); // a
            p.StandardInput.WriteLine("-1"); // b
            p.StandardInput.WriteLine("1"); // n
            p.StandardInput.WriteLine("0"); // x1
            p.StandardInput.WriteLine("1"); // x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            Assert.AreEqual("Значения a или b не лежат в области доступных значений!", result);
            p.Close();
        }

        [TestMethod]
        public void TestMethod14()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("-9"); // a
            p.StandardInput.WriteLine("4"); // b
            p.StandardInput.WriteLine("1"); // n
            p.StandardInput.WriteLine("0"); // x1
            p.StandardInput.WriteLine("1"); // x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            Assert.AreEqual("Значения a или b не лежат в области доступных значений!", result);
            p.Close();
        }

        // Белый ящик
        // try catch
        [TestMethod]
        public void TestMethod15()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();

            p.StandardInput.WriteLine("-9"); // a
            p.StandardInput.WriteLine("5"); // b
            p.StandardInput.WriteLine("2"); // n
            p.StandardInput.WriteLine("0"); // x1
            p.StandardInput.WriteLine("1"); // x2

            var result = File.ReadAllLines("out.txt");
            var first = Math.Round(Convert.ToDouble(result[0]), 4).ToString();
            var second = Math.Round(Convert.ToDouble(result[1]), 4).ToString();
            p.Close();
            Assert.AreEqual("2,7437, 3,7911", first + ", " + second);
        }

        [TestMethod]
        public void TestMethod16()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("-9"); // a
            p.StandardInput.WriteLine("5"); // b
            p.StandardInput.WriteLine("2,5"); // n
            p.StandardInput.WriteLine("0"); // x1
            p.StandardInput.WriteLine("1"); // x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            Assert.AreEqual("Ошибка в вводе! a, b, x1 и x2 должны быть вещественными числами, а n - целым!", result);
            p.Close();
        }

        [TestMethod]
        public void TestMethod17()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("-9"); // a
            p.StandardInput.WriteLine("5"); // b
            p.StandardInput.WriteLine("2"); // n
            p.StandardInput.WriteLine("this is string"); // x1
            p.StandardInput.WriteLine("1"); // x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            Assert.AreEqual("Ошибка в вводе! a, b, x1 и x2 должны быть вещественными числами, а n - целым!", result);
            p.Close();
        }

        [TestMethod]
        public void TestMethod18()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("-9"); // a
            p.StandardInput.WriteLine("5"); // b
            p.StandardInput.WriteLine("2"); // n
            p.StandardInput.WriteLine("0"); // x1
            p.StandardInput.WriteLine("this is string"); // x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            Assert.AreEqual("Ошибка в вводе! a, b, x1 и x2 должны быть вещественными числами, а n - целым!", result);
            p.Close();
        }
        [TestMethod]
        public void TestMethod19()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("this is string"); // a
            p.StandardInput.WriteLine("5"); // b
            p.StandardInput.WriteLine("2"); // n
            p.StandardInput.WriteLine("0"); // x1
            p.StandardInput.WriteLine("1"); // x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            Assert.AreEqual("Ошибка в вводе! a, b, x1 и x2 должны быть вещественными числами, а n - целым!", result);
            p.Close();
        }

        [TestMethod]
        public void TestMethod20()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("-9"); // a
            p.StandardInput.WriteLine("this is string"); // b
            p.StandardInput.WriteLine("2"); // n
            p.StandardInput.WriteLine("0"); // x1
            p.StandardInput.WriteLine("1"); // x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            Assert.AreEqual("Ошибка в вводе! a, b, x1 и x2 должны быть вещественными числами, а n - целым!", result);
            p.Close();
        }

        // Проверка входных данных: x1, x2, n
        // ((x2 <= x1) || (n <= 0))
        [TestMethod]
        public void TestMethod21()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("-9"); // a
            p.StandardInput.WriteLine("5"); // b
            p.StandardInput.WriteLine("0"); // n
            p.StandardInput.WriteLine("1"); // x1
            p.StandardInput.WriteLine("0"); // x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            Assert.AreEqual("x1 должен быть строго больше x2, а n больше нуля!", result);
            p.Close();
        }

        [TestMethod]
        public void TestMethod22()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("-9"); // a
            p.StandardInput.WriteLine("5"); // b
            p.StandardInput.WriteLine("2"); // n
            p.StandardInput.WriteLine("1"); // x1
            p.StandardInput.WriteLine("0"); // x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            Assert.AreEqual("x1 должен быть строго больше x2, а n больше нуля!", result);
            p.Close();
        }

        [TestMethod]
        public void TestMethod23()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("-9"); // a
            p.StandardInput.WriteLine("5"); // b
            p.StandardInput.WriteLine("0"); // n
            p.StandardInput.WriteLine("0"); // x1
            p.StandardInput.WriteLine("1"); // x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            Assert.AreEqual("x1 должен быть строго больше x2, а n больше нуля!", result);
            p.Close();
        }

        [TestMethod]
        public void TestMethod24()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("-9"); // a
            p.StandardInput.WriteLine("5"); // b
            p.StandardInput.WriteLine("2"); // n
            p.StandardInput.WriteLine("0"); // x1
            p.StandardInput.WriteLine("1"); // x2

            var result = File.ReadAllLines("out.txt");
            var first = Math.Round(Convert.ToDouble(result[0]), 4).ToString();
            var second = Math.Round(Convert.ToDouble(result[1]), 4).ToString();
            p.Close();
            Assert.AreEqual("2,7437, 3,7911", first + ", " + second);
        }

        // Проверка входных данных: b, a
        // ((b == -1) || (b == 4) || (a< -10))
        [TestMethod]
        public void TestMethod25()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("-11"); // a
            p.StandardInput.WriteLine("-1"); // b
            p.StandardInput.WriteLine("2"); // n
            p.StandardInput.WriteLine("0"); // x1
            p.StandardInput.WriteLine("1"); // x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            Assert.AreEqual("Значения a или b не лежат в области доступных значений!", result);
            p.Close();
        }

        [TestMethod]
        public void TestMethod26()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("-11"); // a
            p.StandardInput.WriteLine("4"); // b
            p.StandardInput.WriteLine("2"); // n
            p.StandardInput.WriteLine("0"); // x1
            p.StandardInput.WriteLine("1"); // x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            Assert.AreEqual("Значения a или b не лежат в области доступных значений!", result);
            p.Close();
        }

        [TestMethod]
        public void TestMethod27()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("-11"); // a
            p.StandardInput.WriteLine("5"); // b
            p.StandardInput.WriteLine("2"); // n
            p.StandardInput.WriteLine("0"); // x1
            p.StandardInput.WriteLine("1"); // x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            Assert.AreEqual("Значения a или b не лежат в области доступных значений!", result);
            p.Close();
        }

        [TestMethod]
        public void TestMethod28()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("-9"); // a
            p.StandardInput.WriteLine("4"); // b
            p.StandardInput.WriteLine("2"); // n
            p.StandardInput.WriteLine("0"); // x1
            p.StandardInput.WriteLine("1"); // x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            Assert.AreEqual("Значения a или b не лежат в области доступных значений!", result);
            p.Close();
        }

        [TestMethod]
        public void TestMethod29()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("-9"); // a
            p.StandardInput.WriteLine("-1"); // b
            p.StandardInput.WriteLine("2"); // n
            p.StandardInput.WriteLine("0"); // x1
            p.StandardInput.WriteLine("1"); // x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            Assert.AreEqual("Значения a или b не лежат в области доступных значений!", result);
            p.Close();
        }

        [TestMethod]
        public void TestMethod30()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "Lab1.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("-9"); // a
            p.StandardInput.WriteLine("5"); // b
            p.StandardInput.WriteLine("2"); // n
            p.StandardInput.WriteLine("0"); // x1
            p.StandardInput.WriteLine("1"); // x2

            var result = File.ReadAllLines("out.txt");
            var first = Math.Round(Convert.ToDouble(result[0]), 4).ToString();
            var second = Math.Round(Convert.ToDouble(result[1]), 4).ToString();
            p.Close();
            Assert.AreEqual("2,7437, 3,7911", first + ", " + second);
        }
    }
}
