using System;

namespace PokemonGame.Models
{
    /// <summary>
    /// Templates used for spawning Pokémons.
    /// </summary>
    /// <remarks>Ideally, these templates may come from configuration.</remarks>
    public sealed class PokemonTemplate
    {
        /// <summary>
        /// Gets or sets the name of the Pokémon that uniquely identifies it.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the base health points of the Pokémon.
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// Gets or sets the base attack power of the Pokémon.
        /// </summary>
        public int Attack { get; set; }

        /// <summary>
        /// Gets or sets an array of the possessed skill names.
        /// </summary>
        public string[] Skills { get; set; } = Array.Empty<string>();
    }
}