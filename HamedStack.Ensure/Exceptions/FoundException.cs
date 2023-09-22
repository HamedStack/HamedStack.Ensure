// ReSharper disable UnusedType.Global

namespace HamedStack.Ensure.Exceptions;

/// <summary>
/// Represents an exception thrown when a value does not represent a "found" state.
/// </summary>
public class FoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FoundException"/> class.
    /// </summary>
    public FoundException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FoundException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public FoundException(string message) : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FoundException"/> class with a specified error message
    /// and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference
    /// if no inner exception is specified.</param>
    public FoundException(string message, Exception innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FoundException"/> class with a specified parameter name
    /// and error message.
    /// </summary>
    /// <param name="paramName">The name of the parameter that caused the exception.</param>
    /// <param name="message">The message that describes the error.</param>
    public FoundException(string paramName, string message) : base(message)
    {
        ParamName = paramName;
    }

    /// <summary>
    /// Gets or sets the name of the parameter that caused the exception.
    /// </summary>
    public string? ParamName { get; }
}