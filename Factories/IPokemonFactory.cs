using PokemonGame.Models;

namespace PokemonGame
{
    /// <summary>
    /// Interface for a factory used to create new instances of <see cref="Pokemon"/>.
    /// </summary>
    public interface IPokemonFactory
    {
        /// <summary>
        /// Creates a new instance of <see cref="Pokemon"/> from the specified template.
        /// </summary>
        /// <param name="pokemonTemplate">The <see cref="PokemonTemplate"/> to create the Pokémon from.</param>
        /// <returns>A new instance of <see cref="Pokemon"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a mandatory argument is <c>null</c>.</exception>
        Pokemon CreateFrom(PokemonTemplate pokemonTemplate);
    }
}