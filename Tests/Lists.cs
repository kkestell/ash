using System.Collections.Generic;
using System.Linq;
using Ash.Values;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Lists : UnitTest
    {
        [TestMethod]
        public void List()
        {
            var value = Evaluate("(list 1 2 3)");

            Assert.IsInstanceOfType(value, typeof(List));
        }

        [TestMethod]
        public void Filter()
        {
            var value = Evaluate(@"
                (filter
                    (lambda (x) (= x 1))
                    (list 1 0 1 1 0))
            ");

            Assert.AreEqual(value.GetValue<List<Value>>().Count(), 3);
        }

        [TestMethod]
        public void First()
        {
            var value = Evaluate("(first (list 1 2 3))");

            Assert.IsInstanceOfType(value, typeof(Number));
            Assert.AreEqual(value.GetValue<double>(), 1);
        }

        [TestMethod]
        public void Last()
        {
            var value = Evaluate("(last (list 1 2 3))");

            Assert.IsInstanceOfType(value, typeof(Number));
            Assert.AreEqual(value.GetValue<double>(), 3);
        }

        [TestMethod]
        public void Reduce()
        {
            var value = Evaluate(@"
                (reduce
                    (lambda (x y) (+ x y))
                    (list 1 2 3))
            ");

            Assert.IsInstanceOfType(value, typeof(Number));
            Assert.AreEqual(value.GetValue<double>(), 6);
        }
    }
}
