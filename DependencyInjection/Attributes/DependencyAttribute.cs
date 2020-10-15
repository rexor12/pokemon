using System;

namespace PokemonGame.DependencyInjection.Attributes
{
    /// <summary>
    /// An attribute for marking a property as a dependency.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class DependencyAttribute : Attribute
    {
    }
}