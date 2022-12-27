using Microsoft.VisualStudio.TestTools.UnitTesting;
using AmanProject;
using System;

namespace TestGetF {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {
            Assert.AreEqual(-2.77712, Program.IlyaGetF(8, 1, 3), 0.00001);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestMethod2() {
            Program.IlyaGetF(10, 0, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestMethod3()
        {
            Program.IlyaGetF(-10, 0, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestMethod4()
        {
            Program.IlyaGetF(5, -9, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestMethod5()
        {
            Program.IlyaGetF(5, -5, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod6()
        {
            Program.IlyaGetF(5, -8, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod7()
        {
            Program.IlyaGetF(5, -8.999, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod8()
        {
            Program.IlyaGetF(5, -5.001, 3);
        }

        [TestMethod]
        public void TestMethod9()
        {
            Assert.AreEqual(0.79981, Program.IlyaGetF(15, 1, 3), 0.00001);
        }

        [TestMethod]
        public void TestMethod10()
        {
            Assert.AreEqual(-0.7998133316182423, Program.IlyaGetF(15, 1, -3));
        }
    }
}
