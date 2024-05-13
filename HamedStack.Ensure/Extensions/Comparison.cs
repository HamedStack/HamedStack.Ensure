using System.Runtime.CompilerServices;

namespace HamedStack.Ensure.Extensions;

public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that the provided value is equal to the specified unexpected value.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="unexpectedValue">The unexpected value.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to $"Value must be equal to {unexpectedValue}.".</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentException"/>.</param>
    /// <returns>The original value if it is equal to <paramref name="unexpectedValue"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not equal to <paramref name="unexpectedValue"/>.</exception>
    public static T IsEqual<T>(this IEnsure ensure, T value, T unexpectedValue,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null) where T : IEquatable<T>
    {
        if (ensure == null) throw new ArgumentNullException(nameof(ensure));

        if (!value.Equals(unexpectedValue))
        {
            throw exception ?? new ArgumentException(message ?? $"Value must be equal to {unexpectedValue}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the provided value is not equal to the specified expected value.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="expectedValue">The expected value.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to $"Value cannot be equal to {expectedValue}.".</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentException"/>.</param>
    /// <returns>The original value if it is not equal to <paramref name="expectedValue"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is equal to <paramref name="expectedValue"/>.</exception>
    public static T IsNotEqual<T>(this IEnsure ensure, T value, T expectedValue,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null) where T : IEquatable<T>
    {
        if (ensure == null) throw new ArgumentNullException(nameof(ensure));

        if (value.Equals(expectedValue))
        {
            throw exception ?? new ArgumentException(message ?? $"Value cannot be equal to {expectedValue}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the provided value is less than the specified comparison value.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="comparisonValue">The value to compare against.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to $"Value must be less than {comparisonValue}.".</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentException"/>.</param>
    /// <returns>The original value if it is less than <paramref name="comparisonValue"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not less than <paramref name="comparisonValue"/>.</exception>
    public static T IsLessThan<T>(this IEnsure ensure, T value, T comparisonValue,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null) where T : IComparable<T>
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value.CompareTo(comparisonValue) >= 0)
        {
            throw exception ?? new ArgumentException(message ?? $"Value must be less than {comparisonValue}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the provided value is greater than the specified comparison value.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="comparisonValue">The value to compare against.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to $"Value must be greater than {comparisonValue}.".</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentException"/>.</param>
    /// <returns>The original value if it is greater than <paramref name="comparisonValue"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not greater than <paramref name="comparisonValue"/>.</exception>
    public static T IsGreaterThan<T>(this IEnsure ensure, T value, T comparisonValue,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null) where T : IComparable<T>
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value.CompareTo(comparisonValue) <= 0)
        {
            throw exception ?? new ArgumentException(message ?? $"Value must be greater than {comparisonValue}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the provided value is less than or equal to the specified comparison value.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="comparisonValue">The value to compare against.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to $"Value must be less than or equal to {comparisonValue}.".</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentException"/>.</param>
    /// <returns>The original value if it is less than or equal to <paramref name="comparisonValue"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not less than or equal to <paramref name="comparisonValue"/>.</exception>
    public static T IsLessThanEqual<T>(this IEnsure ensure, T value, T comparisonValue,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null) where T : IComparable<T>
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value.CompareTo(comparisonValue) > 0)
        {
            throw exception ?? new ArgumentException(message ?? $"Value must be less than or equal to {comparisonValue}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the provided value is greater than or equal to the specified comparison value.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="comparisonValue">The value to compare against.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to $"Value must be greater than or equal to {comparisonValue}.".</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentException"/>.</param>
    /// <returns>The original value if it is greater than or equal to <paramref name="comparisonValue"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not greater than or equal to <paramref name="comparisonValue"/>.</exception>
    public static T IsGreaterThanEqual<T>(this IEnsure ensure, T value, T comparisonValue,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null) where T : IComparable<T>
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value.CompareTo(comparisonValue) < 0)
        {
            throw exception ?? new ArgumentException(message ?? $"Value must be greater than or equal to {comparisonValue}.", parameterName);
        }

        return value;
    }
}