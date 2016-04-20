using System;
using System.Collections.Generic;
using System.Data;

namespace Z.Dapper.Plus
{
    public static partial class DapperPlusExtensions
    {
        /// <summary>
        ///     An IDbConnection extension method to UPDATE entities in a database table or a view.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="connection">The connection to act on.</param>
        /// <param name="items">items to update.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public static DapperPlusActionSet<T> BulkUpdate<T>(this IDbConnection connection, params T[] items)
        {
            return connection.BulkUpdate<T>(null, items);
        }

        /// <summary>
        ///     An IDbConnection extension method to UPDATE entities in a database table or a view.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="connection">The connection to act on.</param>
        /// <param name="item">The item to update.</param>
        /// <param name="selectors">The selection of entities to update.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public static DapperPlusActionSet<T> BulkUpdate<T>(this IDbConnection connection, T item, params Func<T, object>[] selectors)
        {
            return connection.BulkUpdate(null, item, selectors);
        }

        /// <summary>
        ///     An IDbConnection extension method to UPDATE entities in a database table or a view.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="connection">The connection to act on.</param>
        /// <param name="items">items to update.</param>
        /// <param name="selectors">The selection of entities to update.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public static DapperPlusActionSet<T> BulkUpdate<T>(this IDbConnection connection, IEnumerable<T> items, params Func<T, object>[] selectors)
        {
            return connection.BulkUpdate(null, items, selectors);
        }

        /// <summary>
        ///     An IDbConnection extension method to UPDATE entities in a database table or a view.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="connection">The connection to act on.</param>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="items">items to update.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public static DapperPlusActionSet<T> BulkUpdate<T>(this IDbConnection connection, string mapperKey, params T[] items)
        {
            return new DapperPlusActionSet<T>(connection, mapperKey, DapperPlusActionKind.Update, items);
        }

        /// <summary>
        ///     An IDbConnection extension method to UPDATE entities in a database table or a view.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="connection">The connection to act on.</param>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="item">The item to update.</param>
        /// <param name="selectors">The selection of entities to update.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public static DapperPlusActionSet<T> BulkUpdate<T>(this IDbConnection connection, string mapperKey, T item, params Func<T, object>[] selectors)
        {
            return new DapperPlusActionSet<T>(connection, mapperKey, DapperPlusActionKind.Update, item, selectors);
        }

        /// <summary>
        ///     An IDbConnection extension method to UPDATE entities in a database table or a view.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="connection">The connection to act on.</param>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="items">items to update.</param>
        /// <param name="selectors">The selection of entities to update.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public static DapperPlusActionSet<T> BulkUpdate<T>(this IDbConnection connection, string mapperKey, IEnumerable<T> items, params Func<T, object>[] selectors)
        {
            return new DapperPlusActionSet<T>(connection, mapperKey, DapperPlusActionKind.Update, items, selectors);
        }
    }
}