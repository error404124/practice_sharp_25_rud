using App.Practice7;

namespace AppTests.Test7;

public class ZipSumTest
{
    [Test]
    public void ZipSumTest1()
    {
        var first = new List<int> { 1, 2, 3 };
        var second = new List<int> { 4, 5, 6 };
        int[] answer = { 5, 7, 9};
        var result = ZipSumClass.ZipSum(first, second);
        Assert.AreEqual(answer, result);
        
    }
}