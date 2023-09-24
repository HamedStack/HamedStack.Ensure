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
    /// Ensures that the value represents a "not found" state based on a custom condition.
    /// </summary>
    /// <typeparam name="T">The type of the value to check.</typeparam>
    /// <param name="value">The value to check for "not found" state.</param>
    /// <param name="notFoundCondition">A delegate that defines the condition for "not found."</param>
    /// <param name="paramName">The name of the parameter to include in the exception message.</param>
    /// <param name="exceptionCreator">A delegate that creates an exception if the value does not represent "not found."</param>
    /// <returns>The original value if it represents "not found."</returns>
    /// <exception cref="NotFoundException">
    /// Thrown when the value does not represent "not found."
    /// </exception>
    public static T EnsureNotFound<T>(
        this T value,
        Func<T, bool> notFoundCondition,
        [CallerArgumentExpression("value")] string? paramName = null,
        Func<string, Exception>? exceptionCreator = null)
    {
        if (notFoundCondition(value))
        {
            return value;
        }

        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null)
        {
            throw exception;
        }

        throw new NotFoundException(paramName ?? nameof(value), "Value must represent 'not found'.");
    }
}