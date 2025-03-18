using App.Practice_4;

namespace AppTests.Test4;

public class ClockwiseComparerTest
{
    [Test]

    public void CompareTest1()
    {
        var points = new Vertex[]
        {
            new Vertex(1, 0),
            new Vertex(1, 1),
            new Vertex(0, 1),
            new Vertex(-1, 0),
            new Vertex(0, -1),
            new Vertex(0, -5),
        };
        
        Array.Sort(points, new ClockwiseComparer());
        
        var expected = new Vertex[]
        {
            new Vertex(-1, 0),
            new Vertex(0, -1),
            new Vertex(0, -5),
            new Vertex(1, 0),
            new Vertex(1, 1),
            new Vertex(0, 1),
        };
        for (int i = 0; i < points.Length; i++)
        {
            Assert.AreEqual(expected[i].X, points[i].X);
            Assert.AreEqual(expected[i].Y, points[i].Y);
        }
    }
    
    [Test]

    public void CompareTest2()
    {
        var points = new Vertex[]
        {
            new Vertex(1, 0),
            new Vertex(55, 0),
        };
        
        Array.Sort(points, new ClockwiseComparer());
        
        var expected = new Vertex[]
        {
            new Vertex(1, 0),
            new Vertex(55, 0),
        };
        for (int i = 0; i < points.Length; i++)
        {
            Assert.AreEqual(expected[i].X, points[i].X);
            Assert.AreEqual(expected[i].Y, points[i].Y);
        }
    }
    
    [Test]

    public void CompareTest3()
    {
        var points = new Vertex[]
        {
            new Vertex(-1, 0),
            new Vertex(-55, 0),
        };
        
        Array.Sort(points, new ClockwiseComparer());
        
        var expected = new Vertex[]
        {
            new Vertex(-1, 0),
            new Vertex(-55, 0),
        };
        for (int i = 0; i < points.Length; i++)
        {
            Assert.AreEqual(expected[i].X, points[i].X);
            Assert.AreEqual(expected[i].Y, points[i].Y);
        }
    }
    [Test]

    public void ToStringTest1()
    {
        var v = new Vertex(1, 0);
        
        var expected = v.ToString();
        
        Assert.AreEqual(expected, "(x = 1,000, y = 0,000)");
    }
    
    [Test]
    public void ToStringTest2()
    {
        var v = new Vertex(-41, 10);
        
        var expected = v.ToString();
        
        Assert.AreEqual(expected, "(x = -41,000, y = 10,000)");
    }
}