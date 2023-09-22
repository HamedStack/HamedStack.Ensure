// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;

namespace HamedStack.Ensure;

/// <summary>
/// A set of extension methods for performing value validation and ensuring that values meet certain criteria.
/// </summary>
public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that the string does not match the specified regular expression pattern.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <param name="pattern">The regular expression pattern to avoid matching.</param>
    /// <param name="exceptionCreator">A delegate that creates an exception if the string matches the pattern.</param>
    /// <param name="paramName">The name of the parameter to include in the exception message.</param>
    /// <returns>The original string if it does not match the regular expression pattern.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown when the string matches the specified pattern.
    /// </exception>
    public static string EnsureInvalidFormat(
        [NotNull] this string? value,
        [NotNull] string? pattern,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (value != null && pattern != null && !Regex.IsMatch(value, pattern))
        {
            return value;
        }

        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null)
        {
            throw exception;
        }

        throw new ArgumentException(
            $"Value must not match the regular expression pattern: '{pattern}'.",
            paramName ?? nameof(value)
        );
    }
}