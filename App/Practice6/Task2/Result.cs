namespace App.Practice6;

public class Result<T>
{
    public T Value { get; }
    public bool IsSuccess { get; }
    public int Error { get; }
    public string ErrorMessage { get; }
    
    public Result(T value, bool isSuccess, int errorCode, string errorMessage)
    {
        Value = value;
        IsSuccess = isSuccess;
        Error = errorCode;
        ErrorMessage = errorMessage;
    }

    public static Result<T> CreateSuccess(T value)
    {
        return new Result<T>(value, true, 0, null);
    }

    public static Result<T> CreateFailure(int errorCode, string errorMessage)
    {
        return new Result<T>(default!, false, errorCode, errorMessage);
    }
}

public struct VoidResult
{
}