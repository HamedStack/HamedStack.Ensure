using System.Runtime.CompilerServices;

namespace HamedStack.Ensure.Extensions;

public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that the specified <paramref name="value"/> is zero.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The value to validate.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not zero.</exception>
    public static T IsZero<T>(this IEnsure ensure, T value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
        where T : struct, IComparable, IComparable<T>
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (Comparer<T>.Default.Compare(value, default) != 0)
        {
            throw exception ?? new ArgumentException(message ?? "Value must be zero.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> is not zero.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The value to validate.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is zero.</exception>
    public static T IsNotZero<T>(this IEnsure ensure, T value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
        where T : struct, IComparable, IComparable<T>
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (Comparer<T>.Default.Compare(value, default) == 0)
        {
            throw exception ?? new ArgumentException(message ?? "Value must not be zero.", parameterName);
        }

        return value;
    }
    /// <summary>
    /// Ensures that the specified <paramref name="value"/> is even.
    /// </summary>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The value to validate.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not even.</exception>
    public static long IsEven(this IEnsure ensure, long value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value % 2 != 0)
        {
            throw exception ?? new ArgumentException(message ?? "Value must be even.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> is odd.
    /// </summary>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The value to validate.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not odd.</exception>
    public static long IsOdd(this IEnsure ensure, long value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value % 2 == 0)
        {
            throw exception ?? new ArgumentException(message ?? "Value must be odd.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> is even.
    /// </summary>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The value to validate.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not even.</exception>
    public static int IsEven(this IEnsure ensure, int value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value % 2 != 0)
        {
            throw exception ?? new ArgumentException(message ?? "Value must be even.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> is odd.
    /// </summary>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The value to validate.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not odd.</exception>
    public static int IsOdd(this IEnsure ensure, int value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value % 2 == 0)
        {
            throw exception ?? new ArgumentException(message ?? "Value must be odd.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> is positive.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The value to validate.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not positive.</exception>
    public static T IsPositive<T>(this IEnsure ensure, T value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
        where T : struct, IComparable, IComparable<T>
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (Comparer<T>.Default.Compare(value, default) <= 0)
        {
            throw exception ?? new ArgumentException(message ?? "Value must be positive.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> is negative.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The value to validate.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not negative.</exception>
    public static T IsNegative<T>(this IEnsure ensure, T value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
        where T : struct, IComparable, IComparable<T>
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (Comparer<T>.Default.Compare(value, default) >= 0)
        {
            throw exception ?? new ArgumentException(message ?? "Value must be negative.", parameterName);
        }

        return value;
    }
}