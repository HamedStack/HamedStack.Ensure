// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

using HamedStack.Ensure.Exceptions;

namespace HamedStack.Ensure;

/// <summary>
/// A set of extension methods for performing value validation and ensuring that values meet certain criteria.
/// </summary>
public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that the value represents a "found" state based on a custom condition.
    /// </summary>
    /// <typeparam name="T">The type of the value to check.</typeparam>
    /// <param name="value">The value to check for "found" state.</param>
    /// <param name="foundCondition">A delegate that defines the condition for "found."</param>
    /// <param name="paramName">The name of the parameter to include in the exception message.</param>
    /// <param name="exceptionCreator">A delegate that creates an exception if the value does not represent "found."</param>
    /// <returns>The original value if it represents "found."</returns>
    /// <exception cref="FoundException">
    /// Thrown when the value does not represent "found."
    /// </exception>
    public static T EnsureFound<T>(
        this T value,
        Func<T, bool> foundCondition,
        [CallerArgumentExpression("value")] string? paramName = null,
        Func<string, Exception>? exceptionCreator = null)
    {
        if (foundCondition(value))
        {
            return value;
        }

        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null)
        {
            throw exception;
        }

        throw new FoundException(paramName ?? nameof(value), "Value must represent 'found'.");
    }
}