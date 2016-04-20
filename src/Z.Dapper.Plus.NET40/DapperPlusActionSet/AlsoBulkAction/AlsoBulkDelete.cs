using System;

namespace Z.Dapper.Plus
{
    public partial class DapperPlusActionSet<TEntity>
    {
        /// <summary>DELETE entities in a database table or a view using a lambda expression</summary>
        /// <param name="selectors">The selection of entities to delete.</param>
        /// <returns>A DapperPlusActionSet&lt;TEntity&gt;</returns>
        public DapperPlusActionSet<TEntity> AlsoBulkDelete(params Func<TEntity, object>[] selectors)
        {
            return AlsoBulkDelete(null, selectors);
        }

        /// <summary>DELETE entities in a database table or a view using a lambda expression.</summary>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="selectors">The selection of entities to delete.</param>
        /// <returns>A DapperPlusActionSet&lt;TEntity&gt;</returns>
        public DapperPlusActionSet<TEntity> AlsoBulkDelete(string mapperKey, params Func<TEntity, object>[] selectors)
        {
            AddAction(mapperKey, DapperPlusActionKind.Delete, selectors);
            return this;
        }
    }
}