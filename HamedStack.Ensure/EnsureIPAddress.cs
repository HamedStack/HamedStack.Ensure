// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global
// ReSharper disable InconsistentNaming

using System.Net;
using System.Net.Sockets;

namespace HamedStack.Ensure;

/// <summary>
///     A set of extension methods for performing value validation and ensuring that values meet certain criteria.
/// </summary>
public static partial class EnsureExtensions
{
    /// <summary>
    ///     Ensures that a string represents a valid IPv4 address; otherwise, throws an <see cref="ArgumentException" />.
    /// </summary>
    /// <param name="value">The string value to check.</param>
    /// <param name="exceptionCreator">
    ///     Optional. A function to create a custom exception. If not provided, a standard
    ///     <see cref="ArgumentException" /> is thrown.
    /// </param>
    /// <param name="paramName">
    ///     Optional. The name of the parameter associated with the value. If not provided, the parameter
    ///     name is inferred from the calling code.
    /// </param>
    /// <returns>The input IPv4 address string if it is valid; otherwise, throws an exception.</returns>
    /// <exception cref="ArgumentException">Thrown when the string does not represent a valid IPv4 address.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string EnsureIPv4Address(
        this string value,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (IPAddress.TryParse(value, out var ipAddress) &&
            ipAddress.AddressFamily == AddressFamily.InterNetwork) return value;

        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null) throw exception;

        throw new ArgumentException("Invalid IPv4 address.", paramName ?? nameof(value));
    }

    /// <summary>
    ///     Ensures that a string represents a valid IPv6 address; otherwise, throws an <see cref="ArgumentException" />.
    /// </summary>
    /// <param name="value">The string value to check.</param>
    /// <param name="exceptionCreator">
    ///     Optional. A function to create a custom exception. If not provided, a standard
    ///     <see cref="ArgumentException" /> is thrown.
    /// </param>
    /// <param name="paramName">
    ///     Optional. The name of the parameter associated with the value. If not provided, the parameter
    ///     name is inferred from the calling code.
    /// </param>
    /// <returns>The input IPv6 address string if it is valid; otherwise, throws an exception.</returns>
    /// <exception cref="ArgumentException">Thrown when the string does not represent a valid IPv6 address.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string EnsureIPv6Address(
        this string value,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (IPAddress.TryParse(value, out var ipAddress) &&
            ipAddress.AddressFamily == AddressFamily.InterNetworkV6) return value;

        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null) throw exception;

        throw new ArgumentException("Invalid IPv6 address.", paramName ?? nameof(value));
    }
}