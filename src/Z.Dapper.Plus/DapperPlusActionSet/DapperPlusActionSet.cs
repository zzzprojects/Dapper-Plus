using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Z.Dapper.Plus
{
    public partial class DapperPlusActionSet<TEntity> : BaseDapperPlusActionSet, IDapperPlusActionSet<TEntity>
    {
        /// <summary>Gets or sets the cancellation token.</summary>
        /// <value>The cancellation token.</value>
        public CancellationToken CancellationToken { get; set; }

        /// <summary>Gets or sets the current.</summary>
        /// <value>The current.</value>
        public IEnumerable<TEntity> Current { get; set; }

        /// <summary>Gets or sets the current item.</summary>
        /// <value>The current item.</value>
        public TEntity CurrentItem { get; set; }

        /// <summary>Creates dapper action.</summary>
        /// <typeparam name="T1">Generic type parameter.</typeparam>
        /// <typeparam name="T2">Generic type parameter.</typeparam>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="actionKind">The action kind.</param>
        /// <param name="selectors">A variable-length parameters list containing selectors.</param>
        /// <returns>The new dapper action.</returns>
        public DapperPlusActionSet<T2> CreateDapperAction<T1, T2>(string mapperKey, DapperPlusActionKind actionKind, params Func<T1, T2>[] selectors)
        {
            // FROM: Extensions.AlsoBulKAction

            var action = new DapperPlusActionSet<T2>(this);

            if (selectors == null) return action;

            if (Current != null)
            {
                var childs = selectors.Select(x => ((IEnumerable<T1>) Current).Select(x).ToList()).ToList();
                AddAction(mapperKey, actionKind, childs);
            }
            else if (CurrentItem != null)
            {
                var childs = selectors.Select(x => ((IEnumerable<T1>) CurrentItem).Select(x).ToList()).ToList();
                AddAction(mapperKey, actionKind, childs);
            }

            return action;
        }

        /// <summary>Creates dapper action.</summary>
        /// <typeparam name="T2">Generic type parameter.</typeparam>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="actionKind">The action kind.</param>
        /// <param name="selectors">A variable-length parameters list containing selectors.</param>
        /// <returns>The new dapper action.</returns>
        public DapperPlusActionSet<T2> CreateDapperAction<T2>(string mapperKey, DapperPlusActionKind actionKind, params Func<TEntity, T2>[] selectors)
        {
            // FROM: ThenBulkAction

            var action = new DapperPlusActionSet<T2>(this);

            if (selectors == null) return action;

            if (Current != null)
            {
                var childs = selectors.Select(x => Current.Select(x).ToList()).ToList();
                action.AddAction(mapperKey, actionKind, childs);
            }
            else if (CurrentItem != null)
            {
                var childs = selectors.Select(x => x(CurrentItem)).ToList();
                action.AddAction(mapperKey, actionKind, childs);
            }

            return action;
        }

        /// <summary>Import configuration.</summary>
        /// <param name="oldActionSet">The action set to import configuration from.</param>
        public void ImportConfiguration(BaseDapperPlusActionSet oldActionSet)
        {
            Actions = oldActionSet.Actions;
            Connection = oldActionSet.Connection;
        }

        //public void Execute()
        //{
        //    // For deferred execution later...
        //    foreach (var action in Actions)
        //    {

        //        action.Execute();
        //    }
        //}
    }
}