using App.Practice7;

namespace AppTests.Test7;

public class MedianTest
{
    [Test]
    public void MedianTest1()
    {
        IEnumerable<double> items = new[] { 3.0, 1.0, 2.0 , 5.0};
        var res = ExtensionsTask.Median(items);
        Assert.AreEqual(items.Median(), res);
    }
    
    [Test]
    public void MedianTest2()
    {
        IEnumerable<double> items = new[] { 3.0, 1.0, 2.0};
        var res = ExtensionsTask.Median(items);
        Assert.AreEqual(2, res);
    }
}