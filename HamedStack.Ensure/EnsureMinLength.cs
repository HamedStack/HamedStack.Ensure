// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace HamedStack.Ensure;

/// <summary>
/// A set of extension methods for performing value validation and ensuring that values meet certain criteria.
/// </summary>
public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that the length of a value obtained using an <see cref="int"/> length selector is at least the minimum length; otherwise, throws an <see cref="ArgumentException"/>.
    /// </summary>
    /// <typeparam name="T">The type of the value to check.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="lengthSelector">A function that returns the length of the value as an <see cref="int"/>.</param>
    /// <param name="minLength">The minimum length that the value must have.</param>
    /// <param name="exceptionCreator">Optional. A function to create a custom exception. If not provided, a standard <see cref="ArgumentException"/> is thrown.</param>
    /// <param name="paramName">Optional. The name of the parameter associated with the value. If not provided, the parameter name is inferred from the calling code.</param>
    /// <returns>The input value if its length is at least the minimum length; otherwise, throws an exception.</returns>
    /// <exception cref="ArgumentException">Thrown when the length of the value obtained using the <paramref name="lengthSelector"/> is less than the minimum length.</exception>
    public static T EnsureMinLength<T>(
        this T value,
        Func<T, int> lengthSelector,
        int minLength,
        Func<T, string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (lengthSelector(value) >= minLength) return value;

        var exception = exceptionCreator?.Invoke(value, paramName ?? nameof(value));
        if (exception != null)
        {
            throw exception;
        }

        throw new ArgumentException(paramName ?? nameof(value), $"Value length must be at least {minLength}.");
    }

    /// <summary>
    /// Ensures that the length of a value obtained using a <see cref="long"/> length selector is at least the minimum length; otherwise, throws an <see cref="ArgumentException"/>.
    /// </summary>
    /// <typeparam name="T">The type of the value to check.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="lengthSelector">A function that returns the length of the value as a <see cref="long"/>.</param>
    /// <param name="minLength">The minimum length that the value must have.</param>
    /// <param name="exceptionCreator">Optional. A function to create a custom exception. If not provided, a standard <see cref="ArgumentException"/> is thrown.</param>
    /// <param name="paramName">Optional. The name of the parameter associated with the value. If not provided, the parameter name is inferred from the calling code.</param>
    /// <returns>The input value if its length is at least the minimum length; otherwise, throws an exception.</returns>
    /// <exception cref="ArgumentException">Thrown when the length of the value obtained using the <paramref name="lengthSelector"/> is less than the minimum length.</exception>
    public static T EnsureMinLength<T>(
        this T value,
        Func<T, long> lengthSelector,
        long minLength,
        Func<T, string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (lengthSelector(value) >= minLength) return value;

        var exception = exceptionCreator?.Invoke(value, paramName ?? nameof(value));
        if (exception != null)
        {
            throw exception;
        }

        throw new ArgumentException(paramName ?? nameof(value), $"Value length must be at least {minLength}.");
    }
}