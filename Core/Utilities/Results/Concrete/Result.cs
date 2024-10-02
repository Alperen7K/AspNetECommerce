using System.Runtime.CompilerServices;
using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete;

public class Result : IResult
{
    public Result(string message, bool success) : this(success)
    {
        this.Message = message;
        this.Success = success;
    }

    public Result(bool success)
    {
        this.Success = success;
    }

    public bool Success { get; }
    public string Message { get; }
}