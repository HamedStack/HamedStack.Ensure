using System.Runtime.CompilerServices;

namespace HamedStack.Ensure.Extensions;

/// <summary>
/// Provides extension methods for ensuring certain conditions.
/// </summary>
public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that the provided string is a valid URI.
    /// </summary>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="uri">The string to check if it represents a URI.</param>
    /// <param name="uriKind">One of the enumeration values that specifies whether the URI is absolute or relative.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to "Value must be a valid URI."</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentException"/>.</param>
    /// <returns>The original URI string if it is valid.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="uri"/> is null, empty, whitespace, or not a well-formed URI.</exception>
    public static string IsUri(this IEnsure ensure, string uri, UriKind uriKind = UriKind.Absolute, [CallerArgumentExpression(nameof(uri))] string? parameterName = null, string? message = null, Exception? exception = null)
    {
        if (ensure == null) throw new ArgumentNullException(nameof(ensure));

        if (string.IsNullOrWhiteSpace(uri) || !Uri.IsWellFormedUriString(uri, uriKind))
        {
            throw exception ?? new ArgumentException(message ?? "Value must be a valid URI.", parameterName);
        }

        return uri;
    }
}
