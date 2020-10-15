namespace PokemonGame.Models
{
    /// <summary>
    /// Represents a Pokémon skill.
    /// </summary>
    /// /// <remarks>Ideally, these skills may come from configuration.</remarks>
    public sealed class Skill
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the attack power.
        /// </summary>
        public int Attack { get; set; }
    }
}