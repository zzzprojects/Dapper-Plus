using System;
using System.Collections.Generic;

namespace Z.Dapper.Plus
{
    public partial class DapperPlusActionSet<TEntity>
    {
        /// <summary>UPDATE entities in a database table or a view.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="items">items to update</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> BulkUpdate<T>(params T[] items)
        {
            return BulkUpdate<T>(null, items);
        }

        /// <summary>UPDATE entities in a database table or a view.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="item">The item to update.</param>
        /// <param name="selectors">The selection of entities to update.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> BulkUpdate<T>(T item, params Func<T, object>[] selectors)
        {
            return BulkUpdate(null, item, selectors);
        }

        /// <summary>UPDATE entities in a database table or a view.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="items">items to update.</param>
        /// <param name="selectors">The selection of entities to update.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> BulkUpdate<T>(IEnumerable<T> items, params Func<T, object>[] selectors)
        {
            return BulkUpdate(null, items, selectors);
        }

        /// <summary>UPDATE entities in a database table or a view.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="items">items to update.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> BulkUpdate<T>(string mapperKey, params T[] items)
        {
            return new DapperPlusActionSet<T>(this, mapperKey, DapperPlusActionKind.Update, items);
        }

        /// <summary>UPDATE entities in a database table or a view.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="item">The item to update.</param>
        /// <param name="selectors">The selection of entities to update.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> BulkUpdate<T>(string mapperKey, T item, params Func<T, object>[] selectors)
        {
            return new DapperPlusActionSet<T>(this, mapperKey, DapperPlusActionKind.Update, item, selectors);
        }

        /// <summary>UPDATE entities in a database table or a view.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="items">items to update.</param>
        /// <param name="selectors">The selection of entities to update.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> BulkUpdate<T>(string mapperKey, IEnumerable<T> items, params Func<T, object>[] selectors)
        {
            return new DapperPlusActionSet<T>(this, mapperKey, DapperPlusActionKind.Update, items, selectors);
        }
    }
}