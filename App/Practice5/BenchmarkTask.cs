using System.Diagnostics;
using System.Text;
using NUnit.Framework;

namespace Experiments;

public class Benchmark : IBenchmark
{
    public double MeasureDurationInMs(ITask task, int repetitionCount)
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();

        task.Run();

        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        for (var i = 0; i < repetitionCount; i++)
        {
            task.Run();
        }

        stopWatch.Stop();
        return stopWatch.Elapsed.TotalMilliseconds / repetitionCount;
    }
}

public class StringBuilderTest : ITask
{
    private int repetitionCount;

    public StringBuilderTest()
    {
    }

    public void Run()
    {
        var sb = new StringBuilder();

        for (var i = 0; i < repetitionCount; i++)
        {
            sb.Append('a');
        }

        sb.ToString();
    }
}

public class StringConstructorTest : ITask
{
    private int repetitionCount;

    public StringConstructorTest()
    {
    }

    public void Run()
    {
        var sb = new string('a', repetitionCount);
    }
}

[TestFixture]
public class RealBenchmarkUsageSample
{
    [Test]
    public void StringConstructorFasterThanStringBuilder()
    {
        var builder = new StringBuilderTest();
        var constructor = new StringConstructorTest();
        var benchmarkBuilder = new Benchmark();
        var benchmarkConstructor = new Benchmark();

        Assert.Less(benchmarkConstructor.MeasureDurationInMs(constructor, 100000), 
            benchmarkBuilder.MeasureDurationInMs(builder, 100000));
    }
}