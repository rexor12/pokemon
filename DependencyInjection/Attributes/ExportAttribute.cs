using System;
using PokemonGame.Utilities;

namespace PokemonGame.DependencyInjection.Attributes
{
    /// <summary>
    /// An attribute for marking a class as an exported part.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class ExportAttribute : Attribute
    {
        /// <summary>
        /// Gets the type the exported part satisfies.
        /// </summary>
        public Type ExportType { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="ExportAttribute"/>.
        /// </summary>
        /// <param name="exportType">The <see cref="Type"/> the exported part satisfies.</param>
        /// <exception cref="ArgumentNullException">Thrown when a mandatory argument is <c>null</c>.</exception>
        public ExportAttribute(Type exportType)
        {
            ExceptionHelper.ThrowIfNull(nameof(exportType), exportType);

            ExportType = exportType;
        }
    }
}