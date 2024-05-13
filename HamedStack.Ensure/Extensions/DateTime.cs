using System.Runtime.CompilerServices;

namespace HamedStack.Ensure.Extensions;

public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that the specified <paramref name="value"/> is a future date and time.
    /// </summary>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The <see cref="DateTime"/> value to validate.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not a future date and time.</exception>
    public static DateTime Future(this IEnsure ensure, DateTime value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value <= DateTime.Now)
        {
            throw exception ?? new ArgumentException(message ?? "DateTime must be in the future.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> is a past date and time.
    /// </summary>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The <see cref="DateTime"/> value to validate.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not a past date and time.</exception>
    public static DateTime Past(this IEnsure ensure, DateTime value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value >= DateTime.Now)
        {
            throw exception ?? new ArgumentException(message ?? "DateTime must be in the past.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> is a future date and time.
    /// </summary>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The <see cref="DateTimeOffset"/> value to validate.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not a future date and time.</exception>
    public static DateTimeOffset Future(this IEnsure ensure, DateTimeOffset value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value <= DateTimeOffset.Now)
        {
            throw exception ?? new ArgumentException(message ?? "DateTimeOffset must be in the future.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> is a past date and time.
    /// </summary>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The <see cref="DateTimeOffset"/> value to validate.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not a past date and time.</exception>
    public static DateTimeOffset Past(this IEnsure ensure, DateTimeOffset value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value >= DateTimeOffset.Now)
        {
            throw exception ?? new ArgumentException(message ?? "DateTimeOffset must be in the past.", parameterName);
        }

        return value;
    }
}