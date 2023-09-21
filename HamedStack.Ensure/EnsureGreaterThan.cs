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
    /// Ensures that the value is greater than the specified minimum value.
    /// </summary>
    /// <typeparam name="T">The type of the value to check.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="minValue">The minimum allowed value.</param>
    /// <param name="paramName">The name of the parameter to include in the exception message.</param>
    /// <returns>The original value if it is greater than the specified minimum value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the value is less than or equal to the specified minimum value.
    /// </exception>
    public static T EnsureGreaterThan<T>(
        this T value,
        T minValue,
        [CallerArgumentExpression("value")] string? paramName = null) where T : IComparable<T>
    {
        if (value.CompareTo(minValue) > 0)
        {
            return value;
        }

        throw new ArgumentOutOfRangeException(
            paramName ?? nameof(value),
            $"Value must be greater than {minValue}.");
    }
    /// <summary>
    /// Ensures that the value is greater than the specified minimum value using a custom exception creator delegate.
    /// </summary>
    /// <typeparam name="T">The type of the value to check.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="minValue">The minimum allowed value.</param>
    /// <param name="exceptionCreator">A delegate that creates an exception if the value is less than or equal to the specified minimum value.</param>
    /// <param name="paramName">The name of the parameter to include in the exception message.</param>
    /// <returns>The original value if it is greater than the specified minimum value.</returns>
    /// <exception cref="Exception">
    /// Thrown when the value is less than or equal to the specified minimum value, as created by the <paramref name="exceptionCreator"/> delegate.
    /// </exception>
    public static T EnsureGreaterThan<T>(
        this T value,
        T minValue,
        Func<string, Exception> exceptionCreator,
        [CallerArgumentExpression("value")] string? paramName = null) where T : IComparable<T>
    {
        if (value.CompareTo(minValue) > 0)
        {
            return value;
        }

        throw exceptionCreator(paramName ?? nameof(value));
    }
}