namespace Core.Utilities.Results.Abstract;

// Temel voidlar için
public interface IResult
{
    bool Success { get; }
    string Message { get; }
}