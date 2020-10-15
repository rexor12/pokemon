using System.Collections.Generic;

namespace PokemonGame.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="string"/>.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Concatenates the members of a constructed <see cref="IEnumerable{T}"/> collection of type <c>string</c>,
        /// using the specified separator between each member.
        /// </summary>
        /// <param name="values">
        /// A collection that contains the strings to concatenate.
        /// </param>
        /// <param name="separator">
        /// The string to use as a separator which is included in the returned string
        /// only if values has more than one element.
        /// </param>
        /// <returns>
        /// A string that consists of the members of <paramref name="values"/>
        /// delimited by the <paramref name="separator"/> string;
        /// or <see cref="string.Empty"/> if <paramref name="values"/> has zero elements
        /// or all the elements of values are <c>null</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when a mandatory argument is <c>null</c>.</exception>
        public static string Join(this IEnumerable<string> values, string separator) =>
            string.Join(separator, values);
    }
}