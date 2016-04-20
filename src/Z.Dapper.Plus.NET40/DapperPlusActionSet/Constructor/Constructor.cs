using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;

namespace Z.Dapper.Plus
{
    public partial class DapperPlusActionSet<TEntity>
    {
        /// <summary>Constructor.</summary>
        /// <param name="connection">The connection.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public DapperPlusActionSet(IDbConnection connection, CancellationToken cancellationToken)
        {
            // FROM: cn.BulkActionAsync(selector)

            Connection = connection;
            CancellationToken = cancellationToken;
        }

        /// <summary>Constructor.</summary>
        /// <param name="connection">The connection.</param>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="actionKind">The action kind.</param>
        /// <param name="items">The items.</param>
        public DapperPlusActionSet(IDbConnection connection, string mapperKey, DapperPlusActionKind actionKind, IEnumerable<TEntity> items)
        {
            // FROM: cn.BulkAction<T>(params T[] items)

            Connection = connection;

            if (items == null) return;

            Current = items.ToList();
            AddAction(mapperKey, actionKind, Current);
        }

        /// <summary>Constructor.</summary>
        /// <param name="connection">The connection.</param>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="actionKind">The action kind.</param>
        /// <param name="item">The item.</param>
        /// <param name="selectors">A variable-length parameters list containing selectors.</param>
        public DapperPlusActionSet(IDbConnection connection, string mapperKey, DapperPlusActionKind actionKind, TEntity item, params Func<TEntity, object>[] selectors)
        {
            // FROM: cn.BulkAction<T>(T item, selectors)

            Connection = connection;

            if (item == null) return;

            CurrentItem = item;
            AddAction(mapperKey, actionKind, CurrentItem);

            if (selectors == null) return;

            var childs = selectors.Select(x => x(CurrentItem)).ToList();
            AddAction(mapperKey, actionKind, childs);
        }

        /// <summary>Constructor.</summary>
        /// <param name="connection">The connection.</param>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="actionKind">The action kind.</param>
        /// <param name="items">The items.</param>
        /// <param name="selectors">A variable-length parameters list containing selectors.</param>
        public DapperPlusActionSet(IDbConnection connection, string mapperKey, DapperPlusActionKind actionKind, IEnumerable<TEntity> items, params Func<TEntity, object>[] selectors)
        {
            // FROM: cn.BulkAction<T>(IEnumerable<T> items, selectors)

            Connection = connection;

            if (items == null) return;

            Current = items.ToList();
            AddAction(mapperKey, actionKind, Current);

            if (selectors == null) return;

            var childs = selectors.Select(x => Current.Select(x).ToList()).ToList();
            AddAction(mapperKey, actionKind, childs);
        }

        /// <summary>Constructor.</summary>
        /// <param name="oldActionSet">Set the old action belongs to.</param>
        public DapperPlusActionSet(BaseDapperPlusActionSet oldActionSet)
        {
            // FROM: action.ThenBulkAction

            Connection = oldActionSet.Connection;
        }

        /// <summary>Constructor.</summary>
        /// <param name="oldActionSet">Set the old action belongs to.</param>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="actionKind">The action kind.</param>
        /// <param name="items">The items.</param>
        public DapperPlusActionSet(BaseDapperPlusActionSet oldActionSet, string mapperKey, DapperPlusActionKind actionKind, IEnumerable<TEntity> items)
        {
            // FROM: action.BulkAction<T>(params T[] items)

            ImportConfiguration(oldActionSet);

            if (items == null) return;

            Current = items.ToList();
            AddAction(mapperKey, actionKind, Current);
        }

        /// <summary>Constructor.</summary>
        /// <param name="oldActionSet">Set the old action belongs to.</param>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="actionKind">The action kind.</param>
        /// <param name="item">The item.</param>
        /// <param name="selectors">A variable-length parameters list containing selectors.</param>
        public DapperPlusActionSet(BaseDapperPlusActionSet oldActionSet, string mapperKey, DapperPlusActionKind actionKind, TEntity item, params Func<TEntity, object>[] selectors)
        {
            // FROM: action.BulkAction<T>(T item, selectors)

            ImportConfiguration(oldActionSet);

            if (item == null) return;

            CurrentItem = item;
            AddAction(mapperKey, actionKind, CurrentItem);

            if (selectors == null) return;

            var childs = selectors.Select(x => x(CurrentItem)).ToList();
            AddAction(mapperKey, actionKind, childs);
        }

        /// <summary>Constructor.</summary>
        /// <param name="oldActionSet">Set the old action belongs to.</param>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="actionKind">The action kind.</param>
        /// <param name="items">The items.</param>
        /// <param name="selectors">A variable-length parameters list containing selectors.</param>
        public DapperPlusActionSet(BaseDapperPlusActionSet oldActionSet, string mapperKey, DapperPlusActionKind actionKind, IEnumerable<TEntity> items, params Func<TEntity, object>[] selectors)
        {
            // FROM: action.BulkAction<T>(IEnumerable<T> items, selectors)

            ImportConfiguration(oldActionSet);

            if (items == null) return;

            Current = items.ToList();
            AddAction(mapperKey, actionKind, Current);

            if (selectors == null) return;

            var childs = selectors.Select(x => Current.Select(x).ToList()).ToList();
            AddAction(mapperKey, actionKind, childs);
        }
    }
}