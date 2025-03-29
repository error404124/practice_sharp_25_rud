namespace Experiments;

public enum ExpType
{
    CreateArray,
    CallMethodWithArgument
}

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
    public static ChartData BuildChartData(
        IBenchmark benchmark, int repetitionsCount, ExpType type)
    {
        switch (type)
        {
            case ExpType.CreateArray:
                return new Exp().Times(repetitionsCount, benchmark, $"{type}");
            case ExpType.CallMethodWithArgument:
                return new Exp().Times(repetitionsCount, benchmark, $"{type}");
            default:
                throw new ArgumentException("wrong type");
        }
    }
}