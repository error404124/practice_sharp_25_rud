namespace App.Practice6;

public class TimeService : ITimeService
{
    public DateTime GetNowTime()
    {
        return DateTime.Now;
    }
}