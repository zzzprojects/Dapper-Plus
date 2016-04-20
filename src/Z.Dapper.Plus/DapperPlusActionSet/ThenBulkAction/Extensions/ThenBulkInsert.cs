using System;
using System.Collections.Generic;

namespace Z.Dapper.Plus
{
    public static partial class DapperPlusExtensions
    {
        /// <summary>INSERT entities in a database table or a view using a lambda expression</summary>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="actionSet">The actionSet to act on.</param>
        /// <param name="selectors">The selection of entities to insert.</param>
        /// <returns>An IDapperPlusActionSet&lt;T&gt;</returns>
        public static IDapperPlusActionSet<T> ThenBulkInsert<TEntity, T>(this IDapperPlusActionSet<IEnumerable<TEntity>> actionSet, params Func<TEntity, T>[] selectors)
        {
            return actionSet.ThenBulkInsert(null, selectors);
        }

        /// <summary>INSERT entities in a database table or a view using a lambda expression.</summary>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="actionSet">The actionSet to act on.</param>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="selectors">The selection of entities to insert.</param>
        /// <returns>An IDapperPlusActionSet&lt;T&gt;</returns>
        public static IDapperPlusActionSet<T> ThenBulkInsert<TEntity, T>(this IDapperPlusActionSet<IEnumerable<TEntity>> actionSet, string mapperKey, params Func<TEntity, T>[] selectors)
        {
            return actionSet.CreateDapperAction(mapperKey, DapperPlusActionKind.Insert, selectors);
        }
    }
}