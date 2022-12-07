using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuncLab;
using System;

namespace FuncLabTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(-0.010569963, Program.AmanGetF(10, 8, 21), 0.000000001);
        }

		[TestMethod]
		[ExpectedException(typeof(DivideByZeroException))]
		public void TestMethod2()
		{
			Program.AmanGetF(10, 1, 21);
		}

		[TestMethod]
		[ExpectedException(typeof(DivideByZeroException))]
		public void TestMethod3()
		{
			Program.AmanGetF(10, 12, 21);
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void TestMethod4()
		{
			Program.AmanGetF(10, 5, 19);
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void TestMethod5()
		{
			Program.AmanGetF(10, 5, 19.999);
		}

		[TestMethod]
		public void TestMethod6()
		{
			Assert.AreEqual(-0.000334252, Program.AmanGetF(10, 5, 20.001), 0.000000001);
		}

		[TestMethod]
		public void TestMethod7()
		{
			Assert.AreEqual(-0.055555556, Program.AmanGetF(1.570796327, 3, 21), 0.000000001);
		}

		[TestMethod]
		public void TestMethod8()
		{
			Assert.AreEqual(-0.055555556, Program.AmanGetF(-1.570796327, 3, 21), 0.000000001);
		}

		[TestMethod]
		public void TestMethod9()
		{
			Assert.AreEqual(-26.90780699, Program.AmanGetF(10, 1.001, 21), 0.00000001);
		}

		[TestMethod]
		public void TestMethod10()
		{
			Assert.AreEqual(26.90291511, Program.AmanGetF(10, 0.999, 21), 0.00000001);
		}

		[TestMethod]
		public void TestMethod11()
		{
			Assert.AreEqual(-26.90780699, Program.AmanGetF(10, 11.999, 21), 0.00000001);
		}

		[TestMethod]
		public void TestMethod12()
		{
			Assert.AreEqual(26.90291511, Program.AmanGetF(10, 12.001, 21), 0.00000001);
		}

		[TestMethod]
		public void TestMethod13()
		{
			Assert.AreEqual(0, Program.AmanGetF(0, 3, 21));
		}
	}
}
