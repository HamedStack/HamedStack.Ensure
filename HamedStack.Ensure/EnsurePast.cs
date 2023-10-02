// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global
// ReSharper disable InconsistentNaming

namespace HamedStack.Ensure;

/// <summary>
///     A set of extension methods for performing value validation and ensuring that values meet certain criteria.
/// </summary>
public static partial class EnsureExtensions
{
    /// <summary>
    ///     Ensures that a <see cref="TimeSpan" /> value is before the specified maximum time; otherwise, throws an
    ///     <see cref="ArgumentOutOfRangeException" />.
    /// </summary>
    /// <param name="value">The <see cref="TimeSpan" /> value to check.</param>
    /// <param name="maxTime">The maximum <see cref="TimeSpan" /> value that <paramref name="value" /> must be before.</param>
    /// <param name="exceptionCreator">
    ///     Optional. A function to create a custom exception. If not provided, a standard
    ///     <see cref="ArgumentOutOfRangeException" /> is thrown.
    /// </param>
    /// <param name="paramName">
    ///     Optional. The name of the parameter associated with the value. If not provided, the parameter
    ///     name is inferred from the calling code.
    /// </param>
    /// <returns>
    ///     The input <see cref="TimeSpan" /> value if it is before the specified maximum time; otherwise, throws an
    ///     exception.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Thrown when the <see cref="TimeSpan" /> value is not before the specified
    ///     maximum time.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TimeSpan EnsurePast(
        this TimeSpan value,
        TimeSpan maxTime,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (value < maxTime) return value;

        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null) throw exception;

        throw new ArgumentOutOfRangeException(paramName ?? nameof(value), $"Value must be before {maxTime}.");
    }

    /// <summary>
    ///     Ensures that a <see cref="DateTime" /> value is before the specified maximum date and time; otherwise, throws an
    ///     <see cref="ArgumentOutOfRangeException" />.
    /// </summary>
    /// <param name="value">The <see cref="DateTime" /> value to check.</param>
    /// <param name="maxDateTime">The maximum <see cref="DateTime" /> value that <paramref name="value" /> must be before.</param>
    /// <param name="exceptionCreator">
    ///     Optional. A function to create a custom exception. If not provided, a standard
    ///     <see cref="ArgumentOutOfRangeException" /> is thrown.
    /// </param>
    /// <param name="paramName">
    ///     Optional. The name of the parameter associated with the value. If not provided, the parameter
    ///     name is inferred from the calling code.
    /// </param>
    /// <returns>
    ///     The input <see cref="DateTime" /> value if it is before the specified maximum date and time; otherwise, throws
    ///     an exception.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Thrown when the <see cref="DateTime" /> value is not before the specified
    ///     maximum date and time.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime EnsurePast(
        this DateTime value,
        DateTime maxDateTime,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (value < maxDateTime) return value;

        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null) throw exception;

        throw new ArgumentOutOfRangeException(paramName ?? nameof(value), $"Value must be before {maxDateTime}.");
    }

    /// <summary>
    ///     Ensures that a <see cref="DateTimeOffset" /> value is before the specified maximum date and time; otherwise, throws
    ///     an <see cref="ArgumentOutOfRangeException" />.
    /// </summary>
    /// <param name="value">The <see cref="DateTimeOffset" /> value to check.</param>
    /// <param name="maxDateTimeOffset">
    ///     The maximum <see cref="DateTimeOffset" /> value that <paramref name="value" /> must be
    ///     before.
    /// </param>
    /// <param name="exceptionCreator">
    ///     Optional. A function to create a custom exception. If not provided, a standard
    ///     <see cref="ArgumentOutOfRangeException" /> is thrown.
    /// </param>
    /// <param name="paramName">
    ///     Optional. The name of the parameter associated with the value. If not provided, the parameter
    ///     name is inferred from the calling code.
    /// </param>
    /// <returns>
    ///     The input <see cref="DateTimeOffset" /> value if it is before the specified maximum date and time; otherwise,
    ///     throws an exception.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Thrown when the <see cref="DateTimeOffset" /> value is not before the
    ///     specified maximum date and time.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset EnsurePast(
        this DateTimeOffset value,
        DateTimeOffset maxDateTimeOffset,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (value < maxDateTimeOffset) return value;

        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null) throw exception;

        throw new ArgumentOutOfRangeException(paramName ?? nameof(value), $"Value must be before {maxDateTimeOffset}.");
    }
}