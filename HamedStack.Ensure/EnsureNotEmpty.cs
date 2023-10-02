// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global
// ReSharper disable InconsistentNaming

using System.Diagnostics.CodeAnalysis;

namespace HamedStack.Ensure;

/// <summary>
///     A set of extension methods for performing value validation and ensuring that values meet certain criteria.
/// </summary>
public static partial class EnsureExtensions
{
    /// <summary>
    ///     Ensures that the value is not an empty string or collection (e.g., string, array, list).
    /// </summary>
    /// <typeparam name="T">The type of the value to check.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="exceptionCreator">A delegate that creates an exception if the value is empty.</param>
    /// <param name="paramName">The name of the parameter to include in the exception message.</param>
    /// <returns>The original value if it is not empty.</returns>
    /// <exception cref="ArgumentException">
    ///     Thrown when the value is empty.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T EnsureNotEmpty<T>(
        [NotNull] this T value,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (!EqualityComparer<T>.Default.Equals(value, default) && value != null) return value;
        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null) throw exception;
        throw new ArgumentException(
            "Value must not be empty.",
            paramName ?? nameof(value)
        );
    }

    /// <summary>
    ///     Ensures that the ReadOnlySpan is not empty.
    /// </summary>
    /// <param name="span">The ReadOnlySpan to check.</param>
    /// <param name="exceptionCreator">A delegate that creates an exception if the span is empty.</param>
    /// <param name="paramName">The name of the parameter to include in the exception message.</param>
    /// <returns>The original span if it is not empty.</returns>
    /// <exception cref="ArgumentException">
    ///     Thrown when the span is empty.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlySpan<char> EnsureNotEmpty(
        this ReadOnlySpan<char> span,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("span")] string? paramName = null)
    {
        if (!span.IsEmpty) return span;
        var exception = exceptionCreator?.Invoke(paramName ?? nameof(span));
        if (exception != null) throw exception;
        throw new ArgumentException(
            "Span must not be empty.",
            paramName ?? nameof(span)
        );
    }
}