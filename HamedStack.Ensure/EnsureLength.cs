// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global
// ReSharper disable InconsistentNaming

namespace HamedStack.Ensure;

/// <summary>
///     A set of extension methods for performing value validation and ensuring that values meet certain criteria.
/// </summary>
public static partial class EnsureExtensions
{
    /// <summary>
    ///     Ensures that the length of a value obtained using an <see cref="int" /> length selector matches the expected
    ///     length; otherwise, throws an <see cref="ArgumentException" />.
    /// </summary>
    /// <typeparam name="T">The type of the value to check.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="lengthSelector">A function that returns the length of the value as an <see cref="int" />.</param>
    /// <param name="expectedLength">The expected length that the value must match.</param>
    /// <param name="exceptionCreator">
    ///     Optional. A function to create a custom exception. If not provided, a standard
    ///     <see cref="ArgumentException" /> is thrown.
    /// </param>
    /// <param name="paramName">
    ///     Optional. The name of the parameter associated with the value. If not provided, the parameter
    ///     name is inferred from the calling code.
    /// </param>
    /// <returns>The input value if its length matches the expected length; otherwise, throws an exception.</returns>
    /// <exception cref="ArgumentException">
    ///     Thrown when the length of the value obtained using the
    ///     <paramref name="lengthSelector" /> does not match the expected length.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T EnsureLength<T>(
        this T value,
        Func<T, int> lengthSelector,
        int expectedLength,
        Func<T, string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (lengthSelector(value) == expectedLength) return value;

        var exception = exceptionCreator?.Invoke(value, paramName ?? nameof(value));
        if (exception != null) throw exception;

        throw new ArgumentException(paramName ?? nameof(value), $"Value length must be {expectedLength}.");
    }

    /// <summary>
    ///     Ensures that the length of a value obtained using a <see cref="long" /> length selector matches the expected
    ///     length; otherwise, throws an <see cref="ArgumentException" />.
    /// </summary>
    /// <typeparam name="T">The type of the value to check.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="lengthSelector">A function that returns the length of the value as a <see cref="long" />.</param>
    /// <param name="expectedLength">The expected length that the value must match.</param>
    /// <param name="exceptionCreator">
    ///     Optional. A function to create a custom exception. If not provided, a standard
    ///     <see cref="ArgumentException" /> is thrown.
    /// </param>
    /// <param name="paramName">
    ///     Optional. The name of the parameter associated with the value. If not provided, the parameter
    ///     name is inferred from the calling code.
    /// </param>
    /// <returns>The input value if its length matches the expected length; otherwise, throws an exception.</returns>
    /// <exception cref="ArgumentException">
    ///     Thrown when the length of the value obtained using the
    ///     <paramref name="lengthSelector" /> does not match the expected length.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T EnsureLength<T>(
        this T value,
        Func<T, long> lengthSelector,
        long expectedLength,
        Func<T, string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (lengthSelector(value) == expectedLength) return value;

        var exception = exceptionCreator?.Invoke(value, paramName ?? nameof(value));
        if (exception != null) throw exception;

        throw new ArgumentException(paramName ?? nameof(value), $"Value length must be {expectedLength}.");
    }
}