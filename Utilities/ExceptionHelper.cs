using System;

namespace PokemonGame.Utilities
{
    /// <summary>
    /// Provides methods for throwing exceptions conditionally.
    /// </summary>
    public static class ExceptionHelper
    {
        /// <summary>
        /// Throws a new <see cref="ArgumentNullException"/>
        /// if the given <paramref name="value"/>
        /// of the argument with the given <paramref name="name"/>
        /// is null.
        /// </summary>
        /// <param name="name">The name of the argument.</param>
        /// <param name="value">The value of the argument.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the argument's value is null.
        /// </exception>
        public static void ThrowIfNull(string name, object value)
        {
            if (value != null) return;

            throw new ArgumentNullException(name, "Argument cannot be null.");
        }

        /// <summary>
        /// Throws a new <see cref="ArgumentException"/>
        /// if the given <paramref name="value"/>
        /// of the argument with the given <paramref name="name"/>
        /// is null or contains white-space characters only.
        /// </summary>
        /// <param name="name">The name of the argument.</param>
        /// <param name="value">The value of the argument.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the argument's value is null or consists of white-space characters only.
        /// </exception>
        public static void ThrowIfNullOrWhiteSpace(string name, string value)
        {
            if (!string.IsNullOrWhiteSpace(value)) return;

            throw new ArgumentException("Argument cannot be null or contain white-space characters only.", name);
        }
    }
}