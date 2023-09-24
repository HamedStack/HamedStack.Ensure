// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace HamedStack.Ensure;

/// <summary>
/// A set of extension methods for performing value validation and ensuring that values meet certain criteria.
/// </summary>
public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that the value contains a specific element. For collections, it checks if the element is present; for enums, it checks if the enum value matches the element.
    /// </summary>
    /// <typeparam name="T">The type of the value to check.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="element">The element to check for presence.</param>
    /// <param name="exceptionCreator">Optional. A function to create a custom exception. If not provided, a standard <see cref="ArgumentException"/> is thrown.</param>
    /// <param name="paramName">Optional. The name of the parameter associated with the value. If not provided, the parameter name is inferred from the calling code.</param>
    /// <returns>The input value if it contains the specified element; otherwise, throws an exception.</returns>
    /// <exception cref="ArgumentException">Thrown when the value does not contain the specified element.</exception>
    public static T EnsureContain<T>(
        this T value,
        T? element,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (EqualityComparer<T>.Default.Equals(value, element))
        {
            return value;
        }

        if (value is IEnumerable<T> enumerable)
        {
            if (enumerable.Contains(element))
            {
                return value;
            }
        }
        else if (element != null && typeof(T).IsEnum && Enum.IsDefined(typeof(T), element))
        {
            return value;
        }

        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null)
        {
            throw exception;
        }

        throw new ArgumentException(
            $"Value must contain the element '{element}'.",
            paramName ?? nameof(value));
    }
}