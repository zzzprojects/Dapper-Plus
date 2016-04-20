using System;
using System.Collections.Generic;
using System.Data;

namespace Z.Dapper.Plus
{
    public static partial class DapperPlusExtensions
    {
        /// <summary>
        ///     An IDbConnection extension method to INSERT entities in a database table or a view.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="connection">The connection to act on.</param>
        /// <param name="items">items to insert.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public static DapperPlusActionSet<T> BulkInsert<T>(this IDbConnection connection, params T[] items)
        {
            return connection.BulkInsert<T>(null, items);
        }

        /// <summary>
        ///     An IDbConnection extension method to INSERT entities in a database table or a view.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="connection">The connection to act on.</param>
        /// <param name="item">The item to insert.</param>
        /// <param name="selectors">The selection of entities to insert.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public static DapperPlusActionSet<T> BulkInsert<T>(this IDbConnection connection, T item, params Func<T, object>[] selectors)
        {
            return connection.BulkInsert(null, item, selectors);
        }

        /// <summary>
        ///     An IDbConnection extension method to INSERT entities in a database table or a view.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="connection">The connection to act on.</param>
        /// <param name="items">items to insert.</param>
        /// <param name="selectors">The selection of entities to insert.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public static DapperPlusActionSet<T> BulkInsert<T>(this IDbConnection connection, IEnumerable<T> items, params Func<T, object>[] selectors)
        {
            return connection.BulkInsert(null, items, selectors);
        }

        /// <summary>
        ///     An IDbConnection extension method to INSERT entities in a database table or a view.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="connection">The connection to act on.</param>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="items">items to insert.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public static DapperPlusActionSet<T> BulkInsert<T>(this IDbConnection connection, string mapperKey, params T[] items)
        {
            return new DapperPlusActionSet<T>(connection, mapperKey, DapperPlusActionKind.Insert, items);
        }

        /// <summary>
        ///     An IDbConnection extension method to INSERT entities in a database table or a view.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="connection">The connection to act on.</param>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="item">The item to insert.</param>
        /// <param name="selectors">The selection of entities to insert.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public static DapperPlusActionSet<T> BulkInsert<T>(this IDbConnection connection, string mapperKey, T item, params Func<T, object>[] selectors)
        {
            return new DapperPlusActionSet<T>(connection, mapperKey, DapperPlusActionKind.Insert, item, selectors);
        }

        /// <summary>
        ///     An IDbConnection extension method to INSERT entities in a database table or a view.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="connection">The connection to act on.</param>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="items">items to insert.</param>
        /// <param name="selectors">The selection of entities to insert.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public static DapperPlusActionSet<T> BulkInsert<T>(this IDbConnection connection, string mapperKey, IEnumerable<T> items, params Func<T, object>[] selectors)
        {
            return new DapperPlusActionSet<T>(connection, mapperKey, DapperPlusActionKind.Insert, items, selectors);
        }
    }
}