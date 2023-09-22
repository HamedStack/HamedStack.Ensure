// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

using System.Runtime.CompilerServices;

namespace HamedStack.Ensure;

/// <summary>
/// A set of extension methods for performing value validation and ensuring that values meet certain criteria.
/// </summary>
public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that the value contains the specified element.
    /// </summary>
    /// <typeparam name="T">The type of the value to check.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="element">The element to check for.</param>
    /// <param name="exceptionCreator">A delegate that creates an exception if the value does not contain the element.</param>
    /// <param name="paramName">The name of the parameter to include in the exception message.</param>
    /// <returns>The original value if it contains the element.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown when the value does not contain the specified element.
    /// </exception>
    public static T EnsureContain<T>(
        this T value,
        T element,
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

        var exception = exceptionCreator?.Invoke(paramName ?? nameof(value));
        if (exception != null)
        {
            throw exception;
        }

        throw new ArgumentException(
            $"Value must not contain the element '{element}'.",
            paramName ?? nameof(value));
    }
    
    /// <summary>
    /// Ensures that the enum value contains the specified item.
    /// </summary>
    /// <typeparam name="TEnum">The enum type to check.</typeparam>
    /// <param name="enumValue">The enum value to check.</param>
    /// <param name="item">The item to check for.</param>
    /// <param name="exceptionCreator">A delegate that creates an exception if the enum value does not contain the item.</param>
    /// <param name="paramName">The name of the parameter to include in the exception message.</param>
    /// <returns>The original enum value if it contains the item.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown when the enum value does not contain the specified item.
    /// </exception>
    public static TEnum EnsureContains<TEnum>(
        this TEnum enumValue,
        TEnum item,
        Func<string, Exception>? exceptionCreator = null,
        [CallerArgumentExpression("enumValue")] string? paramName = null)
        where TEnum : Enum
    {
        if (enumValue.HasFlag(item))
        {
            return enumValue;
        }

        var exception = exceptionCreator?.Invoke(paramName ?? nameof(enumValue));
        if (exception != null)
        {
            throw exception;
        }

        throw new ArgumentException(
            paramName ?? nameof(enumValue),
            $"Enum value must contain the item '{item}'.");
    }
}