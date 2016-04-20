using System;
using System.Collections.Generic;

namespace Z.Dapper.Plus
{
    public partial class DapperPlusActionSet<TEntity>
    {
        /// <summary>DELETE entities in a database table or a view.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="items">items to delete</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> BulkDelete<T>(params T[] items)
        {
            return BulkDelete<T>(null, items);
        }

        /// <summary>DELETE entities in a database table or a view.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="item">The item to delete.</param>
        /// <param name="selectors">The selection of entities to delete.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> BulkDelete<T>(T item, params Func<T, object>[] selectors)
        {
            return BulkDelete(null, item, selectors);
        }

        /// <summary>DELETE entities in a database table or a view.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="items">items to delete.</param>
        /// <param name="selectors">The selection of entities to delete.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> BulkDelete<T>(IEnumerable<T> items, params Func<T, object>[] selectors)
        {
            return BulkDelete(null, items, selectors);
        }

        /// <summary>DELETE entities in a database table or a view.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="items">items to delete.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> BulkDelete<T>(string mapperKey, params T[] items)
        {
            return new DapperPlusActionSet<T>(this, mapperKey, DapperPlusActionKind.Delete, items);
        }

        /// <summary>DELETE entities in a database table or a view.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="item">The item to delete.</param>
        /// <param name="selectors">The selection of entities to delete.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> BulkDelete<T>(string mapperKey, T item, params Func<T, object>[] selectors)
        {
            return new DapperPlusActionSet<T>(this, mapperKey, DapperPlusActionKind.Delete, item, selectors);
        }

        /// <summary>DELETE entities in a database table or a view.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="items">items to delete.</param>
        /// <param name="selectors">The selection of entities to delete.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> BulkDelete<T>(string mapperKey, IEnumerable<T> items, params Func<T, object>[] selectors)
        {
            return new DapperPlusActionSet<T>(this, mapperKey, DapperPlusActionKind.Delete, items, selectors);
        }
    }
}