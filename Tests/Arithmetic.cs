using Ash.Values;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Arithmetic : UnitTest
    {
        [TestMethod]
        public void Addition()
        {
            var value = Evaluate("(+ 1 1)");

            Assert.IsInstanceOfType(value, typeof(Number));
            Assert.AreEqual(value.GetValue<double>(), 2);
        }

        [TestMethod]
        public void Subtraction()
        {
            var value = Evaluate("(- 4 2)");

            Assert.IsInstanceOfType(value, typeof(Number));
            Assert.AreEqual(value.GetValue<double>(), 2);
        }

        [TestMethod]
        public void Multiplication()
        {
            var value = Evaluate("(* 6 8)");

            Assert.IsInstanceOfType(value, typeof(Number));
            Assert.AreEqual(value.GetValue<double>(), 48);
        }

        [TestMethod]
        public void Division()
        {
            var value = Evaluate("(/ 4 2)");

            Assert.IsInstanceOfType(value, typeof(Number));
            Assert.AreEqual(value.GetValue<double>(), 2);
        }

        [TestMethod]
        public void Modulo()
        {
            var value = Evaluate("(% 12 6)");

            Assert.IsInstanceOfType(value, typeof(Number));
            Assert.AreEqual(value.GetValue<double>(), 0);
        }
    }
}
