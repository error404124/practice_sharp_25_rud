namespace App.Practice6;

public readonly struct UserId
{
    public Guid Value { get; }

    public UserId(Guid value)
    {
        Value = value;
    }
}