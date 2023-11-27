using System;
using System.Collections.Generic;
using System.Data;
using Z.Dapper.Plus.Mapper;

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
        public static DapperPlusActionSet<T> BulkInsert<T>(this IDbConnection connection, bool useAutoMapper = true, params T[] items)
        {
            return connection.BulkInsert<T>(null, useAutoMapper, items);
        }

        /// <summary>
        ///     An IDbConnection extension method to INSERT entities in a database table or a view.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="connection">The connection to act on.</param>
        /// <param name="item">The item to insert.</param>
        /// <param name="selectors">The selection of entities to insert.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public static DapperPlusActionSet<T> BulkInsert<T>(this IDbConnection connection, T item, bool useAutoMapper = true, params Func<T, object>[] selectors)
        {
            return connection.BulkInsert(null, item, useAutoMapper, selectors);
        }

        /// <summary>
        ///     An IDbConnection extension method to INSERT entities in a database table or a view.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="connection">The connection to act on.</param>
        /// <param name="items">items to insert.</param>
        /// <param name="selectors">The selection of entities to insert.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public static DapperPlusActionSet<T> BulkInsert<T>(this IDbConnection connection, IEnumerable<T> items, bool useAutoMapper = true, 
            params Func<T, object>[] selectors)
        {
            return connection.BulkInsert(null, items, useAutoMapper, selectors);
        }

        /// <summary>
        ///     An IDbConnection extension method to INSERT entities in a database table or a view.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="connection">The connection to act on.</param>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="items">items to insert.</param>
        /// <returns>A DapperPlusActionSet&lt;T&gt;</returns>
        public static DapperPlusActionSet<T> BulkInsert<T>(this IDbConnection connection, string mapperKey, bool useAutoMapper = true, params T[] items)
        {
            return new DapperPlusActionSet<T>(connection, mapperKey, DapperPlusActionKind.Insert, items, useAutoMapper ? AutoMapper.GetEntityName(typeof(T)) : null);
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
        public static DapperPlusActionSet<T> BulkInsert<T>(this IDbConnection connection, string mapperKey, T item, bool useAutoMapper = true, 
            params Func<T, object>[] selectors)
        {
            return new DapperPlusActionSet<T>(connection, mapperKey, DapperPlusActionKind.Insert, item, useAutoMapper ? AutoMapper.GetEntityName(typeof(T)) : null, selectors);
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
        public static DapperPlusActionSet<T> BulkInsert<T>(this IDbConnection connection, string mapperKey, IEnumerable<T> items, bool useAutoMapper = true, 
            params Func<T, object>[] selectors)
        {
            return new DapperPlusActionSet<T>(connection, mapperKey, DapperPlusActionKind.Insert, items, useAutoMapper ? AutoMapper.GetEntityName(typeof(T)) : null, selectors);
        }
    }
}