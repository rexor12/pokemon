using System.Collections.Generic;
using System.Linq;

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
        public static T[] AsArray<T>(this IEnumerable<T> enumerable) =>
            enumerable is T[] array ? array : enumerable.ToArray();
    }
}