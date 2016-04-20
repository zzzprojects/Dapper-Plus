using System;
using System.Collections.Generic;

namespace Z.Dapper.Plus
{
    public partial class DapperPlusActionSet<TEntity>
    {
        /// <summary>INSERT entities in a database table or a view.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="items">items to insert</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> BulkInsert<T>(params T[] items)
        {
            return BulkInsert<T>(null, items);
        }

        /// <summary>INSERT entities in a database table or a view.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="item">The item to insert.</param>
        /// <param name="selectors">The selection of entities to insert.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> BulkInsert<T>(T item, params Func<T, object>[] selectors)
        {
            return BulkInsert(null, item, selectors);
        }

        /// <summary>INSERT entities in a database table or a view.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="items">items to insert.</param>
        /// <param name="selectors">The selection of entities to insert.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> BulkInsert<T>(IEnumerable<T> items, params Func<T, object>[] selectors)
        {
            return BulkInsert(null, items, selectors);
        }

        /// <summary>INSERT entities in a database table or a view.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="items">items to insert.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> BulkInsert<T>(string mapperKey, params T[] items)
        {
            return new DapperPlusActionSet<T>(this, mapperKey, DapperPlusActionKind.Insert, items);
        }

        /// <summary>INSERT entities in a database table or a view.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="item">The item to insert.</param>
        /// <param name="selectors">The selection of entities to insert.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> BulkInsert<T>(string mapperKey, T item, params Func<T, object>[] selectors)
        {
            return new DapperPlusActionSet<T>(this, mapperKey, DapperPlusActionKind.Insert, item, selectors);
        }

        /// <summary>INSERT entities in a database table or a view.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="items">items to insert.</param>
        /// <param name="selectors">The selection of entities to insert.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public DapperPlusActionSet<T> BulkInsert<T>(string mapperKey, IEnumerable<T> items, params Func<T, object>[] selectors)
        {
            return new DapperPlusActionSet<T>(this, mapperKey, DapperPlusActionKind.Insert, items, selectors);
        }
    }
}