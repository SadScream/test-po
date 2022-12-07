using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using FuncLab;

namespace TestGetArray
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Calculations arrayExpected = new Calculations();
            double[] arr = new double[] { 1, 2, 3, 4, 5 };
            List<double> arrayActual = new List<double>() { -1.37153012446425, -2.385374566, -2.777129624, -2.444628256, -1.474584546 };
            List<double> array = arrayExpected.CalculateFunction(arr, 8, 1);
            for (int i = 0; i < arrayActual.Count; i++)
            {
                Assert.AreEqual(arrayActual[i], array[i], 0.0001);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestMethod3()
        {
            Calculations arrayExpected = new Calculations();
            double[] arr = new double[] { 1, 2, 3 };
            List<double> arrayActual = new List<double>() { -1.37153012446425, -2.385374566, -2.777129624 };
            List<double> array = arrayExpected.CalculateFunction(arr, 10, 1);
            for (int i = 0; i < arrayActual.Count; i++)
            {
                Assert.AreEqual(arrayActual[i], array[i], 0.0001);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestMethod4()
        {
            Calculations arrayExpected = new Calculations();
            double[] arr = new double[] { 1, 2, 3 };
            List<double> arrayActual = new List<double>() { -1.37153012446425, -2.385374566, -2.777129624 };
            List<double> array = arrayExpected.CalculateFunction(arr, -10, 1);
            for (int i = 0; i < arrayActual.Count; i++)
            {
                Assert.AreEqual(arrayActual[i], array[i], 0.0001);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod5()
        {
            Calculations arrayExpected = new Calculations();
            double[] arr = new double[] { 1, 2, 3 };
            List<double> arrayActual = new List<double>() { -1.37153012446425, -2.385374566, -2.777129624 };
            List<double> array = arrayExpected.CalculateFunction(arr, 8, -6);
            for (int i = 0; i < arrayActual.Count; i++)
            {
                Assert.AreEqual(arrayActual[i], array[i], 0.0001);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestMethod6()
        {
            Calculations arrayExpected = new Calculations();
            double[] arr = new double[] { 1, 2, 3 };
            List<double> arrayActual = new List<double>() { -1.37153012446425, -2.385374566, -2.777129624 };
            List<double> array = arrayExpected.CalculateFunction(arr, 8, -9);
            for (int i = 0; i < arrayActual.Count; i++)
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
            List<double> arrayActual = new List<double>() { -1.37153012446425, -2.385374566, -2.777129624 };
            List<double> array = arrayExpected.CalculateFunction(arr, 8, -5);
            for (int i = 0; i < arrayActual.Count; i++)
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
            List<double> arrayActual = new List<double>() { -1.37153012446425, -2.385374566, -2.777129624 };
            List<double> array = arrayExpected.CalculateFunction(arr, 8, -8.999);
            for (int i = 0; i < arrayActual.Count; i++)
            {
                Assert.AreEqual(arrayActual[i], array[i], 0.0001);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod9()
        {
            Calculations arrayExpected = new Calculations();
            double[] arr = new double[] { 1, 2, 3 };
            List<double> arrayActual = new List<double>() { -1.37153012446425, -2.385374566, -2.777129624 };
            List<double> array = arrayExpected.CalculateFunction(arr, 8, -5.001);
            for (int i = 0; i < arrayActual.Count; i++)
            {
                Assert.AreEqual(arrayActual[i], array[i], 0.0001);
            }
        }
    }
}
