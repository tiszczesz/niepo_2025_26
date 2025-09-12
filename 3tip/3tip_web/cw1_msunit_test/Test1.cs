using cw1.Models;

namespace cw1_msunit_test
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void CanAgeGoatNegative() {
            var goat = new Goat();
            goat.Age = -1;
            Assert.IsFalse(goat.Age<0);
        }
    }
}
