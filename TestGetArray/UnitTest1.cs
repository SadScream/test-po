using AmanProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace TestGetArray
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
        public static void print(double[] val)
        {
            foreach (double v in val)
            {
                Console.Write($"{v} ");
            }
            Console.WriteLine();
        }

        [TestMethod]
        public void TestMethod1()
        {
            double[] expected = new double[]
            {
                -0.025288336,
                -0.02952935,
                -0.000711245,
                -0.020455358,
                -0.032840563
            };
            var actual = Program.GetArray(5, 1, 5, 8, 21);
            CollectionAssert.AreEqual(expected, actual, new Comparer());
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestMethod2()
        {
            Program.GetArray(5, 1, 5, 1, 21);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestMethod3()
        {
            Program.GetArray(5, 1, 5, 12, 21);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod4()
        {
            Program.GetArray(5, 1, 5, 5, 19);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod5()
        {
            Program.GetArray(3, 3, 1, 8, 21);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod6()
        {
            Program.GetArray(0, 1, 5, 8, 21);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod7()
        {
            Program.GetArray(5, 1, 5, 5, 19.999);
        }

        [TestMethod]
        public void TestMethod8()
        {
            double[] expected = new double[]
            {
                -0.000799687,
                -0.00103851,
            };
            var actual = Program.GetArray(2, 1, 5, 5, 20.001);
            CollectionAssert.AreEqual(expected, actual, new Comparer());
        }

        [TestMethod]
        public void TestMethod9()
        {
            double[] expected = new double[]
            {
                -0.055555556,
            };
            var actual = Program.GetArray(1, 1.570796327, 1.570796327, 3, 21);
            print(expected);
            print(actual);
            CollectionAssert.AreEqual(expected, actual, new Comparer());
        }

        [TestMethod]
        public void TestMethod10()
        {
            double[] expected = new double[]
            {
                -0.055555556,
            };
            var actual = Program.GetArray(1, -1.570796327, -1.570796327, 3, 21);
            CollectionAssert.AreEqual(expected, actual, new Comparer());
        }

        [TestMethod]
        public void TestMethod11()
        {
            double[] expected = new double[]
            {
                -64.37616313,
                -75.17245299,
                -1.810606116,
                -52.07291726,
                -83.60176057
            };
            var actual = Program.GetArray(5, 1, 5, 1.001, 21);
            CollectionAssert.AreEqual(expected, actual, new Comparer());
        }

        [TestMethod]
        public void TestMethod12()
        {
            double[] expected = new double[]
            {
                64.36445944,
                75.15878651,
                1.810276945,
                52.06345031,
                83.58656163
            };
            var actual = Program.GetArray(5, 1, 5, 0.999, 21);
            CollectionAssert.AreEqual(expected, actual, new Comparer());
        }

        [TestMethod]
        public void TestMethod13()
        {
            double[] expected = new double[]
            {
                -64.37616313,
                -75.17245299,
                -1.810606116,
                -52.07291726,
                -83.60176057
            };
            var actual = Program.GetArray(5, 1, 5, 11.999, 21);
            CollectionAssert.AreEqual(expected, actual, new Comparer());
        }

        [TestMethod]
        public void TestMethod14()
        {
            double[] expected = new double[]
            {
                64.36445944,
                75.15878651,
                1.810276945,
                52.06345031,
                83.58656163
            };
            var actual = Program.GetArray(5, 1, 5, 12.001, 21);
            CollectionAssert.AreEqual(expected, actual, new Comparer());
        }

        [TestMethod]
        public void TestMethod15()
        {
            double[] expected = new double[]
            {
                0,
            };
            var actual = Program.GetArray(1, 0, 0, 3, 21);
            CollectionAssert.AreEqual(expected, actual, new Comparer());
        }
    }
}
