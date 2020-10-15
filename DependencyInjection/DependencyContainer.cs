using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using PokemonGame.DependencyInjection.Attributes;
using PokemonGame.DependencyInjection.Catalogs;

namespace PokemonGame.DependencyInjection
{
    /// <summary>
    /// Handles the resolution of dependencies.
    /// </summary>
    public sealed class DependencyContainer : IDisposable
    {
        private int _isDisposed;

        private readonly IDictionary<Type, object> _dependencies = new Dictionary<Type, object>();

        /// <summary>
        /// Resolves the dependencies of the given <paramref name="instance"/>.
        /// </summary>
        /// <param name="instance">The instance of <typeparamref name="T"/> to resolve.</param>
        /// <param name="dependableCatalog">The <see cref="ExportCatalog"/> that provides the exported parts.</param>
        /// <typeparam name="T">The type of the object to resolve.</typeparam>
        public void Resolve<T>(T instance, ExportCatalog dependableCatalog)
            where T : class
        {
            if (_isDisposed == 1)
            {
                throw new ObjectDisposedException(nameof(DependencyContainer));
            }

            Resolve((object)instance, dependableCatalog);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (Interlocked.CompareExchange(ref _isDisposed, 1, 0) == 1)
            {
                throw new ObjectDisposedException(nameof(DependencyContainer));
            }

            foreach (var dependable in _dependencies.Values)
            {
                if (dependable is IDisposable disposable)
                {
                    Console.WriteLine($"[Debug] Disposing service `{disposable.GetType().Name}`...");
                    disposable.Dispose();
                }
            }
        }

        private static IEnumerable<PropertyInfo> GetResolvableProperties(Type type) => type
            .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Select(propertyInfo =>
            (
                PropertyInfo: propertyInfo,
                Attribute: propertyInfo.GetCustomAttributes<DependencyAttribute>(true).SingleOrDefault()
            ))
            .Where(tuple => tuple.Attribute != null)
            .Select(tuple => tuple.PropertyInfo);

        private void Resolve(object instance, ExportCatalog dependableCatalog)
        {
            Console.WriteLine($"[Debug] Resolving dependencies... {new { Type = instance.GetType().Name }}");
            foreach (var propertyInfo in GetResolvableProperties(instance.GetType()))
            {
                var resolvedDependency = ResolveDependency(propertyInfo.PropertyType, dependableCatalog);
                propertyInfo.SetValue(instance, resolvedDependency);
            }
            Console.WriteLine($"[Debug] Successfully resolved dependencies. {new { Type = instance.GetType().Name }}");
        }

        private object ResolveDependency(Type dependencyType, ExportCatalog exportCatalog)
        {
            if (_dependencies.TryGetValue(dependencyType, out var dependable))
            {
                return dependable;
            }

            var dependableType = exportCatalog.Get(dependencyType);
            if (dependableType == null)
            {
                // TODO Specific type of exception.
                throw new Exception($"Dependable for dependency type '{dependencyType.Name}' cannot be found.");
            }

            dependable = Activator.CreateInstance(dependableType);
            Resolve(dependable, exportCatalog);
            return dependable;
        }
    }
}