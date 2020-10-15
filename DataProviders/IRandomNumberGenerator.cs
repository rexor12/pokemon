namespace PokemonGame.DataProviders
{
    /// <summary>
    /// Interface for a random number generator.
    /// </summary>
    public interface IRandomNumberGenerator
    {
        /// <summary>
        /// Gets a random double-precision floating-point number from the specified range.
        /// </summary>
        /// <param name="min">The minimum value, inclusive.</param>
        /// <param name="max">The maximum value, exclusive.</param>
        /// <returns>A random double-precision floating-point number from the specified range.</returns>
        double NextDouble(double min = 0, double max = 1);

        /// <summary>
        /// Gets a random integer from the specified range.
        /// </summary>
        /// <param name="min">The minimum value, inclusive.</param>
        /// <param name="max">The maximum value, exclusive.</param>
        /// <returns>A random integer from the specified range.</returns>
        int NextInteger(int min = 0, int max = int.MaxValue);
    }
}