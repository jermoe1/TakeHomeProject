using TakeHomeProject.Implementations;

namespace TakeHomeTests;

[TestClass]
public class CustomScanTestCases
{
    [TestMethod]
    public void StandardScanTest()
    {
        string scanList = "ABCD";
        int aCountExpected = 1;
        int bCountExpected = 1;
        int cCountExpected = 1;
        int dCountExpected = 1;

        Terminal terminal = new Terminal();
        terminal.Scan(scanList);

        var aCountActual = terminal.GetScanCount("A");
        var bCountActual = terminal.GetScanCount("B");
        var cCountActual = terminal.GetScanCount("C");
        var dCountActual = terminal.GetScanCount("D");

        Assert.AreEqual(aCountExpected, aCountActual);
        Assert.AreEqual(bCountExpected, bCountActual);
        Assert.AreEqual(cCountExpected, cCountActual);
        Assert.AreEqual(dCountExpected, dCountActual);
    }

    [TestMethod]
    public void RepeatedScanTest()
    {
        string scanList1 = "ABCD";
        string scanList2 = "AAAC";

        int aCountExpected = 4;
        int bCountExpected = 1;
        int cCountExpected = 2;
        int dCountExpected = 1;

        Terminal terminal = new Terminal();
        terminal.Scan(scanList1);
        terminal.Scan(scanList2);

        var aCountActual = terminal.GetScanCount("A");
        var bCountActual = terminal.GetScanCount("B");
        var cCountActual = terminal.GetScanCount("C");
        var dCountActual = terminal.GetScanCount("D");

        Assert.AreEqual(aCountExpected, aCountActual);
        Assert.AreEqual(bCountExpected, bCountActual);
        Assert.AreEqual(cCountExpected, cCountActual);
        Assert.AreEqual(dCountExpected, dCountActual);
    }

    [TestMethod]
    public void EmptyScanTest()
    {
        string scanList = string.Empty;

        int aCountExpected = 0;

        Terminal terminal = new Terminal();
        terminal.Scan(scanList);

        var aCountActual = terminal.GetScanCount("A");
        Assert.AreEqual(aCountExpected, aCountActual);
    }

    [TestMethod]
    public void IgnoreBlanksScanTest()
    {
        string scanList = "A B C D";

        int aCountExpected = 1;
        int bCountExpected = 1;
        int cCountExpected = 1;
        int dCountExpected = 1;

        Terminal terminal = new Terminal();
        terminal.Scan(scanList);

        var aCountActual = terminal.GetScanCount("A");
        var bCountActual = terminal.GetScanCount("B");
        var cCountActual = terminal.GetScanCount("C");
        var dCountActual = terminal.GetScanCount("D");

        Assert.AreEqual(aCountExpected, aCountActual);
        Assert.AreEqual(bCountExpected, bCountActual);
        Assert.AreEqual(cCountExpected, cCountActual);
        Assert.AreEqual(dCountExpected, dCountActual);
    }
}
