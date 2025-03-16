namespace Experiments;

public class Exp
{
    public ChartData Times(
        int repetitionsCount,
        IBenchmark benchmark,
        string title)
    {
        var classesTimes = new List<ExperimentResult>();
        var structuresTimes = new List<ExperimentResult>();

        foreach (var size in Constants.FieldCounts)
        {
            ITask structTask;
            ITask classTask;
            if (title == "Create array")
            {
                structTask = new StructArrayCreationTask(size);
                classTask = new ClassArrayCreationTask(size);
            }

            else
            {
                structTask = new MethodCallWithStructArgumentTask(size);
                classTask = new MethodCallWithClassArgumentTask(size);
            }

            var structTime = benchmark.MeasureDurationInMs(structTask, repetitionsCount);
            var classTime = benchmark.MeasureDurationInMs(classTask, repetitionsCount);

            structuresTimes.Add(new ExperimentResult(size, structTime));
            classesTimes.Add(new ExperimentResult(size, classTime));

            structuresTimes.Add(new ExperimentResult(size, structTime));
            classesTimes.Add(new ExperimentResult(size, classTime));
        }

        return new ChartData

        {
            Title = title,
            ClassPoints = classesTimes,
            StructPoints = structuresTimes,
        };
    }
}

public class Experiments
{
    public static ChartData BuildChartDataForArrayCreation(
        IBenchmark benchmark, int repetitionsCount)
    {
        return new Exp().Times(repetitionsCount, benchmark, "Create array");
    }

    public static ChartData BuildChartDataForMethodCall(
        IBenchmark benchmark, int repetitionsCount)
    {
        return new Exp().Times(repetitionsCount, benchmark, "Call method with argument");
    }
}