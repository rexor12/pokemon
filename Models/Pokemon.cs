using PokemonGame.Utilities;

namespace PokemonGame.Models
{
    /// <summary>
    /// Represents a spawned Pokémon.
    /// </summary>
    public sealed class Pokemon
    {
        private int _health = 100;

        /// <summary>
        /// Gets or sets the attack power.
        /// </summary>
        public int Attack { get; set; }

        /// <summary>
        /// Gets or sets the current health.
        /// </summary>
        public int Health
        {
            get => _health;
            set => _health = value > 0 ? value : 0;
        }

        /// <summary>
        /// Gets or sets the name that uniquely identifies the Pokémon.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="Pokemon"/>.
        /// </summary>
        /// <param name="name">The name that uniquely identifies the Pokémon.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when a mandatory argument is <c>null</c> or consists of white-space characters only.
        /// </exception>
        public Pokemon(string name)
        {
            ExceptionHelper.ThrowIfNullOrWhiteSpace(nameof(name), name);

            Name = name;
        }
    }
}