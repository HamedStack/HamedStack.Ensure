// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

using System.Diagnostics.CodeAnalysis;

namespace HamedStack.Ensure;

/// <summary>
/// A set of extension methods for performing value validation and ensuring that values meet certain criteria.
/// </summary>
public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that the value is equal to zero.
    /// </summary>
    /// <typeparam name="T">The type of the value to check.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="exceptionCreator">A delegate that creates an exception if the value is not equal to zero.</param>
    /// <param name="paramName">The name of the parameter to include in the exception message.</param>
    /// <returns>The original value if it is equal to zero.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown when the value is not equal to zero.
    /// </exception>
    public static T EnsureZero<T>(
        [NotNull] this T value,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null) where T : IComparable<T>
    {
        if (value.CompareTo(default) == 0)
        {
            return value;
        }
        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null)
        {
            throw exception;
        }
        throw new ArgumentException(
            "Value must be equal to zero.",
            paramName ?? nameof(value)
            );
    }
}
