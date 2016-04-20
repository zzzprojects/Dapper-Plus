using System;

namespace Z.Dapper.Plus
{
    public partial class DapperPlusActionSet<TEntity>
    {
        /// <summary>UPDATE entities in a database table or a view using a lambda expression</summary>
        /// <param name="selectors">The selection of entities to update.</param>
        /// <returns>A DapperPlusActionSet&lt;TEntity&gt;</returns>
        public DapperPlusActionSet<TEntity> AlsoBulkUpdate(params Func<TEntity, object>[] selectors)
        {
            return AlsoBulkUpdate(null, selectors);
        }

        /// <summary>UPDATE entities in a database table or a view using a lambda expression.</summary>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="selectors">The selection of entities to update.</param>
        /// <returns>A DapperPlusActionSet&lt;TEntity&gt;</returns>
        public DapperPlusActionSet<TEntity> AlsoBulkUpdate(string mapperKey, params Func<TEntity, object>[] selectors)
        {
            AddAction(mapperKey, DapperPlusActionKind.Update, selectors);
            return this;
        }
    }
}