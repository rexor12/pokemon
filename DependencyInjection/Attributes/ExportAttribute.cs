using System;

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
        public ExportAttribute(Type exportType)
        {
            ExportType = exportType;
        }
    }
}