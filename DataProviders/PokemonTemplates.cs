using System;
using System.Collections.Generic;
using System.Linq;
using PokemonGame.DependencyInjection.Attributes;
using PokemonGame.Models;

namespace PokemonGame.DataProviders
{
    /// <summary>
    /// Provides access to Pokémon templates.
    /// </summary>
    [Export(typeof(IPokemonTemplates))]
    public sealed class PokemonTemplates : ProviderBase<PokemonTemplate>, IPokemonTemplates
    {
        /// <inheritdoc/>
        protected override IReadOnlyDictionary<string, PokemonTemplate> InitializeEntities() => new[]
        {
            new PokemonTemplate { Name = "Bulbasaur", Attack = 27, Health = 352, Skills = new[] { "Tackle", "Vine Whip", "Razor Leaf" } },
            new PokemonTemplate { Name = "Charmander", Attack = 30, Health = 311, Skills = new[] { "Scratch", "Ember", "Fire Fang" } },
            new PokemonTemplate { Name = "Squirtle", Attack = 21, Health = 289, Skills = new[] { "Tackle", "Water Gun", "Water Pulse" } }
        }.ToDictionary(template => template.Name, template => template, StringComparer.OrdinalIgnoreCase);
    }
}