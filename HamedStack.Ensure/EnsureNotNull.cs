// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

using System.Diagnostics.CodeAnalysis;

namespace HamedStack.Ensure;

/// <summary>
/// A set of extension methods for performing value validation and ensuring that values meet certain criteria.
/// </summary>
public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that the value is not null.
    /// </summary>
    /// <typeparam name="T">The type of the value to check.</typeparam>
    /// <param name="value">The value to check for null.</param>
    /// <param name="paramName">The name of the parameter to include in the exception message.</param>
    /// <param name="exceptionCreator">A delegate that creates an exception if the value is null.</param>
    /// <returns>The original value if it is not null.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the value is null.
    /// </exception>
    public static T EnsureNotNull<T>(
        [NotNull] this T? value,
        [CallerArgumentExpression("value")] string? paramName = null,
        Func<string, Exception>? exceptionCreator = null
        ) where T : class
    {
        if (value != null) return value;
        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null)
        {
            throw exception;
        }
        throw new ArgumentNullException(paramName ?? nameof(value));
    }
}
