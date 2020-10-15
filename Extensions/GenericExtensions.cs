using System;
using System.Collections.Generic;
using System.Linq;
using PokemonGame.Utilities;

namespace PokemonGame.Extensions
{
    /// <summary>
    /// Extension methods for generic types.
    /// </summary>
    public static class GenericExtensions
    {
        /// <summary>
        /// Converts the specified enumerable to an array.
        /// </summary>
        /// <param name="enumerable">The <see cref="IEnumerable{T}"/> to be converted.</param>
        /// <typeparam name="T">The type of the items in the sequence.</typeparam>
        /// <returns>If already an array, the same instance; otherwise, a new array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a mandatory argument is <c>null</c>.</exception>
        public static T[] AsArray<T>(this IEnumerable<T> enumerable)
        {
            ExceptionHelper.ThrowIfNull(nameof(enumerable), enumerable);

            return enumerable is T[] array ? array : enumerable.ToArray();
        }

        /// <summary>
        /// Concatenates the members of a constructed <see cref="IEnumerable{T}"/> collection of type <c>string</c>,
        /// using the specified separator between each member.
        /// </summary>
        /// <param name="values">
        /// A collection that contains the items to concatenate.
        /// </param>
        /// <param name="selector">
        /// The <see cref="Func{T, TResult}"/> that determines the transformation
        /// of the collection items.
        /// </param>
        /// <param name="separator">
        /// The string to use as a separator which is included in the returned string
        /// only if values has more than one element.
        /// </param>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <returns>
        /// A string that consists of the members of <paramref name="values"/>
        /// delimited by the <paramref name="separator"/> string;
        /// or <see cref="string.Empty"/> if <paramref name="values"/> has zero elements
        /// or all the elements of values are <c>null</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when a mandatory argument is <c>null</c>.</exception>
        public static string Join<T>(this IEnumerable<T> values, Func<T, string> selector, string separator) =>
            values.Select(selector).Join(separator);
    }
}