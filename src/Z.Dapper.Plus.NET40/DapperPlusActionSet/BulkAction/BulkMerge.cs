using System;
using System.Collections.Generic;

namespace Z.Dapper.Plus
{
    public partial class DapperPlusActionSet<TEntity>
    {
        /// <summary>MERGE (Upsert) entities in a database table or a view.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="items">items to merge</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> BulkMerge<T>(params T[] items)
        {
            return BulkMerge<T>(null, items);
        }

        /// <summary>MERGE (Upsert) entities in a database table or a view.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="item">The item to merge.</param>
        /// <param name="selectors">The selection of entities to merge.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> BulkMerge<T>(T item, params Func<T, object>[] selectors)
        {
            return BulkMerge(null, item, selectors);
        }

        /// <summary>MERGE (Upsert) entities in a database table or a view.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="items">items to merge.</param>
        /// <param name="selectors">The selection of entities to merge.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> BulkMerge<T>(IEnumerable<T> items, params Func<T, object>[] selectors)
        {
            return BulkMerge(null, items, selectors);
        }

        /// <summary>MERGE (Upsert) entities in a database table or a view.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="items">items to merge.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> BulkMerge<T>(string mapperKey, params T[] items)
        {
            return new DapperPlusActionSet<T>(this, mapperKey, DapperPlusActionKind.Merge, items);
        }

        /// <summary>MERGE (Upsert) entities in a database table or a view.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="item">The item to merge.</param>
        /// <param name="selectors">The selection of entities to merge.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> BulkMerge<T>(string mapperKey, T item, params Func<T, object>[] selectors)
        {
            return new DapperPlusActionSet<T>(this, mapperKey, DapperPlusActionKind.Merge, item, selectors);
        }

        /// <summary>MERGE (Upsert) entities in a database table or a view.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="items">items to merge.</param>
        /// <param name="selectors">The selection of entities to merge.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> BulkMerge<T>(string mapperKey, IEnumerable<T> items, params Func<T, object>[] selectors)
        {
            return new DapperPlusActionSet<T>(this, mapperKey, DapperPlusActionKind.Merge, items, selectors);
        }
    }
}