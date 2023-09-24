// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace HamedStack.Ensure;

/// <summary>
/// A set of extension methods for performing value validation and ensuring that values meet certain criteria.
/// </summary>
public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that a specified value is not of the specified type; otherwise, throws an <see cref="ArgumentException"/>.
    /// </summary>
    /// <typeparam name="T">The type to check against.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="type">The type that the value should not be.</param>
    /// <param name="exceptionCreator">Optional. A function to create a custom exception. If not provided, a standard <see cref="ArgumentException"/> is thrown.</param>
    /// <param name="paramName">Optional. The name of the parameter associated with the value. If not provided, the parameter name is inferred from the calling code.</param>
    /// <returns>The input value if it is not of the specified type; otherwise, throws an exception.</returns>
    /// <exception cref="ArgumentException">Thrown when the value is of the specified type.</exception>
    public static T EnsureNotType<T>(
        this T value,
        Type type,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (value == null || !type.IsInstanceOfType(value)) return value;

        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null)
        {
            throw exception;
        }

        throw new ArgumentException($"Value must not be of type '{type.FullName}'.", paramName ?? nameof(value));
    }
}