using System;
using System.Collections.Generic;

namespace PokemonGame.DataProviders
{
    /// <summary>
    /// Interface for a service that provides entities of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of entities the service provides.</typeparam>
    public interface IProvider<T>
    {
        /// <summary>
        /// Gets an enumerable of all entities.
        /// </summary>
        IEnumerable<T> AllEntities { get; }

        /// <summary>
        /// Tries to get the entity identified by the specified name.
        /// </summary>
        /// <param name="name">The name that uniquely identifies the entity.</param>
        /// <param name="entity">If found, the entity.</param>
        bool TryGet(string name, out T entity);

        /// <summary>
        /// Gets the entity identified by the specified name.
        /// </summary>
        /// <param name="name">The name that uniquely identifies the entity.</param>
        /// <returns>The entity identified by the specified name.</returns>
        T Get(string name);
    }
}