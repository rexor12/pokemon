using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PokemonGame.DependencyInjection.Attributes;

namespace PokemonGame.DependencyInjection.Catalogs
{
    /// <summary>
    /// Provides access to exports provided by a specific assembly.
    /// </summary>
    public sealed class AssemblyExportCatalog : ExportCatalog
    {
        /// <summary>
        /// Initializes a new instance of <see cref="AssemblyExportCatalog"/>.
        /// </summary>
        /// <param name="assembly">The <see cref="Assembly"/> from which to get the exported parts.</param>
        public AssemblyExportCatalog(Assembly assembly)
            : base(GetExports(assembly))
        {
        }

        private static IEnumerable<Type> GetExports(Assembly assembly) => assembly
            .GetTypes()
            .Where(type => type.GetCustomAttribute<ExportAttribute>(true) != null);
    }
}