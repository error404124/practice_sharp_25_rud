namespace App.Practice6;

public class TimeService : ITimeService
{
    private DateTime currentTime;
    
    public TimeService(DateTime startTime)
    {
        currentTime = startTime;
    }

    public DateTime GetNowTime()
    {
        return currentTime;
    }

    public void Advance(TimeSpan timeSpan)
    {
        currentTime = currentTime.Add(timeSpan);
    }
}