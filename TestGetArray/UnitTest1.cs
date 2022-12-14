using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using IlyaTestMet;
using System.Linq;

namespace TestGetArray
{
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
            Calculations arrayExpected = new Calculations();

            double[] arrayActual = new double[] { -1.37153012446425, -2.385374566, -2.777129624, -2.444628256, -1.474584546 };
            double[] array = arrayExpected.GetArray(5, 1, 5, 8, 1);

            for (int i = 0; i < arrayActual.Length; i++)
            {
                Assert.AreEqual(arrayActual[i], array[i], 0.0001);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod2()
        {
            Calculations arrayExpected = new Calculations();

            double[] arrayActual = new double[] { -1.37153012446425, -2.385374566, -2.777129624 };
            double[] array = arrayExpected.GetArray(3, 3, 1, 8, 1);

            for (int i = 0; i < arrayActual.Length; i++)
            {
                Assert.AreEqual(arrayActual[i], array[i], 0.0001);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestMethod3()
        {
            Calculations arrayExpected = new Calculations();

            double[] arrayActual = new double[] { -1.37153012446425, -2.385374566, -2.777129624 };
            double[] array = arrayExpected.GetArray(10, 1, 10, 10, 1);

            for (int i = 0; i < arrayActual.Length; i++)
            {
                Assert.AreEqual(arrayActual[i], array[i], 0.0001);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestMethod4()
        {
            Calculations arrayExpected = new Calculations();

            double[] arrayActual = new double[] { -1.37153012446425, -2.385374566, -2.777129624 };
            double[] array = arrayExpected.GetArray(10, 1, 10, -10, 1);
            for (int i = 0; i < arrayActual.Length; i++)
            {
                Assert.AreEqual(arrayActual[i], array[i], 0.0001);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod5()
        {
            Calculations arrayExpected = new Calculations();

            double[] arrayActual = new double[] { -1.37153012446425, -2.385374566, -2.777129624 };
            double[] array = arrayExpected.GetArray(10, 1, 10, 8, -6);
            for (int i = 0; i < arrayActual.Length; i++)
            {
                Assert.AreEqual(arrayActual[i], array[i], 0.0001);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestMethod6()
        {
            Calculations arrayExpected = new Calculations();

            double[] arrayActual = new double[] { -1.37153012446425, -2.385374566, -2.777129624 };
            double[] array = arrayExpected.GetArray(10, 1, 10, 8, -9);
            for (int i = 0; i < arrayActual.Length; i++)
            {
                Assert.AreEqual(arrayActual[i], array[i], 0.0001);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestMethod7()
        {
            Calculations arrayExpected = new Calculations();
            double[] arr = new double[] { 1, 2, 3 };
            double[] arrayActual = new double[] { -1.37153012446425, -2.385374566, -2.777129624 };
            double[] array = arrayExpected.GetArray(1, 1, 10, 8, -5);
            for (int i = 0; i < arrayActual.Length; i++)
            {
                Assert.AreEqual(arrayActual[i], array[i], 0.0001);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod8()
        {
            Calculations arrayExpected = new Calculations();
            double[] arr = new double[] { 1, 2, 3 };
            double[] arrayActual = new double[] { -1.37153012446425, -2.385374566, -2.777129624 };
            double[] array = arrayExpected.GetArray(1, 2, 5, 8, -8.999);
            for (int i = 0; i < arrayActual.Length; i++)
            {
                Assert.AreEqual(arrayActual[i], array[i], 0.0001);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod9()
        {
            Calculations arrayExpected = new Calculations();
            double[] arrayActual = new double[] { -1.37153012446425, -2.385374566, -2.777129624 };
            double[] array = arrayExpected.GetArray(1, 2, 5, 8, -5.001);
            for (int i = 0; i < arrayActual.Length; i++)
            {
                Assert.AreEqual(arrayActual[i], array[i], 0.0001);
            }
        }


        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestMethod10()
        {
            Calculations arrayExpected = new Calculations();
            double[] arr = new double[] { 1, 2 };
            double[] arrayActual = new double[] { -1.37153012446425, -2.385374566 };
            double[] array = arrayExpected.GetArray(0, 2, 5, 8, 1);
            for (int i = 0; i < arrayActual.Length; i++)
            {
                Assert.AreEqual(arrayActual[i], array[i], 0.0001);
            }
        }

        [TestMethod]
        public void TestMethod11()
        {
            Calculations arrayExpected = new Calculations();
            double[] arr = new double[] { 1 };
            double[] arrayActual = new double[] { -1.37153012446425 };
            double[] array = arrayExpected.GetArray(1, 1, 5, 8, 1);
            for (int i = 0; i < arrayActual.Length; i++)
            {
                Assert.AreEqual(arrayActual[i], array[i], 0.0001);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestMethod12()
        {
            Calculations arrayExpected = new Calculations();
            double[] arr = new double[] { };
            double[] arrayActual = new double[] { };
            double[] array = arrayExpected.GetArray(0, 1, 5, 8, 1);
            for (int i = 0; i < arrayActual.Length; i++)
            {
                Assert.AreEqual(arrayActual[i], array[i], 0.0001);
            }
        }

        [TestMethod]
        public void TestMethod13()
        {
            Calculations arrayExpected = new Calculations();
            double[] arr = new double[] { 1, 2, 3, 4, 5 };
            double[] arrayActual = new double[] { -1.096528242, -2.014955074, -2.606106854, -2.773966935, -2.491270977 };
            double[] array = arrayExpected.GetArray(5, 1, 5, 8, -9.001);
            for (int i = 0; i < arrayActual.Length; i++)
            {
                Assert.AreEqual(arrayActual[i], array[i], 0.0001);
            }
        }

        [TestMethod]
        public void TestMethod14()
        {
            Calculations arrayExpected = new Calculations();
            double[] arr = new double[] { 1, 2, 3, 4, 5 };
            double[] arrayActual = new double[] { 0.89715947, 1.648599606, 2.132269244, 2.26960931, 2.038312618 };
            double[] array = arrayExpected.GetArray(5, 1, 5, 12, -4.999);
            for (int i = 0; i < arrayActual.Length; i++)
            {
                Assert.AreEqual(arrayActual[i], array[i], 0.0001);
            }
        }
    }
}
