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
    ///     Ensures that a string represents a valid URI according to the specified <paramref name="uriKind" />; otherwise,
    ///     throws an <see cref="ArgumentException" />.
    /// </summary>
    /// <param name="value">The string value to check.</param>
    /// <param name="uriKind">
    ///     Optional. The <see cref="UriKind" /> to use when creating the URI. Default is
    ///     <see cref="UriKind.RelativeOrAbsolute" />.
    /// </param>
    /// <param name="exceptionCreator">
    ///     Optional. A function to create a custom exception. If not provided, a standard
    ///     <see cref="ArgumentException" /> is thrown.
    /// </param>
    /// <param name="paramName">
    ///     Optional. The name of the parameter associated with the value. If not provided, the parameter
    ///     name is inferred from the calling code.
    /// </param>
    /// <returns>The input URI string if it is valid; otherwise, throws an exception.</returns>
    /// <exception cref="ArgumentException">
    ///     Thrown when the string does not represent a valid URI according to the specified
    ///     <paramref name="uriKind" />.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string EnsureUri(
        this string value,
        UriKind uriKind = UriKind.RelativeOrAbsolute,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (Uri.TryCreate(value, uriKind, out _)) return value;

        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null) throw exception;

        throw new ArgumentException("Invalid URI.", paramName ?? nameof(value));
    }
}