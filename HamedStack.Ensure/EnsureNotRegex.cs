// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

using System.Text.RegularExpressions;

namespace HamedStack.Ensure;

/// <summary>
/// A set of extension methods for performing value validation and ensuring that values meet certain criteria.
/// </summary>
public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that a string matches a specified regular expression pattern; otherwise, throws an <see cref="ArgumentException"/>.
    /// </summary>
    /// <param name="value">The string value to check.</param>
    /// <param name="pattern">The regular expression pattern to match against.</param>
    /// <param name="exceptionCreator">Optional. A function to create a custom exception. If not provided, a standard <see cref="ArgumentException"/> is thrown.</param>
    /// <param name="paramName">Optional. The name of the parameter associated with the value. If not provided, the parameter name is inferred from the calling code.</param>
    /// <exception cref="ArgumentException">Thrown when the string does not match the regular expression pattern.</exception>
    public static string EnsureNotRegex(
        this string value,
        string pattern,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (!Regex.IsMatch(value, pattern)) return value;

        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null)
        {
            throw exception;
        }

        throw new ArgumentException("Value should not match the specified pattern.", paramName ?? nameof(value));
    }
}