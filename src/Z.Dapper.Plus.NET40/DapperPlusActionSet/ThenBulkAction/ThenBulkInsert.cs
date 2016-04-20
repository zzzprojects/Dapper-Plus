using System;

namespace Z.Dapper.Plus
{
    public partial class DapperPlusActionSet<TEntity>
    {
        /// <summary>INSERT entities in a database table or a view using a lambda expression</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="selectors">The selection of entities to insert.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> ThenBulkInsert<T>(params Func<TEntity, T>[] selectors)
        {
            return ThenBulkInsert(null, selectors);
        }

        /// <summary>INSERT entities in a database table or a view using a lambda expression.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="selectors">The selection of entities to insert.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> ThenBulkInsert<T>(string mapperKey, params Func<TEntity, T>[] selectors)
        {
            return CreateDapperAction<T>(mapperKey, DapperPlusActionKind.Insert, selectors);
        }
    }
}