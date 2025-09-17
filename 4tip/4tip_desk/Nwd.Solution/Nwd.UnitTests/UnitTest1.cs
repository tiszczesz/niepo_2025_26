namespace Nwd.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void If_Even_Modulo_0() {
            int number = 12;
            Assert.Equal(0, number % 2);
        }

        [Fact]
        public void If_Times_psitive_negative_Is_negative() {
            int a = 5;
            int b = -3;
            int result = a * b;
            Assert.True(result<0);
        }

    }
}
