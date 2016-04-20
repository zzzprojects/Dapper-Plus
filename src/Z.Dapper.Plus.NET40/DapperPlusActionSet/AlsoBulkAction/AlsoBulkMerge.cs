using System;

namespace Z.Dapper.Plus
{
    public partial class DapperPlusActionSet<TEntity>
    {
        /// <summary>MERGE (Upsert) entities in a database table or a view using a lambda expression</summary>
        /// <param name="selectors">The selection of entities to merge.</param>
        /// <returns>A DapperPlusActionSet&lt;TEntity&gt;</returns>
        public DapperPlusActionSet<TEntity> AlsoBulkMerge(params Func<TEntity, object>[] selectors)
        {
            return AlsoBulkMerge(null, selectors);
        }

        /// <summary>MERGE (Upsert) entities in a database table or a view using a lambda expression</summary>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="selectors">The selection of entities to merge.</param>
        /// <returns>A DapperPlusActionSet&lt;TEntity&gt;</returns>
        public DapperPlusActionSet<TEntity> AlsoBulkMerge(string mapperKey, params Func<TEntity, object>[] selectors)
        {
            AddAction(mapperKey, DapperPlusActionKind.Merge, selectors);
            return this;
        }
    }
}