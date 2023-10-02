// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global
// ReSharper disable InconsistentNaming

using System.Text.RegularExpressions;

namespace HamedStack.Ensure;

/// <summary>
///     A set of extension methods for performing value validation and ensuring that values meet certain criteria.
/// </summary>
public static partial class EnsureExtensions
{
    /// <summary>
    ///     Ensures that a string represents a valid email address; otherwise, throws an <see cref="ArgumentException" />.
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
    /// <returns>The input email address if it is valid; otherwise, throws an exception.</returns>
    /// <exception cref="ArgumentException">Thrown when the string does not represent a valid email address.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string EnsureEmail(
        this string value,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        const string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        if (Regex.IsMatch(value, pattern)) return value;

        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null) throw exception;

        throw new ArgumentException("Value does not match the specified pattern.", paramName ?? nameof(value));
    }
}