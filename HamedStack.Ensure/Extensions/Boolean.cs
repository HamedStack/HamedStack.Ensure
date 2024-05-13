using System.Runtime.CompilerServices;

namespace HamedStack.Ensure.Extensions;

public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that the provided boolean value is false.
    /// </summary>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The boolean value to check for false.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to "Value must be 'false'."</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentException"/>.</param>
    /// <returns>The original boolean value if it is false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is true.</exception>
    public static bool IsFalse(this IEnsure ensure, bool value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure == null) throw new ArgumentNullException(nameof(ensure));

        if (value)
        {
            throw exception ?? new ArgumentException(message ?? "Value must be 'false'.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the provided boolean value is true.
    /// </summary>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The boolean value to check for true.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to "Value must be 'true'."</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentException"/>.</param>
    /// <returns>The original boolean value if it is true.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is false.</exception>
    public static bool IsTrue(this IEnsure ensure, bool value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure == null) throw new ArgumentNullException(nameof(ensure));

        if (!value)
        {
            throw exception ?? new ArgumentException(message ?? "Value must be 'true'.", parameterName);
        }

        return value;
    }
}