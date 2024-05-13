using System.Runtime.CompilerServices;

namespace HamedStack.Ensure.Extensions;

public static partial class EnsureExtensions
{
    private static readonly DateTime MinSqlDate = new(1753, 1, 1);
    private static readonly DateTime MaxSqlDate = new(9999, 12, 31);

    /// <summary>
    /// Ensures that the provided <see cref="DateTime"/> value falls within the SQL Server-supported date range (January 1, 1753, to December 31, 9999).
    /// </summary>
    /// <param name="ensure">The <see cref="IEnsure"/> instance used for ensuring conditions.</param>
    /// <param name="value">The <see cref="DateTime"/> value to check against the SQL Server-supported date range.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="message">The message to include in the exception if the condition is not met. Defaults to "Value is outside the SQL Server-supported date range."</param>
    /// <param name="exception">The exception to throw if the condition is not met. Defaults to <see cref="ArgumentException"/>.</param>
    /// <returns>The original <see cref="DateTime"/> value if it falls within the SQL Server-supported date range.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is outside the SQL Server-supported date range.</exception>
    public static DateTime IsInSqlDateRange(this IEnsure ensure, DateTime value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null,
        Exception? exception = null)
    {
        if (ensure == null) throw new ArgumentNullException(nameof(ensure));
        if (value < MinSqlDate || value > MaxSqlDate)
        {
            throw exception ?? new ArgumentException(message ?? "Value is outside the SQL Server-supported date range.", parameterName);
        }

        return value;
    }
}