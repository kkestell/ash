using Ash.Values;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ComparisonEquality : UnitTest
    {
        [TestMethod]
        public void GreaterThan()
        {
            var value = Evaluate("(> 2 1)");

            Assert.IsInstanceOfType(value, typeof(Bool));
            Assert.AreEqual(value.GetValue<bool>(), true);
        }

        [TestMethod]
        public void LessThan()
        {
            var value = Evaluate("(< 1 2)");

            Assert.IsInstanceOfType(value, typeof(Bool));
            Assert.AreEqual(value.GetValue<bool>(), true);
        }

        [TestMethod]
        public void Equality()
        {
            var value = Evaluate("(= 1 1)");

            Assert.IsInstanceOfType(value, typeof(Bool));
            Assert.AreEqual(value.GetValue<bool>(), true);
        }
    }
}
