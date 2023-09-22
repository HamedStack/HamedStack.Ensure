// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace HamedStack.Ensure;

/// <summary>
/// A set of extension methods for performing value validation and ensuring that values meet certain criteria.
/// </summary>
public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that the value is positive (greater than zero).
    /// </summary>
    /// <typeparam name="T">The type of the value to check.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="exceptionCreator">A delegate that creates an exception if the value is not positive.</param>
    /// <param name="paramName">The name of the parameter to include in the exception message.</param>
    /// <returns>The original value if it is positive.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the value is not positive.
    /// </exception>
    public static T EnsurePositive<T>(
        [NotNull] this T value,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null) where T : IComparable<T>
    {
        if (value.CompareTo(default) > 0)
        {
            return value;
        }
        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null)
        {
            throw exception;
        }
        throw new ArgumentOutOfRangeException(
            paramName ?? nameof(value),
            "Value must be positive.");
    }
}
