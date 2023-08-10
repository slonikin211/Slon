using System.Diagnostics.CodeAnalysis;

namespace Slon.SharedAssets.Common;

/// <summary>
/// Represents the outcome of an operation, encapsulating success or failure along with error information.
/// </summary>
public class Result
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class.
    /// </summary>
    /// <param name="isSuccess">Indicates whether the operation is successful.</param>
    /// <param name="error">The error associated with the result.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the provided combination of success and error is invalid.
    /// </exception>
    protected internal Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
        {
            throw new InvalidOperationException("Invalid combination of success and error.");
        }

        if (!isSuccess && error == Error.None)
        {
            throw new InvalidOperationException("Invalid combination of failure and error.");
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    /// <summary>
    /// Gets a value indicating whether the operation is successful.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Gets a value indicating whether the operation is a failure.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// Gets the error associated with the result.
    /// </summary>
    public Error Error { get; }

    /// <summary>
    /// Creates a new successful result.
    /// </summary>
    /// <returns>A new instance of <see cref="Result"/> representing success.</returns>
    public static Result Success() => new(true, Error.None);

    /// <summary>
    /// Creates a new failure result with the specified error.
    /// </summary>
    /// <param name="error">The error associated with the failure.</param>
    /// <returns>A new instance of <see cref="Result"/> representing failure.</returns>
    public static Result Failure(Error error) => new(false, error);

    /// <summary>
    /// Creates a new successful result with the specified value.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="value">The value to include in the result.</param>
    /// <returns>A new instance of <see cref="Result{TValue}"/> representing success with a value.</returns>
    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

    /// <summary>
    /// Creates a new failure result with the specified error.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="error">The error associated with the failure.</param>
    /// <returns>A new instance of <see cref="Result{TValue}"/> representing failure.</returns>
    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);

    /// <summary>
    /// Creates a new result based on the provided value.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="value">The value to include in the result.</param>
    /// <returns>
    /// A new instance of <see cref="Result{TValue}"/> representing success with the provided value
    /// or a failure result if the value is null.
    /// </returns>
    public static Result<TValue> Create<TValue>(TValue? value) =>
        value is not null ? Success(value) : Failure<TValue>(Error.NullValue);
}


/// <summary>
/// Represents the outcome of an operation with a value, encapsulating success or failure along with error information.
/// </summary>
/// <typeparam name="TValue">The type of the value.</typeparam>
public class Result<TValue> : Result
{
    private readonly TValue? _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{TValue}"/> class.
    /// </summary>
    /// <param name="value">The value of the result.</param>
    /// <param name="isSuccess">Indicates whether the operation is successful.</param>
    /// <param name="error">The error associated with the result.</param>
    protected internal Result(TValue? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        _value = value;
    }

    /// <summary>
    /// Gets the value of the result.
    /// </summary>
    [NotNull]
    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("The value of a failure result cannot be accessed.");

    /// <summary>
    /// Creates a new result with the provided value.
    /// </summary>
    /// <param name="value">The value to include in the result.</param>
    /// <returns>A new instance of <see cref="Result{TValue}"/> representing success with the provided value.</returns>
    public Result<TValue> FromValue(TValue? value) => Create(value);

    /// <summary>
    /// Converts the result to its associated value.
    /// </summary>
    /// <returns>The value associated with the result.</returns>
    public TValue ToValue() => Value;
}
