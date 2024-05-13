using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace HamedStack.Ensure.Extensions;

public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that the specified <paramref name="value"/> matches the specified regular expression <paramref name="pattern"/>.
    /// </summary>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The string to validate.</param>
    /// <param name="pattern">The regular expression pattern to match against.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if the <paramref name="pattern"/> is null or empty, or if <paramref name="value"/> does not match the pattern.</exception>
    public static string Matches(this IEnsure ensure, string value, string pattern,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (string.IsNullOrEmpty(pattern))
        {
            throw new ArgumentException("Pattern must not be null or empty.", nameof(pattern));
        }

        if (!Regex.IsMatch(value, pattern))
        {
            throw exception ?? new ArgumentException(message ?? $"Value does not match the required pattern: {pattern}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> does not match the specified regular expression <paramref name="pattern"/>.
    /// </summary>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The string to validate.</param>
    /// <param name="pattern">The regular expression pattern to avoid matching.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if the <paramref name="pattern"/> is null or empty, or if <paramref name="value"/> matches the pattern.</exception>
    public static string NotMatches(this IEnsure ensure, string value, string pattern,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (string.IsNullOrEmpty(pattern))
        {
            throw new ArgumentException("Pattern must not be null or empty.", nameof(pattern));
        }

        if (Regex.IsMatch(value, pattern))
        {
            throw exception ?? new ArgumentException(message ?? $"Value must not match the pattern: {pattern}.", parameterName);
        }

        return value;
    }
}