// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

using System.Runtime.CompilerServices;

namespace HamedStack.Ensure;

public static partial class EnsureExtensions
{
    /// <summary>
    /// Ensures that the date falls within the specified SQL-style date range inclusively.
    /// </summary>
    /// <typeparam name="T">The type of the date value.</typeparam>
    /// <param name="date">The date value to check.</param>
    /// <param name="paramName">The name of the parameter to include in the exception message.</param>
    /// <param name="exceptionCreator">A delegate that creates an exception if the date is outside the range.</param>
    /// <returns>The original date value if it falls within the specified SQL-style date range.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the date value is outside the specified SQL-style date range.
    /// </exception>
    public static T EnsureSqlDateRange<T>(
        this T date,
        [CallerArgumentExpression("date")] string? paramName = null,
        Func<string, Exception>? exceptionCreator = null
    ) where T : IComparable, IComparable<T>, IEquatable<T>
    {
        // Define custom SQL-style minimum and maximum date ticks
        const long sqlMinDateTicks = 552877920000000000;
        const long sqlMaxDateTicks = 3155378975999970000;
        var dateTicks = date switch
        {
            DateTime dateTime => dateTime.Ticks,
            DateTimeOffset dateTimeOffset => dateTimeOffset.Ticks,
            _ => throw new ArgumentException("Unsupported date type.", paramName ?? nameof(date))
        };

        if (dateTicks is >= sqlMinDateTicks and <= sqlMaxDateTicks)
        {
            return date;
        }

        var exception = exceptionCreator?.Invoke(paramName ?? nameof(date));
        if (exception != null)
        {
            throw exception;
        }

        throw new ArgumentOutOfRangeException(
            paramName ?? nameof(date),
            $"Date must fall within the SQL-style date range: [{new DateTime(sqlMinDateTicks):yyyy-MM-dd}] to [{new DateTime(sqlMaxDateTicks):yyyy-MM-dd}].");
    }
}