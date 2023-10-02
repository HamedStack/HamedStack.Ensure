// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global
// ReSharper disable InconsistentNaming

using System.Diagnostics.CodeAnalysis;

namespace HamedStack.Ensure;

/// <summary>
///     A set of extension methods for performing value validation and ensuring that values meet certain criteria.
/// </summary>
public static partial class EnsureExtensions
{
    /// <summary>
    ///     Ensures that the value is less than the specified maximum value.
    /// </summary>
    /// <typeparam name="T">The type of the value to check.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="maxValue">The maximum allowed value.</param>
    /// <param name="exceptionCreator">A delegate that creates an exception if the value is not less than the target value.</param>
    /// <param name="paramName">The name of the parameter to include in the exception message.</param>
    /// <returns>The original value if it is less than the specified maximum value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Thrown when the value is greater than or equal to the specified maximum value.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T EnsureLessThan<T>(
        [NotNull] this T value,
        [NotNull] T maxValue,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null) where T : IComparable<T>
    {
        if (value.CompareTo(maxValue) < 0) return value;

        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null) throw exception;

        throw new ArgumentOutOfRangeException(
            paramName ?? nameof(value),
            $"Value must be less than {maxValue}.");
    }
}