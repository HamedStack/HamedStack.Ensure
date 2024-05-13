using System.Runtime.CompilerServices;

namespace HamedStack.Ensure.Extensions;

public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that the provided value is of the specified type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type that the value should be.</typeparam>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The value to check against the specified type.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to "Value must be of the specified type."</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentException"/>.</param>
    /// <returns>The original value if it is of type <typeparamref name="T"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not of type <typeparamref name="T"/>.</exception>
    public static object IsType<T>(this IEnsure ensure, object value,
           [CallerArgumentExpression(nameof(value))] string? parameterName = null,
           string? message = null,
           Exception? exception = null)
    {
        if (ensure == null) throw new ArgumentNullException(nameof(ensure));
        if (value is not T)
        {
            throw exception ?? new ArgumentException(message ?? "Value must be of the specified type.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the provided value is not of the specified type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type that the value should not be.</typeparam>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The value to check against the specified type.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to "Value must not be of the specified type."</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentException"/>.</param>
    /// <returns>The original value if it is not of type <typeparamref name="T"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is of type <typeparamref name="T"/>.</exception>
    public static object IsNotType<T>(this IEnsure ensure, object value,
           [CallerArgumentExpression(nameof(value))] string? parameterName = null,
           string? message = null,
           Exception? exception = null)
    {
        if (ensure == null) throw new ArgumentNullException(nameof(ensure));
        if (value is T)
        {
            throw exception ?? new ArgumentException(message ?? "Value must not be of the specified type.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the provided value is of the specified type.
    /// </summary>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The value to check against the specified type.</param>
    /// <param name="expectedType">The type that the value should be.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to "Value must be of type {expectedType.Name}."</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentException"/>.</param>
    /// <returns>The original value if it is of the specified type.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not of the specified type.</exception>
    public static object IsType(this IEnsure ensure, object value, Type expectedType,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure == null) throw new ArgumentNullException(nameof(ensure));
        if (!expectedType.IsInstanceOfType(value))
        {
            throw exception ?? new ArgumentException(message ?? $"Value must be of type {expectedType.Name}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the provided value is not of the specified type.
    /// </summary>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The value to check against the specified type.</param>
    /// <param name="unexpectedType">The type that the value should not be.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to "Value must not be of type {unexpectedType.Name}."</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentException"/>.</param>
    /// <returns>The original value if it is not of the specified type.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is of the specified type.</exception>
    public static object IsNotType(this IEnsure ensure, object value, Type unexpectedType,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure == null) throw new ArgumentNullException(nameof(ensure));
        if (unexpectedType.IsInstanceOfType(value))
        {
            throw exception ?? new ArgumentException(message ?? $"Value must not be of type {unexpectedType.Name}.", parameterName);
        }

        return value;
    }
}