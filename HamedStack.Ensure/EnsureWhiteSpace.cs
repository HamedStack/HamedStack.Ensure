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
    ///     Ensures that the value is a string consisting only of white-space characters.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="exceptionCreator">A delegate that creates an exception if the value is not white-space.</param>
    /// <param name="paramName">The name of the parameter to include in the exception message.</param>
    /// <returns>The original value if it consists only of white-space characters.</returns>
    /// <exception cref="ArgumentException">
    ///     Thrown when the value is not white-space.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string EnsureWhiteSpace(
        [NotNull] this string? value,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (value != null && string.IsNullOrWhiteSpace(value)) return value;
        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null) throw exception;
        throw new ArgumentException(
            paramName ?? nameof(value),
            "Value must consist only of white-space characters.");
    }

    /// <summary>
    ///     Ensures that the ReadOnlySpan consists only of white-space characters.
    /// </summary>
    /// <param name="span">The ReadOnlySpan to check.</param>
    /// <param name="exceptionCreator">A delegate that creates an exception if the span is not white-space.</param>
    /// <param name="paramName">The name of the parameter to include in the exception message.</param>
    /// <returns>The original span if it consists only of white-space characters.</returns>
    /// <exception cref="ArgumentException">
    ///     Thrown when the span is not white-space.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlySpan<char> EnsureWhiteSpace(
        this ReadOnlySpan<char> span,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("span")] string? paramName = null)
    {
        if (span.Trim().IsEmpty) return span;
        var exception = exceptionCreator?.Invoke(paramName ?? nameof(span));
        if (exception != null) throw exception;
        throw new ArgumentException(
            "Span must consist only of white-space characters.",
            paramName ?? nameof(span)
        );
    }
}