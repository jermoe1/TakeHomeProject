using TakeHomeProject.Implementations;

namespace TakeHomeTests
{
    [TestClass]
    // sealed class keyword was auto recommended by Visual Studio
    public sealed class ProvidedTestCases
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Bulk A deal being used: 2 for $7.00
            string providedTestCase1 = "ABCDABAA";
            decimal expectedTotal = 32.40M; // (7' * 2) + (12 * 2) + 1.25 + 0.15 = 32.40

            Terminal terminal = new Terminal();
            terminal.Scan(providedTestCase1);
            var actualTotal = terminal.Total();

            Assert.AreEqual(expectedTotal, actualTotal);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Bulk C deal being used: 6 for $6.00
            string providedTestCase2 = "CCCCCCC";
            decimal expectedTotal = 7.25M; // 6.00 + 1.25 = 7.25

            Terminal terminal = new Terminal();
            terminal.Scan(providedTestCase2);
            var actualTotal = terminal.Total();

            Assert.AreEqual(expectedTotal, actualTotal);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string providedTestCase3 = "ABCD";
            decimal expectedTotal = 15.40M; // 2.00 + 12.00 + 1.25 + 0.15 = 15.40

            Terminal terminal = new Terminal();
            terminal.Scan(providedTestCase3);
            var actualTotal = terminal.Total();

            Assert.AreEqual(expectedTotal, actualTotal);
        }
    }
}
