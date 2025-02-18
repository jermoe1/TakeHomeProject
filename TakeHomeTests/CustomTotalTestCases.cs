using TakeHomeProject.Implementations;

namespace TakeHomeTests;

[TestClass]
public class CustomTotalTestCases
{
    [TestMethod]
    public void InvalidProductCodeTest()
    {
        // 'E' is not a valid product code
        // Current implementation does not throw an exception for invalid product codes

        string invalidScanList = "ABCDE";
        decimal expectedTotal = 15.40M; // 2.00 + 12.00 + 1.25 + 0.15 = 15.40

        Terminal terminal = new Terminal();
        terminal.Scan(invalidScanList);
        var actualTotal = terminal.Total();

        Assert.AreEqual(expectedTotal, actualTotal);
    }

    [TestMethod]
    public void RepeatedScanTotalTest()
    {
        string scanList1 = "ABCD";
        string scanList2 = "AAAC";

        decimal expectedTotal = 21.65M; // 7' + 12 + (2 * 1.25) + 0.15 = 21.65

        Terminal terminal = new Terminal();
        terminal.Scan(scanList1);
        terminal.Scan(scanList2);
        var actualTotal = terminal.Total();

        Assert.AreEqual(expectedTotal, actualTotal);
    }

    [TestMethod]
    public void EmptyScanTotalTest()
    {
        string scanList = string.Empty;

        decimal expectedTotal = 0.00M;

        Terminal terminal = new Terminal();
        terminal.Scan(scanList);
        var actualTotal = terminal.Total();

        Assert.AreEqual(expectedTotal, actualTotal);
    }

    [TestMethod]
    public void IgnoreBlanksScanTotalTest()
    {
        string scanList = "A B C D"; // 2.00 + 12.00 + 1.25 + 0.15 = 15.40

        decimal expectedTotal = 15.40M;

        Terminal terminal = new Terminal();
        terminal.Scan(scanList);
        var actualTotal = terminal.Total();

        Assert.AreEqual(expectedTotal, actualTotal);
    }
}
