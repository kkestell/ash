using Ash;
using Ash.Values;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Assignment : UnitTest
    {
        [TestMethod]
        public void Let()
        {
            var value = Evaluate(@"
                (let a 10)
            ");

            Assert.IsInstanceOfType(value, typeof(Number));
            Assert.AreEqual(value.GetValue<double>(), 10);
        }

        [TestMethod]
        public void Reassignment()
        {
            var value = Evaluate(@"
                (let a 10)
                (let a 20)
            ");

            Assert.IsInstanceOfType(value, typeof(Number));
            Assert.AreEqual(value.GetValue<double>(), 20);
        }
    }
}
