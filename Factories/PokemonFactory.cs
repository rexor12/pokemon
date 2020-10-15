using PokemonGame.Utilities;
using PokemonGame.DataProviders;
using PokemonGame.DependencyInjection.Attributes;
using PokemonGame.Models;

namespace PokemonGame
{
    /// <summary>
    /// A factory used to create new instances of <see cref="Pokemon"/>.
    /// </summary>
    [Export(typeof(IPokemonFactory))]
    public class PokemonFactory : IPokemonFactory
    {
        /// <summary>
        /// Gets or sets the instance of <see cref="IRandomNumberGenerator"/>
        /// used for generating random numbers.
        /// </summary>
        [Dependency]
        public IRandomNumberGenerator RandomNumberGenerator { get; set; }

        /// <inheritdoc/>
        public Pokemon CreateFrom(PokemonTemplate pokemonTemplate)
        {
            ExceptionHelper.ThrowIfNull(nameof(pokemonTemplate), pokemonTemplate);

            return new Pokemon(pokemonTemplate.Name)
            {
                Attack = pokemonTemplate.Attack,
                Health = (int)(pokemonTemplate.Health * RandomNumberGenerator.NextDouble(1d, 1.1d))
            };
        }
    }
}