using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace TestAllProgram
{
    public class Comparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (Math.Abs((double)x - (double)y) < 0.000001)
            {
                return 0;
            }

            return -1;
        }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "AmanProject.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            //n
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //b
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(8);
            //c
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(21);
            //x1
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(1);
            //x2
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //путь до файла
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(Directory.GetCurrentDirectory() + @"\test.txt");

            Thread.Sleep(150);

            string[] line = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\test.txt");
            double[] array = new double[] { -0.025288336, -0.02952935, -0.000711245, -0.020455358, -0.032840563 };

            CollectionAssert.AreEqual(array, Array.ConvertAll(line, Double.Parse), new Comparer());
        }

        [TestMethod]
        public void TestMethod2()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "AmanProject.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();
            //n
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //b
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(8);
            //c
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(21);
            //x1
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(3);
            //x2
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(1);

            Assert.IsNotNull(p.StandardError.ReadLine());
            p.Kill();

        }

        [TestMethod]
        public void TestMethod3()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "AmanProject.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();
            //n
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //b
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(1);

            string stringWrong = p.StandardOutput.ReadLine();
            p.Kill();
            Assert.AreEqual("B != 12 or b != 1", stringWrong);
        }

        [TestMethod]
        public void TestMethod4()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "AmanProject.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();
            //n
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //b
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(12);

            string stringWrong = p.StandardOutput.ReadLine();
            p.Kill();
            Assert.AreEqual("B != 12 or b != 1", stringWrong);
        }

        [TestMethod]
        public void TestMethod5()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "AmanProject.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();
            //n
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //b
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(8);
            //c
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(19);

            string stringWrong = p.StandardOutput.ReadLine();
            p.Kill();
            Assert.AreEqual("C < 20", stringWrong);
        }

        [TestMethod]
        public void TestMethod6()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "AmanProject.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();
            //n
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //b
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(8);
            //c
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(19.999);

            string stringWrong = p.StandardOutput.ReadLine();
            p.Kill();
            Assert.AreEqual("C < 20", stringWrong);
        }

        [TestMethod]
        public void TestMethod7()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "AmanProject.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();
            //n
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(0);

            string stringWrong = p.StandardOutput.ReadLine();
            p.Kill();
            Assert.AreEqual("N не должен быть отрицательным, либо равным нулю", stringWrong);
        }

        [TestMethod]
        public void TestMethod8()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "AmanProject.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            //n
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //b
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(8);
            //c
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(20.001);
            //x1
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(1);
            //x2
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //путь до файла
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(Directory.GetCurrentDirectory() + @"\test.txt");

            Thread.Sleep(150);

            string[] line = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\test.txt");
            double[] array = new double[] { -0.00079968741155, -0.00093380005002, -0.0000225, -0.0006468552083, -0.00103850978783 };
            for (int i = 0; i < line.Length; i++)
            {
                Assert.AreEqual(array[i], Convert.ToDouble(line[i]), 0.0001);
            }
        }

        [TestMethod]
        public void TestMethod9()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "AmanProject.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            //n
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(1);
            //b
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(3);
            //c
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(21);
            //x
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(1.5707963267949);
            //путь до файла
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(Directory.GetCurrentDirectory() + @"\test.txt");

            Thread.Sleep(150);

            string[] line = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\test.txt");
            double[] array = new double[] { -0.055555556 };
            for (int i = 0; i < line.Length; i++)
            {
                Assert.AreEqual(array[i], Convert.ToDouble(line[i]), 0.0001);
            }
        }

        [TestMethod]
        public void TestMethod10()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "AmanProject.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            //n
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(1);
            //b
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(3);
            //c
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(21);
            //x
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(-1.5707963267949);
            //путь до файла
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(Directory.GetCurrentDirectory() + @"\test.txt");

            Thread.Sleep(150);

            string[] line = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\test.txt");
            double[] array = new double[] { -0.055555556 };
            for (int i = 0; i < line.Length; i++)
            {
                Assert.AreEqual(array[i], Convert.ToDouble(line[i]), 0.0001);
            }
        }

        [TestMethod]
        public void TestMethod11()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "AmanProject.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();
            //n
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //b
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(1.001);
            //c
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(21);
            //x1
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(1);
            //x2
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //путь до файла
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(Directory.GetCurrentDirectory() + @"\test.txt");

            Thread.Sleep(150);

            string[] line = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\test.txt");
            double[] array = new double[] { -64.37616313, -75.17245299, -1.810606116, -52.07291726, -83.60176057 };
            for (int i = 0; i < line.Length; i++)
            {
                Assert.AreEqual(array[i], Convert.ToDouble(line[i]), 0.0001);
            }
        }

        [TestMethod]
        public void TestMethod12()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "AmanProject.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();
            //n
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //b
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(0.999);
            //c
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(21);
            //x1
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(1);
            //x2
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //путь до файла
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(Directory.GetCurrentDirectory() + @"\test.txt");

            Thread.Sleep(150);

            string[] line = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\test.txt");
            double[] array = new double[] { 64.36445944, 75.15878651, 1.810276945, 52.06345031, 83.58656163 };
            for (int i = 0; i < line.Length; i++)
            {
                Assert.AreEqual(array[i], Convert.ToDouble(line[i]), 0.0001);
            }
        }

        [TestMethod]
        public void TestMethod13()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "AmanProject.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();
            //n
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //b
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(11.999);
            //c
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(21);
            //x1
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(1);
            //x2
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //путь до файла
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(Directory.GetCurrentDirectory() + @"\test.txt");

            Thread.Sleep(150);

            string[] line = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\test.txt");
            double[] array = new double[] { -64.37616313, -75.17245299, -1.810606116, -52.07291726, -83.60176057 };
            for (int i = 0; i < line.Length; i++)
            {
                Assert.AreEqual(array[i], Convert.ToDouble(line[i]), 0.0001);
            }
        }

        [TestMethod]
        public void TestMethod14()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "AmanProject.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();
            //n
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //b
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(12.001);
            //c
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(21);
            //x1
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(1);
            //x2
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //путь до файла
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(Directory.GetCurrentDirectory() + @"\test.txt");

            Thread.Sleep(150);

            string[] line = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\test.txt");
            double[] array = new double[] { 64.36445944, 75.15878651, 1.810276945, 52.06345031, 83.58656163 };
            for (int i = 0; i < line.Length; i++)
            {
                Assert.AreEqual(array[i], Convert.ToDouble(line[i]), 0.0001);
            }
        }

        [TestMethod]
        public void TestMethod15()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "AmanProject.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();
            //n
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(1);
            //b
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(3);
            //c
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(21);
            //x
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(0);
            //путь до файла
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(Directory.GetCurrentDirectory() + @"\test.txt");

            Thread.Sleep(150);

            string[] line = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\test.txt");
            double[] array = new double[] { 0 };
            for (int i = 0; i < line.Length; i++)
            {
                Assert.AreEqual(array[i], Convert.ToDouble(line[i]), 0.0001);
            }
        }

        [TestMethod]
        public void TestMethod16()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "AmanProject.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();
            //n
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //b
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(8);
            //c
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(21);
            //x1
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(1);
            //x2
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //путь до файла
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(Directory.GetCurrentDirectory() + @"\test*.txt");

            string stringWrong = p.StandardOutput.ReadLine();
            p.Kill();
            Assert.AreEqual("Ќеправильный путь к файлу: " + 
                "—интаксическа€ ошибка в имени файла, имени папки или метке тома. :" + 
                $" '{Directory.GetCurrentDirectory()}\\test*.txt'", stringWrong);
        }

        [TestMethod]
        public void TestMethod17()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "AmanProject.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();
            //n
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //b
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(8);
            //c
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(21);
            //x1
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine("a");

            string stringWrong = p.StandardOutput.ReadLine();
            p.Kill();
            Assert.AreEqual("¬ведено не число", stringWrong);
        }

        [TestMethod]
        public void TestMethod18()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "AmanProject.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();
            //n
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //b
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(8);
            //c
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(21);
            //x1
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(1);
            //x2
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine("b");

            string stringWrong = p.StandardOutput.ReadLine();
            p.Kill();
            Assert.AreEqual("¬ведено не число", stringWrong);
        }

        [TestMethod]
        public void TestMethod19()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "AmanProject.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();
            //n
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine("c");

            string stringWrong = p.StandardOutput.ReadLine();
            p.Kill();
            Assert.AreEqual("¬ведено не число", stringWrong);
        }

        [TestMethod]
        public void TestMethod20()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "AmanProject.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();
            //n
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //b
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine("a");

            string stringWrong = p.StandardOutput.ReadLine();
            p.Kill();
            Assert.AreEqual("¬ведено не число", stringWrong);
        }

        [TestMethod]
        public void TestMethod21()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "AmanProject.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();
            //n
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //b
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(8);
            //c
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine("a");

            string stringWrong = p.StandardOutput.ReadLine();
            p.Kill();
            Assert.AreEqual("¬ведено не число", stringWrong);
        }
    }
}
