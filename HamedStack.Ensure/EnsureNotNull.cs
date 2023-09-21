// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

using System.Runtime.CompilerServices;

namespace HamedStack.Ensure;

/// <summary>
/// A set of extension methods for performing value validation and ensuring that values meet certain criteria.
/// </summary>
public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that the value is not null.
    /// </summary>
    /// <typeparam name="T">The type of the value to check.</typeparam>
    /// <param name="value">The value to check for null.</param>
    /// <param name="paramName">The name of the parameter to include in the exception message.</param>
    /// <returns>The original value if it is not null.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the value is null.
    /// </exception>
    public static T EnsureNotNull<T>(
        this T value,
        [CallerArgumentExpression("value")] string? paramName = null) where T : class
    {
        if (value == null)
        {
            throw new ArgumentNullException(paramName ?? nameof(value));
        }
        return value;
    }

    /// <summary>
    /// Ensures that the value is not null and provides a custom exception creator delegate.
    /// </summary>
    /// <typeparam name="T">The type of the value to check.</typeparam>
    /// <param name="value">The value to check for null.</param>
    /// <param name="exceptionCreator">A delegate that creates an exception if the value is null.</param>
    /// <param name="paramName">The name of the parameter to include in the exception message.</param>
    /// <returns>The original value if it is not null.</returns>
    /// <exception cref="Exception">
    /// Thrown when the value is null, as created by the <paramref name="exceptionCreator"/> delegate.
    /// </exception>
    public static T EnsureNotNull<T>(
        this T value,
        Func<string, Exception> exceptionCreator,
        [CallerArgumentExpression("value")] string? paramName = null) where T : class
    {
        if (value == null)
        {
            throw exceptionCreator(paramName ?? nameof(value));
        }
        return value;
    }
}
