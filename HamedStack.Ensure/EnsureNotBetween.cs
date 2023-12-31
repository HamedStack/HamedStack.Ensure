﻿// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global
// ReSharper disable InconsistentNaming

using System.Diagnostics.CodeAnalysis;
using HamedStack.Ensure.Enums;

namespace HamedStack.Ensure;

/// <summary>
///     A set of extension methods for performing value validation and ensuring that values meet certain criteria.
/// </summary>
public static partial class EnsureExtensions
{
    /// <summary>
    ///     Ensures that the value does not fall within the specified range inclusively or exclusively.
    /// </summary>
    /// <typeparam name="T">The type of the value to check.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="minValue">The minimum allowed value.</param>
    /// <param name="maxValue">The maximum allowed value.</param>
    /// <param name="minBoundary">The boundary type for the minimum value (inclusive/exclusive).</param>
    /// <param name="maxBoundary">The boundary type for the maximum value (inclusive/exclusive).</param>
    /// <param name="exceptionCreator">A delegate that creates an exception if the value is within the range.</param>
    /// <param name="paramName">The name of the parameter to include in the exception message.</param>
    /// <returns>The original value if it does not fall within the specified range.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Thrown when the value is within the specified range.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T EnsureNotBetween<T>(
        [NotNull] this T value,
        [NotNull] T minValue,
        [NotNull] T maxValue,
        BoundaryType minBoundary = BoundaryType.Exclusive,
        BoundaryType maxBoundary = BoundaryType.Exclusive,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("value")] string? paramName = null
    ) where T : IComparable<T>
    {
        var isLessThanMin = minBoundary == BoundaryType.Exclusive
            ? value.CompareTo(minValue) <= 0
            : value.CompareTo(minValue) < 0;
        var isGreaterThanMax = maxBoundary == BoundaryType.Exclusive
            ? value.CompareTo(maxValue) >= 0
            : value.CompareTo(maxValue) > 0;

        if (isLessThanMin || isGreaterThanMax) return value;

        var minBoundaryStr = minBoundary == BoundaryType.Exclusive ? "(" : "[";
        var maxBoundaryStr = maxBoundary == BoundaryType.Exclusive ? ")" : "]";

        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null) throw exception;

        throw new ArgumentOutOfRangeException(
            paramName ?? nameof(value),
            $"Value must not be in the range {minBoundaryStr}{minValue}, {maxValue}{maxBoundaryStr}.");
    }
}