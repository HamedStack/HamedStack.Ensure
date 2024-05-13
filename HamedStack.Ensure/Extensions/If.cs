using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HamedStack.Ensure.Extensions
{
    public static partial class EnsureExtensions
    {
        /// <summary>
        /// Throws an exception if the specified condition is met.
        /// </summary>
        /// <typeparam name="T">The type of the value to check.</typeparam>
        /// <param name="ensure">The <see cref="IEnsure"/> instance.</param>
        /// <param name="value">The value to check against the condition.</param>
        /// <param name="predicate">The condition that triggers the throw.</param>
        /// <param name="parameterName">The name of the parameter being checked.</param>
        /// <param name="message">The custom error message to throw if the condition is met.</param>
        /// <param name="exception">The custom exception to throw if the condition is met. If null, a default exception is thrown.</param>
        /// <returns>The original <paramref name="value"/> if the condition is not met.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="ensure"/> or <paramref name="predicate"/> is null.</exception>
        /// <exception cref="Exception">A custom exception or a default <see cref="ArgumentException"/> if the condition is met.</exception>
        public static T If<T>(this IEnsure ensure, T value, Func<T, bool> predicate,
            [CallerArgumentExpression(nameof(value))] string? parameterName = null,
            string? message = null,
            Exception? exception = null)
        {
            if (ensure == null)
                throw new ArgumentNullException(nameof(ensure));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            if (predicate(value))
            {
                throw exception ?? new ArgumentException(message ?? $"Condition failed for '{parameterName}'.", parameterName);
            }

            return value;
        }
    }
}
