using System;
using System.Collections.Generic;

namespace PokemonGame.DataProviders
{
    /// <summary>
    /// Abstract base class for providers.
    /// </summary>
    /// <typeparam name="T">The type of the entities the service provides.</typeparam>
    public abstract class ProviderBase<T> : IProvider<T>
    {
        private readonly Lazy<IReadOnlyDictionary<string, T>> _entities;

        /// <inheritdoc/>
        public IEnumerable<T> AllEntities => _entities.Value.Values;

        /// <summary>
        /// Initializes a new instance of <see cref="ProviderBase"/>.
        /// </summary>
        protected ProviderBase()
        {
            _entities = new Lazy<IReadOnlyDictionary<string, T>>(InitializeEntities);
        }

        /// <inheritdoc/>
        public bool TryGet(string name, out T entity) =>
            _entities.Value.TryGetValue(name, out entity);

        /// <inheritdoc/>
        public T Get(string name) =>
            _entities.Value[name];

        protected abstract IReadOnlyDictionary<string, T> InitializeEntities();
    }
}