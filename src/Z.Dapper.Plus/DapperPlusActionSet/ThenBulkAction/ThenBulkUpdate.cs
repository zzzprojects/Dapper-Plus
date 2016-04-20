using System;

namespace Z.Dapper.Plus
{
    public partial class DapperPlusActionSet<TEntity>
    {
        /// <summary>UPDATE entities in a database table or a view using a lambda expression</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="selectors">The selection of entities to update.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> ThenBulkUpdate<T>(params Func<TEntity, T>[] selectors)
        {
            return ThenBulkUpdate(null, selectors);
        }

        /// <summary>UPDATE entities in a database table or a view using a lambda expression.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="selectors">The selection of entities to update.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> ThenBulkUpdate<T>(string mapperKey, params Func<TEntity, T>[] selectors)
        {
            return CreateDapperAction<T>(mapperKey, DapperPlusActionKind.Update, selectors);
        }
    }
}