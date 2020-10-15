using System;
using PokemonGame.DependencyInjection.Attributes;

namespace PokemonGame.DataProviders
{
    /// <summary>
    /// Default implementation of a random number generator.
    /// </summary>
    [Export(typeof(IRandomNumberGenerator))]
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private readonly Random _random = new Random();

        /// <inheritdoc/>
        public double NextDouble(double min = 0, double max = 1) =>
            _random.NextDouble() * (max - min) + min;

        /// <inheritdoc/>
        public int NextInteger(int min = 0, int max = 10) =>
            _random.Next(min, max);
    }
}