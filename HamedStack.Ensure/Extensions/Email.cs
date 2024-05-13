using System.Net.Mail;
using System.Runtime.CompilerServices;

namespace HamedStack.Ensure.Extensions;

public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that an email address is in a valid format.
    /// </summary>
    /// <param name="ensure">The guard instance for fluent validation.</param>
    /// <param name="email">The email address to be validated.</param>
    /// <param name="parameterName">The name of the parameter being validated. Automatically provided using <see cref="CallerArgumentExpressionAttribute"/>.</param>
    /// <param name="message">Optional error message to provide more context in the exception.</param>
    /// <param name="exception">Optional custom exception to throw instead of <see cref="ArgumentException"/>.</param>
    /// <exception cref="ArgumentException">Thrown if the email address is not in a valid format.</exception>
    /// <returns>The validated <paramref name="email"/> if it is in a valid format.</returns>
    public static string IsEmail(this IEnsure ensure, string email, [CallerArgumentExpression(nameof(email))] string? parameterName = null, string? message = null, Exception? exception = null)
    {
        if (ensure is null)
        {
            throw new ArgumentNullException(nameof(ensure));
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentNullException(parameterName, "Email address cannot be null or empty.");
        }

        try
        {
            _ = new MailAddress(email);
        }
        catch (FormatException)
        {
            throw exception ?? new ArgumentException(message ?? $"The email address '{parameterName}' is not in a valid format.", parameterName);
        }

        return email;
    }
}