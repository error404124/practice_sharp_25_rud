namespace Experiments;

public static class ChartDataGenerator
{
    private static readonly Random Random = new();

    public static ChartData GenerateArrayCreationChartData(int repetitions)
    {
        return Experiments.BuildChartData(new Benchmark(), repetitions, ExpType.CreateArray);
    }

    public static ChartData GenerateMethodCallChartData(int repetitions)
    {
        return Experiments.BuildChartData(new Benchmark(), repetitions, ExpType.CallMethodWithArgument);
    }

    public static ChartData GenerateRandomChartData(int repetitions)
    {
        var chartData = new ChartData
        {
            Title = "Random",
            StructPoints = GenerateExperimentResults(repetitions),
            ClassPoints = GenerateExperimentResults(repetitions)
        };
        return chartData;
    }

    private static List<ExperimentResult> GenerateExperimentResults(int repetitions)
    {
        var results = new List<ExperimentResult>();

        for (var i = 0; i < repetitions; i++)
        {
            var fieldsCount = RandomExtensions.NextInclusive(1, 100);
            var averageTime = RandomExtensions.NextDoubleInclusive(1.0, 100.0);

            results.Add(new ExperimentResult(fieldsCount, averageTime));
        }

        return results;
    }
}