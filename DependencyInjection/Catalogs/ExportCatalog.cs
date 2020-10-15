using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PokemonGame.DependencyInjection.Attributes;

namespace PokemonGame.DependencyInjection.Catalogs
{
    /// <summary>
    /// Provides access to a specific set of exports.
    /// </summary>
    public class ExportCatalog
    {
        private readonly Lazy<IReadOnlyDictionary<Type, Type>> _exports;

        /// <summary>
        /// Initializes a new instance of <see cref="ExportCatalog"/>.
        /// </summary>
        /// <param name="exportedParts">An enumerable of <see cref="Type"/> instances that provide exports.</param>
        public ExportCatalog(IEnumerable<Type> exportedParts)
        {
            _exports = new Lazy<IReadOnlyDictionary<Type, Type>>(() => InitializeExports(exportedParts));
        }

        /// <summary>
        /// Gets the type of the exported part for the specified export type.
        /// </summary>
        /// <param name="exportType">The <see cref="Type"/> for which to get the exported part type.</param>
        /// <returns>If exists, the exported part type; otherwise, <c>null</c>.</returns>
        public Type Get(Type exportType) =>
            _exports.Value.TryGetValue(exportType, out var export)
                ? export
                : null;

        private static IReadOnlyDictionary<Type, Type> InitializeExports(IEnumerable<Type> exports) =>
            exports.ToDictionary(GetExportType, exportType => exportType);

        private static Type GetExportType(Type dependableType) =>
            dependableType.GetCustomAttributes<ExportAttribute>(true).SingleOrDefault()?.ExportType;
    }
}