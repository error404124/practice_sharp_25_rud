using App.Practice7;

namespace AppTests.Test7;

public class BigramsTest
{
    [Test]
    public void BigramsTest1()
    {
        IEnumerable<double> items = new[] { 3.0, 1.0, 2.0 , 5.0};
        var res = ExtensionsTask.Bigrams(items);
        var expected = new List<(double, double)>
        {
            (1.0, 2.0),
            (2.0, 3.0),
            (3.0, 5.0)
        };
        CollectionAssert.AreEqual(expected, res);
    }
}