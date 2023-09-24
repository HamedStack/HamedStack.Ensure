// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace HamedStack.Ensure;

/// <summary>
/// A set of extension methods for performing value validation and ensuring that values meet certain criteria.
/// </summary>
public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that an <see cref="int"/> value is odd; otherwise, throws an <see cref="ArgumentException"/>.
    /// </summary>
    /// <param name="value">The <see cref="int"/> value to check.</param>
    /// <param name="exceptionCreator">Optional. A function to create a custom exception. If not provided, a standard <see cref="ArgumentException"/> is thrown.</param>
    /// <param name="paramName">Optional. The name of the parameter associated with the value. If not provided, the parameter name is inferred from the calling code.</param>
    /// <returns>The input <see cref="int"/> value if it is odd; otherwise, throws an exception.</returns>
    /// <exception cref="ArgumentException">Thrown when the <see cref="int"/> value is not odd.</exception>
    public static int EnsureOdd(
        this int value,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (value % 2 != 0) return value;

        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null)
        {
            throw exception;
        }

        throw new ArgumentException("Value must be odd.", paramName ?? nameof(value));
    }

    /// <summary>
    /// Ensures that a <see cref="long"/> value is odd; otherwise, throws an <see cref="ArgumentException"/>.
    /// </summary>
    /// <param name="value">The <see cref="long"/> value to check.</param>
    /// <param name="exceptionCreator">Optional. A function to create a custom exception. If not provided, a standard <see cref="ArgumentException"/> is thrown.</param>
    /// <param name="paramName">Optional. The name of the parameter associated with the value. If not provided, the parameter name is inferred from the calling code.</param>
    /// <returns>The input <see cref="long"/> value if it is odd; otherwise, throws an exception.</returns>
    /// <exception cref="ArgumentException">Thrown when the <see cref="long"/> value is not odd.</exception>
    public static long EnsureOdd(
        this long value,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (value % 2 != 0) return value;

        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null)
        {
            throw exception;
        }

        throw new ArgumentException("Value must be odd.", paramName ?? nameof(value));
    }
}