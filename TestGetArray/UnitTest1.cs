using Laba2;
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
    }
}
