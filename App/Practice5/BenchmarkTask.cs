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

        var stopWatch = new Stopwatch();
        stopWatch.Start();
        for (var i = 0; i < repetitionCount; i++)
        {
            task.Run();
        }

        return stopWatch.Elapsed.TotalMilliseconds / repetitionCount;
    }
}

public class StringBuilderTest : ITask
{
    private int repetitionCount;

    public int RepetitionCount
    {
        get => repetitionCount;
        set => repetitionCount = value;
    }

    public StringBuilderTest(int repetitionCount)
    {
        this.repetitionCount = repetitionCount;
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

    public int RepetitionCount
    {
        get => repetitionCount;
        set => repetitionCount = value;
    }

    public StringConstructorTest(int repetitionCount)
    {
        this.repetitionCount = repetitionCount;
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
        var repetitionCount = 100000;
        var builder = new StringBuilderTest(repetitionCount);
        var constructor = new StringConstructorTest(repetitionCount);

        var benchmarkBuilder = new Benchmark();
        var benchmarkConstructor = new Benchmark();

        Assert.Less(benchmarkConstructor.MeasureDurationInMs(constructor, constructor.RepetitionCount),
            benchmarkBuilder.MeasureDurationInMs(builder, builder.RepetitionCount));
    }
}