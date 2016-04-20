using System;

namespace Z.Dapper.Plus
{
    public partial class DapperPlusActionSet<TEntity>
    {
        /// <summary>INSERT entities in a database table or a view using a lambda expression</summary>
        /// <param name="selectors">The selection of entities to insert.</param>
        /// <returns>A DapperPlusActionSet&lt;TEntity&gt;</returns>
        public DapperPlusActionSet<TEntity> AlsoBulkInsert(params Func<TEntity, object>[] selectors)
        {
            return AlsoBulkInsert(null, selectors);
        }

        /// <summary>INSERT entities in a database table or a view using a lambda expression.</summary>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="selectors">The selection of entities to insert.</param>
        /// <returns>A DapperPlusActionSet&lt;TEntity&gt;</returns>
        public DapperPlusActionSet<TEntity> AlsoBulkInsert(string mapperKey, params Func<TEntity, object>[] selectors)
        {
            AddAction(mapperKey, DapperPlusActionKind.Insert, selectors);
            return this;
        }
    }
}