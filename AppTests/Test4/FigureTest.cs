using App.Practice_4;

namespace AppTests.Test4;

public class FigureTest
{
    [Test]
    public void TriangleTest1()
    {
        var v1 = new Figure.Vertex(0, 0);
        var v2 = new Figure.Vertex(1, 0);
        var v3 = new Figure.Vertex(1, 1);
        var a = new Figure.Triangle(v1, v2, v3);
        
        var area = a.CalculateArea();
        Assert.That(Math.Abs(area - 0.5), Is.LessThan(0.05));
        
    }
    
    [Test]
    public void TriangleTest2()
    {
        var v1 = new Figure.Vertex(2, 2);
        var v2 = new Figure.Vertex(0, 0);
        var v3 = new Figure.Vertex(-1, 1);
        var a = new Figure.Triangle(v1, v2, v3);
        
        var area = a.CalculateArea();
        Assert.That(Math.Abs(area - 2), Is.LessThan(0.05));
        
    }
    
    [Test]
    public void RectangleTest1()
    {
        var v1 = new Figure.Vertex(1, 4);
        var v2 = new Figure.Vertex(5, 4);
        var v3 = new Figure.Vertex(5, 1);
        var v4 = new Figure.Vertex(1, 1);
        var a = new Figure.Rectangle(v3, v2,  v4, v1);
        
        var area = a.CalculateArea();
        Assert.That(Math.Abs(area - 12), Is.LessThan(0.05));
        
    }
    
    [Test]
    public void RectangleTest2()
    {
        var v1 = new Figure.Vertex(-1, 2);
        var v2 = new Figure.Vertex(2, -2);
        var v3 = new Figure.Vertex(0, 0);
        var v4 = new Figure.Vertex(0, 2);
        Assert.Throws<ArgumentException>(() => new Figure.Rectangle(v1, v2, v3, v4));
        
    }
    
    [Test]
    public void SquareTest1()
    {
        var v1 = new Figure.Vertex(0, 2);
        var v2 = new Figure.Vertex(2, 2);
        var v3 = new Figure.Vertex(0, 0);
        var v4 = new Figure.Vertex(0, 2);
        var a = new Figure.Square(v1, v2,  v3, v4);
        
        var area = a.CalculateArea();
        Assert.That(Math.Abs(area - 4), Is.LessThan(0.05));
        
    }
    
    [Test]
    public void SquareTest2()
    {
        var v1 = new Figure.Vertex(-1, 2);
        var v2 = new Figure.Vertex(2, 2);
        var v3 = new Figure.Vertex(0, 0);
        var v4 = new Figure.Vertex(0, 2);
        
        Assert.Throws<ArgumentException>(() => new Figure.Square(v1, v2, v3, v4));
        
    }
    
    [Test]
    public void SquareTest3()
    {
        var v1 = new Figure.Vertex(1, 4);
        var v2 = new Figure.Vertex(5, 4);
        var v3 = new Figure.Vertex(5, 1);
        var v4 = new Figure.Vertex(1, 1);
        Assert.Throws<ArgumentException>(() => new Figure.Square(v1, v2, v3, v4));
        
    }
}