// ReSharper disable InconsistentNaming

using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace HamedStack.Ensure.Extensions;

public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that the provided string represents a valid IPv4 address.
    /// </summary>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The string value to check for a valid IPv4 address.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to $"Parameter '{parameterName}' must be a valid IPv4 address."</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentException"/>.</param>
    /// <returns>The original string value if it represents a valid IPv4 address.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is null, empty, whitespace, or not a valid IPv4 address.</exception>
    public static string IsIPv4(this IEnsure ensure, string value, [CallerArgumentExpression(nameof(value))] string? parameterName = null, string? message = null, Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (string.IsNullOrWhiteSpace(value) || !IPAddress.TryParse(value, out var ipAddress) || ipAddress.AddressFamily != AddressFamily.InterNetwork)
        {
            throw exception ?? new ArgumentException(message ?? $"Parameter '{parameterName}' must be a valid IPv4 address.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the provided string represents a valid IPv6 address.
    /// </summary>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The string value to check for a valid IPv6 address.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to $"Parameter '{parameterName}' must be a valid IPv6 address."</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentException"/>.</param>
    /// <returns>The original string value if it represents a valid IPv6 address.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is null, empty, whitespace, or not a valid IPv6 address.</exception>
    public static string IsIPv6(this IEnsure ensure, string value, [CallerArgumentExpression(nameof(value))] string? parameterName = null, string? message = null, Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (string.IsNullOrWhiteSpace(value) || !IPAddress.TryParse(value, out var ipAddress) || ipAddress.AddressFamily != AddressFamily.InterNetworkV6)
        {
            throw exception ?? new ArgumentException(message ?? $"Parameter '{parameterName}' must be a valid IPv6 address.", parameterName);
        }

        return value;
    }
}