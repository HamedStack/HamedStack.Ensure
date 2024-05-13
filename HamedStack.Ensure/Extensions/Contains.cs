using System.Runtime.CompilerServices;

// ReSharper disable PossibleMultipleEnumeration

namespace HamedStack.Ensure.Extensions;

public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that the specified <paramref name="value"/> contains the specified <paramref name="substring"/>.
    /// </summary>
    /// <param name="ensure">The <see cref="IEnsure"/> instance.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="substring">The substring to check for within the value.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The custom error message to throw if the condition is not met.</param>
    /// <param name="exception">The custom exception to throw if the condition is not met.</param>
    /// <returns>The original <paramref name="value"/> if the condition is met.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/>, <paramref name="value"/>, or <paramref name="substring"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the <paramref name="value"/> does not contain the <paramref name="substring"/>.</exception>
    public static string Contains(this IEnsure ensure, string value, string substring,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value == null) throw new ArgumentNullException(nameof(value));
        if (string.IsNullOrWhiteSpace(substring))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(substring));

        if (!value.Contains(substring))
        {
            throw exception ?? new ArgumentException(message ?? $"Value must contain '{substring}'.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> does not contain the specified <paramref name="substring"/>.
    /// </summary>
    /// <param name="ensure">The <see cref="IEnsure"/> instance.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="substring">The substring to check for within the value.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The custom error message to throw if the condition is not met.</param>
    /// <param name="exception">The custom exception to throw if the condition is not met.</param>
    /// <returns>The original <paramref name="value"/> if the condition is met.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/>, <paramref name="value"/>, or <paramref name="substring"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the <paramref name="value"/> contains the <paramref name="substring"/>.</exception>
    public static string NotContain(this IEnsure ensure, string value, string substring,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value == null) throw new ArgumentNullException(nameof(value));
        if (string.IsNullOrWhiteSpace(substring))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(substring));

        if (value.Contains(substring))
        {
            throw exception ?? new ArgumentException(message ?? $"Value must not contain '{substring}'.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="collection"/> contains the specified <paramref name="item"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="ensure">The <see cref="IEnsure"/> instance.</param>
    /// <param name="collection">The collection to check.</param>
    /// <param name="item">The item to check for within the collection.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The custom error message to throw if the condition is not met.</param>
    /// <param name="exception">The custom exception to throw if the condition is not met.</param>
    /// <returns>The original <paramref name="collection"/> if the condition is met.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> or <paramref name="collection"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the <paramref name="collection"/> does not contain the <paramref name="item"/>.</exception>
    public static IEnumerable<T> Contains<T>(this IEnsure ensure, IEnumerable<T> collection, T item,
        [CallerArgumentExpression(nameof(collection))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (collection == null) throw new ArgumentNullException(nameof(collection));

        if (!collection.Contains(item))
        {
            throw exception ?? new ArgumentException(message ?? "Collection must contain the specified item.", parameterName);
        }

        return collection;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="collection"/> does not contain the specified <paramref name="item"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="ensure">The <see cref="IEnsure"/> instance.</param>
    /// <param name="collection">The collection to check.</param>
    /// <param name="item">The item to check for within the collection.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The custom error message to throw if the condition is not met.</param>
    /// <param name="exception">The custom exception to throw if the condition is not met.</param>
    /// <returns>The original <paramref name="collection"/> if the condition is met.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> or <paramref name="collection"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the <paramref name="collection"/> contains the <paramref name="item"/>.</exception>
    public static IEnumerable<T> NotContain<T>(this IEnsure ensure, IEnumerable<T> collection, T item,
        [CallerArgumentExpression(nameof(collection))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (collection == null) throw new ArgumentNullException(nameof(collection));

        if (collection.Contains(item))
        {
            throw exception ?? new ArgumentException(message ?? "Collection must not contain the specified item.", parameterName);
        }

        return collection;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> contains the specified <paramref name="enumFlag"/>.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="ensure">The <see cref="IEnsure"/> instance.</param>
    /// <param name="value">The enum value to check.</param>
    /// <param name="enumFlag">The enum flag to check for within the value.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The custom error message to throw if the condition is not met.</param>
    /// <param name="exception">The custom exception to throw if the condition is not met.</param>
    /// <returns>The original <paramref name="value"/> if the condition is met.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the <paramref name="value"/> does not contain the <paramref name="enumFlag"/>.</exception>
    public static TEnum ContainsFlag<TEnum>(this IEnsure ensure, TEnum value, TEnum enumFlag,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null) where TEnum : struct, Enum
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (!Enum.IsDefined(typeof(TEnum), enumFlag))
        {
            throw new ArgumentException("The specified enum flag is not defined.", nameof(enumFlag));
        }

        if (!value.HasFlag(enumFlag))
        {
            throw exception ?? new ArgumentException(message ?? $"Value must contain the flag '{enumFlag}'.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> does not contain the specified <paramref name="enumFlag"/>.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="ensure">The <see cref="IEnsure"/> instance.</param>
    /// <param name="value">The enum value to check.</param>
    /// <param name="enumFlag">The enum flag to check for within the value.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The custom error message to throw if the condition is not met.</param>
    /// <param name="exception">The custom exception to throw if the condition is not met.</param>
    /// <returns>The original <paramref name="value"/> if the condition is met.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the <paramref name="value"/> contains the <paramref name="enumFlag"/>.</exception>
    public static TEnum NotContainFlag<TEnum>(this IEnsure ensure, TEnum value, TEnum enumFlag,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null) where TEnum : struct, Enum
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (!Enum.IsDefined(typeof(TEnum), enumFlag))
        {
            throw new ArgumentException("The specified enum flag is not defined.", nameof(enumFlag));
        }

        if (value.HasFlag(enumFlag))
        {
            throw exception ?? new ArgumentException(message ?? $"Value must not contain the flag '{enumFlag}'.", parameterName);
        }

        return value;
    }
    /// <summary>
    /// Ensures that the specified <paramref name="value"/> is equal to the specified <paramref name="enumValue"/>.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="ensure">The <see cref="IEnsure"/> instance.</param>
    /// <param name="value">The enum value to check.</param>
    /// <param name="enumValue">The enum value to check for equality.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The custom error message to throw if the condition is not met.</param>
    /// <param name="exception">The custom exception to throw if the condition is not met.</param>
    /// <returns>The original <paramref name="value"/> if the condition is met.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the <paramref name="value"/> is not equal to the <paramref name="enumValue"/>.</exception>
    public static TEnum Contains<TEnum>(this IEnsure ensure, TEnum value, TEnum enumValue,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null) where TEnum : struct, Enum
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (!Enum.IsDefined(typeof(TEnum), enumValue))
        {
            throw new ArgumentException("The specified enum value is not defined.", nameof(enumValue));
        }

        if (!EqualityComparer<TEnum>.Default.Equals(value, enumValue))
        {
            throw exception ?? new ArgumentException(message ?? $"Value must be equal to '{enumValue}'.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> is not equal to the specified <paramref name="enumValue"/>.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="ensure">The <see cref="IEnsure"/> instance.</param>
    /// <param name="value">The enum value to check.</param>
    /// <param name="enumValue">The enum value to check for inequality.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The custom error message to throw if the condition is not met.</param>
    /// <param name="exception">The custom exception to throw if the condition is not met.</param>
    /// <returns>The original <paramref name="value"/> if the condition is met.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the <paramref name="value"/> is equal to the <paramref name="enumValue"/>.</exception>
    public static TEnum NotContain<TEnum>(this IEnsure ensure, TEnum value, TEnum enumValue,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null) where TEnum : struct, Enum
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (!Enum.IsDefined(typeof(TEnum), enumValue))
        {
            throw new ArgumentException("The specified enum value is not defined.", nameof(enumValue));
        }

        if (EqualityComparer<TEnum>.Default.Equals(value, enumValue))
        {
            throw exception ?? new ArgumentException(message ?? $"Value must not be equal to '{enumValue}'.", parameterName);
        }

        return value;
    }
}