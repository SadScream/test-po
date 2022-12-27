using Microsoft.VisualStudio.TestTools.UnitTesting;
using AmanProject;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace TestWTF
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
            string filePath = @"C:\Program Files\test.txt";
            double[] array = { 1, 2, 3, 4, 5 };

            Program.WriteToFile(filePath, array);

            double[] actual = Array.ConvertAll(File.ReadAllLines(filePath), Double.Parse);

            CollectionAssert.AreEqual(array, actual, new Comparer());
        }

        [ExpectedException(typeof(IOException))]
        [TestMethod]
        public void TestMethod2()
        {
            string filePath = @"C:\Program Files\aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.txt";
            double[] array = { 1, 2, 3, 4, 5 };

            Program.WriteToFile(filePath, array);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string filePath = @"C:\Program Files\test.txt";
            double[] array = { };

            Program.WriteToFile(filePath, array);

            double[] actual = Array.ConvertAll(File.ReadAllLines(filePath), Double.Parse);

            CollectionAssert.AreEqual(array, actual, new Comparer());
        }

        [ExpectedException(typeof(IOException))]
        [TestMethod]
        public void TestMethod4()
        {
            string filePath = @"C:\Program Files\test*.txt";
            double[] array = { 1, 2, 3, 4, 5 };

            Program.WriteToFile(filePath, array);
        }

        [ExpectedException(typeof(IOException))]
        [TestMethod]
        public void TestMethod5()
        {
            string filePath = @"C:\Program Files\test<.txt";
            double[] array = { 1, 2, 3, 4, 5 };

            Program.WriteToFile(filePath, array);
        }

        [ExpectedException(typeof(IOException))]
        [TestMethod]
        public void TestMethod6()
        {
            string filePath = @"C:\Program Files\test>.txt";
            double[] array = { 1, 2, 3, 4, 5 };

            Program.WriteToFile(filePath, array);
        }

        [ExpectedException(typeof(IOException))]
        [TestMethod]
        public void TestMethod7()
        {
            string filePath = @"C:\Program Files\test?.txt";
            double[] array = { 1, 2, 3, 4, 5 };

            Program.WriteToFile(filePath, array);
        }

        [ExpectedException(typeof(DirectoryNotFoundException))]
        [TestMethod]
        public void TestMethod8()
        {
            string filePath = @"C:\Program Files\test/.txt";
            double[] array = { 1, 2, 3, 4, 5 };

            Program.WriteToFile(filePath, array);
        }

        [ExpectedException(typeof(DirectoryNotFoundException))]
        [TestMethod]
        public void TestMethod9()
        {
            string filePath = @"C:\Program Files\test\.txt";
            double[] array = { 1, 2, 3, 4, 5 };

            Program.WriteToFile(filePath, array);
        }

        [ExpectedException(typeof(IOException))]
        [TestMethod]
        public void TestMethod10()
        {
            string filePath = @"C:\Program Files\test|.txt";
            double[] array = { 1, 2, 3, 4, 5 };

            Program.WriteToFile(filePath, array);
        }

        [TestMethod]
        public void TestMethod11()
        {
            string filePath = @"C:\Program Files\a.txt";
            double[] array = { 1, 2, 3, 4, 5 };

            Program.WriteToFile(filePath, array);

            double[] actual = Array.ConvertAll(File.ReadAllLines(filePath), Double.Parse);

            CollectionAssert.AreEqual(array, actual, new Comparer());
        }

        [ExpectedException(typeof(DirectoryNotFoundException))]
        [TestMethod]
        public void TestMethod12()
        {
            string filePath = @"Z:\Program Files\test.txt";
            double[] array = { 1, 2, 3, 4, 5 };

            Program.WriteToFile(filePath, array);
        }

        [ExpectedException(typeof(DirectoryNotFoundException))]
        [TestMethod]
        public void TestMethod13()
        {
            string filePath = @"C:\a\b\c\d\aw.txt";
            double[] array = { 1, 2, 3, 4, 5 };

            Program.WriteToFile(filePath, array);

            double[] actual = Array.ConvertAll(File.ReadAllLines(filePath), Double.Parse);

            CollectionAssert.AreEqual(array, actual, new Comparer());
        }
    }
}
