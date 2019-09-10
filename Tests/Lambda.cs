using Ash.Values;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Lambda : UnitTest
    {
        [TestMethod]
        public void Closure()
        {
            var value = Evaluate("(lambda (x) (x))");

            Assert.IsInstanceOfType(value, typeof(Closure));
        }

        [TestMethod]
        public void Call()
        {
            var value = Evaluate(@"
                (let add-one
                    (lambda (x) (+ x 1)))

                (add-one 1)
            ");

            Assert.IsInstanceOfType(value, typeof(Number));
            Assert.AreEqual(value.GetValue<double>(), 2);
        }
    }
}
