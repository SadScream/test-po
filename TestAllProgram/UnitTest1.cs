using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace TestAllProgram
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "IlyaProject.exe";
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
            p.StandardInput.WriteLine(1);
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
            double[] array = new double[] { -1.3715301244642522, -2.3853745661267767, -2.777129623674452, -2.4446282555304797, -1.4745845460417426 };
            for (int i = 0; i < line.Length; i++)
            {
                Assert.AreEqual(array[i], Convert.ToDouble(line[i]), 0.0001);
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "IlyaProject.exe";
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
            p.StandardInput.WriteLine(1);
            //x1
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //x2
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(1);

            //Console.WriteLine(p.StandardError.ReadLine());
            Assert.IsNotNull(p.StandardError.ReadLine());
            p.Kill();

        }

        [TestMethod]
        public void TestMethod3()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "IlyaProject.exe";
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
            p.StandardInput.WriteLine(10);

            string stringWrong = p.StandardOutput.ReadLine();
            p.Kill();
            Assert.AreEqual("B не должно быть равно 10 или -10", stringWrong);
        }

        [TestMethod]
        public void TestMethod4()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "IlyaProject.exe";
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
            p.StandardInput.WriteLine(-10);

            string stringWrong = p.StandardOutput.ReadLine();
            p.Kill();
            Assert.AreEqual("B не должно быть равно 10 или -10", stringWrong);
        }

        [TestMethod]
        public void TestMethod5()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "IlyaProject.exe";
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
            p.StandardInput.WriteLine(-6);

            string stringWrong = p.StandardOutput.ReadLine();
            p.Kill();
            Assert.AreEqual("C должно быть больше чем -5 и меньше чем-9", stringWrong);
        }

        [TestMethod]
        public void TestMethod6()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "IlyaProject.exe";
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
            p.StandardInput.WriteLine(-9);

            string stringWrong = p.StandardOutput.ReadLine();
            p.Kill();
            Assert.AreEqual("C не должно быть равно -9 или -5", stringWrong);
        }

        [TestMethod]
        public void TestMethod7()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "IlyaProject.exe";
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
            p.StandardInput.WriteLine(-5);

            string stringWrong = p.StandardOutput.ReadLine();
            p.Kill();
            Assert.AreEqual("C не должно быть равно -9 или -5", stringWrong);
        }

        [TestMethod]
        public void TestMethod8()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "IlyaProject.exe";
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
            p.StandardInput.WriteLine(-8.999);

            string stringWrong = p.StandardOutput.ReadLine();
            p.Kill();
            Assert.AreEqual("C должно быть больше чем -5 и меньше чем-9", stringWrong);
        }

        [TestMethod]
        public void TestMethod9()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "IlyaProject.exe";
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
            p.StandardInput.WriteLine(-5.001);

            string stringWrong = p.StandardOutput.ReadLine();
            p.Kill();
            Assert.AreEqual("C должно быть больше чем -5 и меньше чем-9", stringWrong);
        }

        [TestMethod]
        public void TestMethod10()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "IlyaProject.exe";
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
        public void TestMethod11()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "IlyaProject.exe";
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
            p.StandardInput.WriteLine(-9.001);
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
            double[] array = new double[] { -1.0965282417577722, -2.0149550743927005, -2.6061068543638726, -2.7739669347588958, -2.491270977355259 };
            for (int i = 0; i < line.Length; i++)
            {
                Assert.AreEqual(array[i], Convert.ToDouble(line[i]), 0.0001);
            }
        }

        [TestMethod]
        public void TestMethod12()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "IlyaProject.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            //n
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //b
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(12);
            //c
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(-4.999);
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
            double[] array = new double[] { 0.8971594702945838, 1.6485996059699282, 2.1322692442145454, 2.2696093103107375, 2.0383126184005804 };
            for (int i = 0; i < line.Length; i++)
            {
                Assert.AreEqual(array[i], Convert.ToDouble(line[i]), 0.0001);
            }
        }

        [TestMethod]
        public void TestMethod13()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "IlyaProject.exe";
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
            p.StandardInput.WriteLine(1);
            //x1
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(1);
            //x2
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //путь до файла
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(@"D:\newDirec\test*.txt");

            string stringWrong = p.StandardOutput.ReadLine();
            p.Kill();
            Assert.AreEqual("Ќеверное им€ файла", stringWrong);
        }

        [TestMethod]
        public void TestMethod14()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "IlyaProject.exe";
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
            p.StandardInput.WriteLine(1);
            //x1
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(1);
            //x2
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(5);
            //путь до файла
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine(Directory.GetCurrentDirectory() + @"\con.txt");

            string stringWrong = p.StandardError.ReadLine();
            p.Kill();
            Assert.IsNotNull(stringWrong);
        }

        [TestMethod]
        public void TestMethod15()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "IlyaProject.exe";
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
            p.StandardInput.WriteLine(1);
            //x1
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine("a");

            string stringWrong = p.StandardOutput.ReadLine();
            p.Kill();
            Assert.AreEqual("¬ведено не число", stringWrong);
        }

        [TestMethod]
        public void TestMethod16()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "IlyaProject.exe";
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
            p.StandardInput.WriteLine(1);
            //x1
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine("1");
            //x2
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine("b");

            string stringWrong = p.StandardOutput.ReadLine();
            p.Kill();
            Assert.AreEqual("¬ведено не число", stringWrong);
        }

        [TestMethod]
        public void TestMethod17()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "IlyaProject.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine("n");
            string stringWrong = p.StandardOutput.ReadLine();
            p.Kill();
            Assert.AreEqual("¬ведено не число", stringWrong);
        }

        [TestMethod]
        public void TestMethod18()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "IlyaProject.exe";
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
        public void TestMethod19()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "IlyaProject.exe";
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
            p.StandardInput.WriteLine("8");
            //c
            p.StandardOutput.ReadLine();
            p.StandardInput.WriteLine("a");

            string stringWrong = p.StandardOutput.ReadLine();
            p.Kill();
            Assert.AreEqual("¬ведено не число", stringWrong);
        }
   
    }
}
