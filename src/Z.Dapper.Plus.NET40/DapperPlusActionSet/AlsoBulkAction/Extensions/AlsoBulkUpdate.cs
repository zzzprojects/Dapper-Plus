using System;
using System.Collections.Generic;

namespace Z.Dapper.Plus
{
    public static partial class DapperPlusExtensions
    {
        /// <summary>UPDATE entities in a database table or a view using a lambda expression.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="actionSet">The actionSet to act on.</param>
        /// <param name="selectors">The selection of entities to update.</param>
        /// <returns>An IDapperPlusActionSet&lt;IEnumerable&lt;T&gt;&gt;</returns>
        public static IDapperPlusActionSet<IEnumerable<T>> AlsoBulkUpdate<T>(this IDapperPlusActionSet<IEnumerable<T>> actionSet, params Func<T, object>[] selectors)
        {
            return actionSet.AlsoBulkUpdate(null, selectors);
        }

        /// <summary>UPDATE entities in a database table or a view using a lambda expression.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="actionSet">The actionSet to act on.</param>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="selectors">The selection of entities to update.</param>
        /// <returns>An IDapperPlusActionSet&lt;IEnumerable&lt;T&gt;&gt;</returns>
        public static IDapperPlusActionSet<IEnumerable<T>> AlsoBulkUpdate<T>(this IDapperPlusActionSet<IEnumerable<T>> actionSet, string mapperKey, params Func<T, object>[] selectors)
        {
            actionSet.AddAction(mapperKey, DapperPlusActionKind.Update, selectors);
            return actionSet;
        }
    }
}