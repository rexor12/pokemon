using System.Collections.Generic;
using System.Linq;
using PokemonGame.DependencyInjection.Attributes;
using PokemonGame.Models;

namespace PokemonGame.DataProviders
{
    /// <summary>
    /// Provides access to skills.
    /// </summary>
    [Export(typeof(ISkills))]
    public sealed class Skills : ProviderBase<Skill>, ISkills
    {
        /// <inheritdoc/>
        protected override IReadOnlyDictionary<string, Skill> InitializeEntities() => new[]
        {
            new Skill { Name = "Tackle", Attack = 40 },
            new Skill { Name = "Vine Whip", Attack = 45 },
            new Skill { Name = "Razor Leaf", Attack = 55 },
            new Skill { Name = "Scratch", Attack = 40 },
            new Skill { Name = "Ember", Attack = 40 },
            new Skill { Name = "Fire Fang", Attack = 65 },
            new Skill { Name = "Water Gun", Attack = 40 },
            new Skill { Name = "Water Pulse", Attack = 60 },
        }.ToDictionary(skill => skill.Name, skill => skill);
    }
}