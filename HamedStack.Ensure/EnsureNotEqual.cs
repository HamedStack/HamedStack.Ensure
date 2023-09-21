// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

using System.Runtime.CompilerServices;

namespace HamedStack.Ensure;

/// <summary>
/// A set of extension methods for performing value validation and ensuring that values meet certain criteria.
/// </summary>
public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that the value is not equal to the specified target value.
    /// </summary>
    /// <typeparam name="T">The type of the value to check.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="targetValue">The target value for comparison.</param>
    /// <param name="paramName">The name of the parameter to include in the exception message.</param>
    /// <returns>The original value if it is not equal to the specified target value.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown when the value is equal to the specified target value.
    /// </exception>
    public static T EnsureNotEqual<T>(
        this T value,
        T targetValue,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (!EqualityComparer<T>.Default.Equals(value, targetValue))
        {
            return value;
        }

        throw new ArgumentException(
            $"Value must not be equal to {targetValue}.",
            paramName ?? nameof(value));
    }
    /// <summary>
    /// Ensures that the value is not equal to the specified target value using a custom exception creator delegate.
    /// </summary>
    /// <typeparam name="T">The type of the value to check.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="targetValue">The target value for comparison.</param>
    /// <param name="exceptionCreator">A delegate that creates an exception if the value is equal to the target value.</param>
    /// <param name="paramName">The name of the parameter to include in the exception message.</param>
    /// <returns>The original value if it is not equal to the specified target value.</returns>
    /// <exception cref="Exception">
    /// Thrown when the value is equal to the specified target value, as created by the <paramref name="exceptionCreator"/> delegate.
    /// </exception>
    public static T EnsureNotEqual<T>(
        this T value,
        T targetValue,
        Func<string, Exception> exceptionCreator,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (!EqualityComparer<T>.Default.Equals(value, targetValue))
        {
            return value;
        }

        throw exceptionCreator(paramName ?? nameof(value));
    }

}