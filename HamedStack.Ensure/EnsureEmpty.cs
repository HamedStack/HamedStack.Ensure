// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

using System.Diagnostics.CodeAnalysis;

namespace HamedStack.Ensure;

/// <summary>
/// A set of extension methods for performing value validation and ensuring that values meet certain criteria.
/// </summary>
public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that the value is an empty string or collection (e.g., string, array, list).
    /// </summary>
    /// <typeparam name="T">The type of the value to check.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="exceptionCreator">A delegate that creates an exception if the value is not empty.</param>
    /// <param name="paramName">The name of the parameter to include in the exception message.</param>
    /// <returns>The original value if it is empty.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown when the value is not empty.
    /// </exception>
    public static T EnsureEmpty<T>(
        [NotNull] this T value,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (EqualityComparer<T>.Default.Equals(value, default) && value != null)
        {
            return value;
        }

        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null)
        {
            throw exception;
        }

        throw new ArgumentException(
            "Value must be empty.",
            paramName ?? nameof(value)
            );
    }
    
    /// <summary>
    /// Ensures that the ReadOnlySpan is empty.
    /// </summary>
    /// <param name="span">The ReadOnlySpan to check.</param>
    /// <param name="exceptionCreator">A delegate that creates an exception if the span is not empty.</param>
    /// <param name="paramName">The name of the parameter to include in the exception message.</param>
    /// <returns>The original span if it is empty.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown when the span is not empty.
    /// </exception>
    public static ReadOnlySpan<char> EnsureEmpty(
        this ReadOnlySpan<char> span,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("span")] string? paramName = null)
    {
        if (span.IsEmpty)
        {
            return span;
        }
        var exception = exceptionCreator?.Invoke(paramName ?? nameof(span));
        if (exception != null)
        {
            throw exception;
        }
        throw new ArgumentException(
            "Span must be empty.",
            paramName ?? nameof(span)
            );
    }
}