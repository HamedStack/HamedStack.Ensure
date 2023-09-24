// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace HamedStack.Ensure;

/// <summary>
/// A set of extension methods for performing value validation and ensuring that values meet certain criteria.
/// </summary>
public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that a <see cref="TimeSpan"/> value is after the specified minimum time; otherwise, throws an <see cref="ArgumentOutOfRangeException"/>.
    /// </summary>
    /// <param name="value">The <see cref="TimeSpan"/> value to check.</param>
    /// <param name="minTime">The minimum <see cref="TimeSpan"/> value that <paramref name="value"/> must be after.</param>
    /// <param name="exceptionCreator">Optional. A function to create a custom exception. If not provided, a standard <see cref="ArgumentOutOfRangeException"/> is thrown.</param>
    /// <param name="paramName">Optional. The name of the parameter associated with the value. If not provided, the parameter name is inferred from the calling code.</param>
    /// <returns>The input <see cref="TimeSpan"/> value if it is after the specified minimum time; otherwise, throws an exception.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="TimeSpan"/> value is not after the specified minimum time.</exception>
    public static TimeSpan EnsureAfter(
        this TimeSpan value,
        TimeSpan minTime,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (value > minTime) return value;

        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null)
        {
            throw exception;
        }

        throw new ArgumentOutOfRangeException(paramName ?? nameof(value), $"Value must be after {minTime}.");
    }

    /// <summary>
    /// Ensures that a <see cref="DateTime"/> value is after the specified minimum date and time; otherwise, throws an <see cref="ArgumentOutOfRangeException"/>.
    /// </summary>
    /// <param name="value">The <see cref="DateTime"/> value to check.</param>
    /// <param name="minDateTime">The minimum <see cref="DateTime"/> value that <paramref name="value"/> must be after.</param>
    /// <param name="exceptionCreator">Optional. A function to create a custom exception. If not provided, a standard <see cref="ArgumentOutOfRangeException"/> is thrown.</param>
    /// <param name="paramName">Optional. The name of the parameter associated with the value. If not provided, the parameter name is inferred from the calling code.</param>
    /// <returns>The input <see cref="DateTime"/> value if it is after the specified minimum date and time; otherwise, throws an exception.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="DateTime"/> value is not after the specified minimum date and time.</exception>
    public static DateTime EnsureAfter(
        this DateTime value,
        DateTime minDateTime,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (value > minDateTime) return value;

        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null)
        {
            throw exception;
        }

        throw new ArgumentOutOfRangeException(paramName ?? nameof(value), $"Value must be after {minDateTime}.");
    }

    /// <summary>
    /// Ensures that a <see cref="DateTimeOffset"/> value is after the specified minimum date and time; otherwise, throws an <see cref="ArgumentOutOfRangeException"/>.
    /// </summary>
    /// <param name="value">The <see cref="DateTimeOffset"/> value to check.</param>
    /// <param name="minDateTimeOffset">The minimum <see cref="DateTimeOffset"/> value that <paramref name="value"/> must be after.</param>
    /// <param name="exceptionCreator">Optional. A function to create a custom exception. If not provided, a standard <see cref="ArgumentOutOfRangeException"/> is thrown.</param>
    /// <param name="paramName">Optional. The name of the parameter associated with the value. If not provided, the parameter name is inferred from the calling code.</param>
    /// <returns>The input <see cref="DateTimeOffset"/> value if it is after the specified minimum date and time; otherwise, throws an exception.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="DateTimeOffset"/> value is not after the specified minimum date and time.</exception>
    public static DateTimeOffset EnsureAfter(
        this DateTimeOffset value,
        DateTimeOffset minDateTimeOffset,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (value > minDateTimeOffset) return value;

        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null)
        {
            throw exception;
        }

        throw new ArgumentOutOfRangeException(paramName ?? nameof(value), $"Value must be after {minDateTimeOffset}.");
    }
}