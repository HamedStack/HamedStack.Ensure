// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace HamedStack.Ensure;

/// <summary>
/// A set of extension methods for performing value validation and ensuring that values meet certain criteria.
/// </summary>
public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that a specified condition is true; otherwise, throws an <see cref="ArgumentException"/>.
    /// </summary>
    /// <param name="condition">The boolean condition to check.</param>
    /// <param name="exceptionCreator">Optional. A function to create a custom exception. If not provided, a standard <see cref="ArgumentException"/> is thrown.</param>
    /// <param name="paramName">Optional. The name of the parameter associated with the condition. If not provided, the parameter name is inferred from the calling code.</param>
    /// <returns>True if the condition is true; otherwise, throws an exception.</returns>
    /// <exception cref="ArgumentException">Thrown when the specified condition is false.</exception>
    public static bool EnsureTrue(
        this bool condition,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("condition")]
        string? paramName = null)
    {
        if (condition) return true;

        var exception = exceptionCreator?.Invoke(paramName ?? nameof(condition));
        if (exception != null)
        {
            throw exception;
        }

        throw new ArgumentException("Value must be true.", paramName ?? nameof(condition));
    }
}