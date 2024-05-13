using System.Runtime.CompilerServices;

namespace HamedStack.Ensure.Extensions;

public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that the provided value is between the specified minimum and maximum values.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="min">The minimum allowed value.</param>
    /// <param name="max">The maximum allowed value.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to $"Value must be between {min} and {max}.".</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentOutOfRangeException"/>.</param>
    /// <returns>The original value if it falls between <paramref name="min"/> and <paramref name="max"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="value"/> is not between <paramref name="min"/> and <paramref name="max"/>.</exception>
    public static T IsBetween<T>(this IEnsure ensure, T value, T min, T max,
    [CallerArgumentExpression(nameof(value))] string? parameterName = null,
    string? message = null,
    Exception? exception = null) where T : IComparable<T>
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
        {
            throw exception ?? new ArgumentOutOfRangeException(parameterName, message ?? $"Value must be between {min} and {max}.");
        }

        return value;
    }

    /// <summary>
    /// Ensures that the provided value is not between the specified minimum and maximum values.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="min">The minimum allowed value.</param>
    /// <param name="max">The maximum allowed value.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to $"Value must not be between {min} and {max}.".</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentException"/>.</param>
    /// <returns>The original value if it is not between <paramref name="min"/> and <paramref name="max"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is between <paramref name="min"/> and <paramref name="max"/>.</exception>
    public static T IsNotBetween<T>(this IEnsure ensure, T value, T min, T max,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null) where T : IComparable<T>
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0)
        {
            throw exception ?? new ArgumentException(message ?? $"Value must not be between {min} and {max}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the provided value is exclusively between the specified minimum and maximum values.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="min">The minimum allowed value.</param>
    /// <param name="max">The maximum allowed value.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to $"Value must be exclusively between {min} and {max}.".</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentOutOfRangeException"/>.</param>
    /// <returns>The original value if it falls exclusively between <paramref name="min"/> and <paramref name="max"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="value"/> is not exclusively between <paramref name="min"/> and <paramref name="max"/>.</exception>
    public static T IsBetweenExclusive<T>(this IEnsure ensure, T value, T min, T max,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null) where T : IComparable<T>
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value.CompareTo(min) <= 0 || value.CompareTo(max) >= 0)
        {
            throw exception ?? new ArgumentOutOfRangeException(parameterName, message ?? $"Value must be exclusively between {min} and {max}.");
        }

        return value;
    }

    /// <summary>
    /// Ensures that the provided value is not exclusively between the specified minimum and maximum values.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="min">The minimum allowed value.</param>
    /// <param name="max">The maximum allowed value.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to $"Value must not be exclusively between {min} and {max}.".</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentException"/>.</param>
    /// <returns>The original value if it is not exclusively between <paramref name="min"/> and <paramref name="max"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is exclusively between <paramref name="min"/> and <paramref name="max"/>.</exception>
    public static T IsNotBetweenExclusive<T>(this IEnsure ensure, T value, T min, T max,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null) where T : IComparable<T>
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value.CompareTo(min) > 0 && value.CompareTo(max) < 0)
        {
            throw exception ?? new ArgumentException(message ?? $"Value must not be exclusively between {min} and {max}.", parameterName);
        }

        return value;
    }
}