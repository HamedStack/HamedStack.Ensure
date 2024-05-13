using System.Runtime.CompilerServices;

// ReSharper disable PossibleMultipleEnumeration

namespace HamedStack.Ensure.Extensions;

public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that the specified <paramref name="value"/> has a minimum length.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The collection to validate.</param>
    /// <param name="minLength">The minimum length allowed for the collection.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if the length of <paramref name="value"/> is less than <paramref name="minLength"/>.</exception>
    public static IEnumerable<T> HasMinLength<T>(this IEnsure ensure, IEnumerable<T> value, int minLength,
         [CallerArgumentExpression(nameof(value))] string? parameterName = null,
         string? message = null,
         Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        int count = Convert.ToInt32(CountElements(value));
        if (count < minLength)
        {
            throw exception ?? new ArgumentException(message ?? $"Length must be at least {minLength}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> has a maximum length.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The collection to validate.</param>
    /// <param name="maxLength">The maximum length allowed for the collection.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if the length of <paramref name="value"/> exceeds <paramref name="maxLength"/>.</exception>
    public static IEnumerable<T> HasMaxLength<T>(this IEnsure ensure, IEnumerable<T> value, int maxLength,
       [CallerArgumentExpression(nameof(value))] string? parameterName = null,
       string? message = null,
       Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        int count = Convert.ToInt32(CountElements(value));
        if (count > maxLength)
        {
            throw exception ?? new ArgumentException(message ?? $"Length must be at most {maxLength}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> has an exact length.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The collection to validate.</param>
    /// <param name="exactLength">The exact length required for the collection.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if the length of <paramref name="value"/> does not match <paramref name="exactLength"/>.</exception>
    public static IEnumerable<T> HasLength<T>(this IEnsure ensure, IEnumerable<T> value, int exactLength,
       [CallerArgumentExpression(nameof(value))] string? parameterName = null,
       string? message = null,
       Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        int count = Convert.ToInt32(CountElements(value));
        if (count != exactLength)
        {
            throw exception ?? new ArgumentException(message ?? $"Length must be exactly {exactLength}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> has a length within a specified range.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The collection to validate.</param>
    /// <param name="minLength">The minimum length allowed for the collection.</param>
    /// <param name="maxLength">The maximum length allowed for the collection.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if the length of <paramref name="value"/> is outside the range defined by <paramref name="minLength"/> and <paramref name="maxLength"/>.</exception>
    public static IEnumerable<T> HasLength<T>(this IEnsure ensure, IEnumerable<T> value, int minLength, int maxLength,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        int count = Convert.ToInt32(CountElements(value));
        if (count < minLength || count > maxLength)
        {
            throw exception ?? new ArgumentException(message ?? $"Length must be between {minLength} and {maxLength}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> has a minimum length.
    /// </summary>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The string to validate.</param>
    /// <param name="minLength">The minimum length allowed for the string.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if the length of <paramref name="value"/> is less than <paramref name="minLength"/>.</exception>
    public static string HasMinLength(this IEnsure ensure, string value, int minLength,
         [CallerArgumentExpression(nameof(value))] string? parameterName = null,
         string? message = null,
         Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value.Length < minLength)
        {
            throw exception ?? new ArgumentException(message ?? $"Length must be at least {minLength}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> has a maximum length.
    /// </summary>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The string to validate.</param>
    /// <param name="maxLength">The maximum length allowed for the string.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if the length of <paramref name="value"/> exceeds <paramref name="maxLength"/>.</exception>
    public static string HasMaxLength(this IEnsure ensure, string value, int maxLength,
          [CallerArgumentExpression(nameof(value))] string? parameterName = null,
          string? message = null,
          Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value.Length > maxLength)
        {
            throw exception ?? new ArgumentException(message ?? $"Length must be at most {maxLength}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> has an exact length.
    /// </summary>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The string to validate.</param>
    /// <param name="exactLength">The exact length required for the string.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if the length of <paramref name="value"/> does not match <paramref name="exactLength"/>.</exception>
    public static string HasLength(this IEnsure ensure, string value, int exactLength,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value.Length != exactLength)
        {
            throw exception ?? new ArgumentException(message ?? $"Length must be exactly {exactLength}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> has a length within a specified range.
    /// </summary>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The string to validate.</param>
    /// <param name="minLength">The minimum length allowed for the string.</param>
    /// <param name="maxLength">The maximum length allowed for the string.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if the length of <paramref name="value"/> is outside the range defined by <paramref name="minLength"/> and <paramref name="maxLength"/>.</exception>
    public static string HasLength(this IEnsure ensure, string value, int minLength, int maxLength,
         [CallerArgumentExpression(nameof(value))] string? parameterName = null,
         string? message = null,
         Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        int length = value.Length;
        if (length < minLength || length > maxLength)
        {
            throw exception ?? new ArgumentException(message ?? $"Length must be between {minLength} and {maxLength}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> has a minimum length.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The collection to validate.</param>
    /// <param name="minLength">The minimum length allowed for the collection.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if the length of <paramref name="value"/> is less than <paramref name="minLength"/>.</exception>
    public static IEnumerable<T> HasMinLength<T>(this IEnsure ensure, IEnumerable<T> value, long minLength,
         [CallerArgumentExpression(nameof(value))] string? parameterName = null,
         string? message = null,
         Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        long count = CountElements(value);
        if (count < minLength)
        {
            throw exception ?? new ArgumentException(message ?? $"Length must be at least {minLength}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> has a maximum length.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The collection to validate.</param>
    /// <param name="maxLength">The maximum length allowed for the collection.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if the length of <paramref name="value"/> exceeds <paramref name="maxLength"/>.</exception>
    public static IEnumerable<T> HasMaxLength<T>(this IEnsure ensure, IEnumerable<T> value, long maxLength,
       [CallerArgumentExpression(nameof(value))] string? parameterName = null,
       string? message = null,
       Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        long count = CountElements(value);
        if (count > maxLength)
        {
            throw exception ?? new ArgumentException(message ?? $"Length must be at most {maxLength}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> has an exact length.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The collection to validate.</param>
    /// <param name="exactLength">The exact length required for the collection.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if the length of <paramref name="value"/> does not match <paramref name="exactLength"/>.</exception>
    public static IEnumerable<T> HasLength<T>(this IEnsure ensure, IEnumerable<T> value, long exactLength,
       [CallerArgumentExpression(nameof(value))] string? parameterName = null,
       string? message = null,
       Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        long count = CountElements(value);
        if (count != exactLength)
        {
            throw exception ?? new ArgumentException(message ?? $"Length must be exactly {exactLength}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> has a length within a specified range.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The collection to validate.</param>
    /// <param name="minLength">The minimum length allowed for the collection.</param>
    /// <param name="maxLength">The maximum length allowed for the collection.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if the length of <paramref name="value"/> is outside the range defined by <paramref name="minLength"/> and <paramref name="maxLength"/>.</exception>
    public static IEnumerable<T> HasLength<T>(this IEnsure ensure, IEnumerable<T> value, long minLength, long maxLength,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        long count = CountElements(value);
        if (count < minLength || count > maxLength)
        {
            throw exception ?? new ArgumentException(message ?? $"Length must be between {minLength} and {maxLength}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> has a minimum length.
    /// </summary>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The string to validate.</param>
    /// <param name="minLength">The minimum length allowed for the string.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if the length of <paramref name="value"/> is less than <paramref name="minLength"/>.</exception>
    public static string HasMinLength(this IEnsure ensure, string value, long minLength,
         [CallerArgumentExpression(nameof(value))] string? parameterName = null,
         string? message = null,
         Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value.Length < minLength)
        {
            throw exception ?? new ArgumentException(message ?? $"Length must be at least {minLength}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> has a maximum length.
    /// </summary>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The string to validate.</param>
    /// <param name="maxLength">The maximum length allowed for the string.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if the length of <paramref name="value"/> exceeds <paramref name="maxLength"/>.</exception>
    public static string HasMaxLength(this IEnsure ensure, string value, long maxLength,
          [CallerArgumentExpression(nameof(value))] string? parameterName = null,
          string? message = null,
          Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value.Length > maxLength)
        {
            throw exception ?? new ArgumentException(message ?? $"Length must be at most {maxLength}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> has an exact length.
    /// </summary>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The string to validate.</param>
    /// <param name="exactLength">The exact length required for the string.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if the length of <paramref name="value"/> does not match <paramref name="exactLength"/>.</exception>
    public static string HasLength(this IEnsure ensure, string value, long exactLength,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (value.Length != exactLength)
        {
            throw exception ?? new ArgumentException(message ?? $"Length must be exactly {exactLength}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the specified <paramref name="value"/> has a length within a specified range.
    /// </summary>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The string to validate.</param>
    /// <param name="minLength">The minimum length allowed for the string.</param>
    /// <param name="maxLength">The maximum length allowed for the string.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if the length of <paramref name="value"/> is outside the range defined by <paramref name="minLength"/> and <paramref name="maxLength"/>.</exception>
    public static string HasLength(this IEnsure ensure, string value, long minLength, long maxLength,
         [CallerArgumentExpression(nameof(value))] string? parameterName = null,
         string? message = null,
         Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        long length = value.Length;
        if (length < minLength || length > maxLength)
        {
            throw exception ?? new ArgumentException(message ?? $"Length must be between {minLength} and {maxLength}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the length of the specified <paramref name="value"/> is at least <paramref name="minLength"/>.
    /// </summary>
    /// <typeparam name="T">The type of the value to validate.</typeparam>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The value to validate.</param>
    /// <param name="lengthSelector">A function to determine the length of the value.</param>
    /// <param name="minLength">The minimum allowed length.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> or <paramref name="lengthSelector"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if the length of <paramref name="value"/> is less than <paramref name="minLength"/>.</exception>
    public static T MinLength<T>(this IEnsure ensure, T value, Func<T, int> lengthSelector, int minLength,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
            throw new ArgumentNullException(nameof(ensure));

        if (lengthSelector is null)
            throw new ArgumentNullException(nameof(lengthSelector));

        int length = lengthSelector(value);

        if (length < minLength)
        {
            throw exception ?? new ArgumentException(message ?? $"Length must be at least {minLength}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the length of the specified <paramref name="value"/> is at most <paramref name="maxLength"/>.
    /// </summary>
    /// <typeparam name="T">The type of the value to validate.</typeparam>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The value to validate.</param>
    /// <param name="lengthSelector">A function to determine the length of the value.</param>
    /// <param name="maxLength">The maximum allowed length.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> or <paramref name="lengthSelector"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if the length of <paramref name="value"/> is more than <paramref name="maxLength"/>.</exception>
    public static T MaxLength<T>(this IEnsure ensure, T value, Func<T, int> lengthSelector, int maxLength,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
            throw new ArgumentNullException(nameof(ensure));

        if (lengthSelector is null)
            throw new ArgumentNullException(nameof(lengthSelector));

        int length = lengthSelector(value);

        if (length > maxLength)
        {
            throw exception ?? new ArgumentException(message ?? $"Length must be at most {maxLength}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the length of the specified <paramref name="value"/> is exactly <paramref name="exactLength"/>.
    /// </summary>
    /// <typeparam name="T">The type of the value to validate.</typeparam>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The value to validate.</param>
    /// <param name="lengthSelector">A function to determine the length of the value.</param>
    /// <param name="exactLength">The exact required length.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> or <paramref name="lengthSelector"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if the length of <paramref name="value"/> is not exactly <paramref name="exactLength"/>.</exception>
    public static T Length<T>(this IEnsure ensure, T value, Func<T, int> lengthSelector, int exactLength,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
            throw new ArgumentNullException(nameof(ensure));

        if (lengthSelector is null)
            throw new ArgumentNullException(nameof(lengthSelector));

        int length = lengthSelector(value);

        if (length != exactLength)
        {
            throw exception ?? new ArgumentException(message ?? $"Length must be exactly {exactLength}.", parameterName);
        }

        return value;
    }
    /// <summary>
    /// Ensures that the length of the specified <paramref name="value"/> is at least <paramref name="minLength"/>.
    /// </summary>
    /// <typeparam name="T">The type of the value to validate.</typeparam>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The value to validate.</param>
    /// <param name="lengthSelector">A function to determine the length of the value.</param>
    /// <param name="minLength">The minimum allowed length.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> or <paramref name="lengthSelector"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if the length of <paramref name="value"/> is less than <paramref name="minLength"/>.</exception>
    public static T MinLength<T>(this IEnsure ensure, T value, Func<T, long> lengthSelector, int minLength,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
            throw new ArgumentNullException(nameof(ensure));

        if (lengthSelector is null)
            throw new ArgumentNullException(nameof(lengthSelector));

        long length = lengthSelector(value);

        if (length < minLength)
        {
            throw exception ?? new ArgumentException(message ?? $"Length must be at least {minLength}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the length of the specified <paramref name="value"/> is at most <paramref name="maxLength"/>.
    /// </summary>
    /// <typeparam name="T">The type of the value to validate.</typeparam>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The value to validate.</param>
    /// <param name="lengthSelector">A function to determine the length of the value.</param>
    /// <param name="maxLength">The maximum allowed length.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> or <paramref name="lengthSelector"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if the length of <paramref name="value"/> is more than <paramref name="maxLength"/>.</exception>
    public static T MaxLength<T>(this IEnsure ensure, T value, Func<T, long> lengthSelector, int maxLength,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
            throw new ArgumentNullException(nameof(ensure));

        if (lengthSelector is null)
            throw new ArgumentNullException(nameof(lengthSelector));

        long length = lengthSelector(value);

        if (length > maxLength)
        {
            throw exception ?? new ArgumentException(message ?? $"Length must be at most {maxLength}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the length of the specified <paramref name="value"/> is exactly <paramref name="exactLength"/>.
    /// </summary>
    /// <typeparam name="T">The type of the value to validate.</typeparam>
    /// <param name="ensure">The instance of <see cref="IEnsure"/> used for validation.</param>
    /// <param name="value">The value to validate.</param>
    /// <param name="lengthSelector">A function to determine the length of the value.</param>
    /// <param name="exactLength">The exact required length.</param>
    /// <param name="parameterName">The name of the parameter being validated.</param>
    /// <param name="message">The custom error message to include in the exception if validation fails. If not provided, a default message is used.</param>
    /// <param name="exception">The custom exception to throw if validation fails. If not provided, an <see cref="ArgumentException"/> is thrown.</param>
    /// <returns>The validated <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="ensure"/> or <paramref name="lengthSelector"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if the length of <paramref name="value"/> is not exactly <paramref name="exactLength"/>.</exception>
    public static T Length<T>(this IEnsure ensure, T value, Func<T, long> lengthSelector, int exactLength,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure is null)
            throw new ArgumentNullException(nameof(ensure));

        if (lengthSelector is null)
            throw new ArgumentNullException(nameof(lengthSelector));

        long length = lengthSelector(value);

        if (length != exactLength)
        {
            throw exception ?? new ArgumentException(message ?? $"Length must be exactly {exactLength}.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Counts the number of elements in the specified collection.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="value">The collection to count.</param>
    /// <returns>The number of elements in the collection.</returns>
    private static long CountElements<T>(IEnumerable<T> value)
    {
        if (value is ICollection<T> collection)
        {
            return collection.Count;
        }
        return value.LongCount();
    }
}