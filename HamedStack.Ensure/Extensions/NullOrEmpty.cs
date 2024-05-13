using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace HamedStack.Ensure.Extensions;

public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that the provided value is not null.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The value to check for null.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to "Value cannot be null."</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentNullException"/>.</param>
    /// <returns>The original value if it is not null.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null or when <paramref name="value"/> is null.</exception>
    public static T IsNotNull<T>(this IEnsure ensure, [NotNull] T value,
         [CallerArgumentExpression(nameof(value))] string? parameterName = null,
         string? message = null,
         Exception? exception = null)
         where T : class
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value == null)
        {
            throw exception ?? new ArgumentNullException(parameterName, message ?? "Value cannot be null.");
        }
        return value;
    }

    /// <summary>
    /// Ensures that the provided value is null.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The value to check for null.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to "Value must be null."</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentException"/>.</param>
    /// <returns>The original value if it is null.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not null.</exception>
    public static T? IsNull<T>(this IEnsure ensure, T? value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
        where T : class
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value != null)
        {
            throw exception ?? new ArgumentException(message ?? "Value must be null.", parameterName);
        }
        return value;
    }

    /// <summary>
    /// Ensures that the provided string value is null or empty.
    /// </summary>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The string value to check for null or empty.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to "Value cannot be null or empty."</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentException"/>.</param>
    /// <returns>The original string value if it is null or empty.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not null or empty.</exception>
    public static string IsNullOrEmpty(this IEnsure ensure, string value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (!string.IsNullOrEmpty(value))
        {
            throw exception ?? new ArgumentException(message ?? "Value cannot be null or empty.", parameterName);
        }
        return value;
    }

    /// <summary>
    /// Ensures that the provided string value is null or consists only of whitespace characters.
    /// </summary>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The string value to check for null or whitespace.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to "Value cannot be null or consist only of whitespace."</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentException"/>.</param>
    /// <returns>The original string value if it is null or consists only of whitespace characters.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not null or consists only of whitespace characters.</exception>
    public static string IsNullOrWhiteSpace(this IEnsure ensure, string value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure == null) throw new ArgumentNullException(nameof(ensure));
        if (string.IsNullOrWhiteSpace(value))
        {
            throw exception ?? new ArgumentException(message ?? "Value cannot be null or consist only of whitespace.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the provided string value is not null or empty.
    /// </summary>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The string value to check for null or empty.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to "Value cannot be null or empty."</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentException"/>.</param>
    /// <returns>The original string value if it is not null or empty.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is null or empty.</exception>
    public static string IsNotNullOrEmpty(this IEnsure ensure, string value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (string.IsNullOrEmpty(value))
        {
            throw exception ?? new ArgumentException(message ?? "Value cannot be null or empty.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the provided string value is not null or consists only of whitespace characters.
    /// </summary>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The string value to check for null or whitespace.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to "Value cannot be null or consist only of whitespace."</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentException"/>.</param>
    /// <returns>The original string value if it is not null or consists only of whitespace characters.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is null or consists only of whitespace characters.</exception>
    public static string IsNotNullOrWhiteSpace(this IEnsure ensure, string value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure == null) throw new ArgumentNullException(nameof(ensure));
        if (string.IsNullOrWhiteSpace(value))
        {
            throw exception ?? new ArgumentException(message ?? "Value cannot be null or consist only of whitespace.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the provided ReadOnlySpan&lt;char&gt; value is not empty.
    /// </summary>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The ReadOnlySpan&lt;char&gt; value to check for being empty.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to "Value cannot be empty."</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentException"/>.</param>
    /// <returns>The original ReadOnlySpan&lt;char&gt; value if it is not empty.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is empty.</exception>
    public static ReadOnlySpan<char> IsNotNullOrEmpty(this IEnsure ensure, ReadOnlySpan<char> value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value.IsEmpty)
        {
            throw exception ?? new ArgumentException(message ?? "Value cannot be empty.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the provided ReadOnlySpan&lt;char&gt; value is not empty or consists only of whitespace characters.
    /// </summary>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The ReadOnlySpan&lt;char&gt; value to check for being empty or whitespace.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to "Value cannot be empty or whitespace."</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentException"/>.</param>
    /// <returns>The original ReadOnlySpan&lt;char&gt; value if it is not empty or whitespace.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is empty or consists only of whitespace characters.</exception>
    public static ReadOnlySpan<char> IsNotNullOrWhiteSpace(this IEnsure ensure, ReadOnlySpan<char> value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value.Trim().IsEmpty)
        {
            throw exception ?? new ArgumentException(message ?? "Value cannot be empty or consist only of whitespace.", parameterName);
        }

        return value;
    }
}