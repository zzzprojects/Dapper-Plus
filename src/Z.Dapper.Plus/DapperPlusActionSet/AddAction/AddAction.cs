using System;
using System.Collections.Generic;
using System.Linq;

namespace Z.Dapper.Plus
{
    public partial class DapperPlusActionSet<TEntity>
    {
        /// <summary>Adds an action to the actionSet.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="actionKind">The action kind.</param>
        /// <param name="selectors">The selection of entities to perform the action kind on.</param>
        public void AddAction<T>(string mapperKey, DapperPlusActionKind actionKind, string entityName = null, params Func<T, object>[] selectors)
        {
            // FROM: Extensions.AlsoBulKAction

            if (selectors == null) return;

            if (Current != null)
            {
                var childs = selectors.Select(x => ((IEnumerable<T>) Current).Select(x).ToList()).ToList();
                AddAction(mapperKey, actionKind, childs, entityName);
            }
            else if (CurrentItem != null)
            {
                var childs = selectors.Select(x => ((IEnumerable<T>) CurrentItem).Select(x).ToList()).ToList();
                AddAction(mapperKey, actionKind, childs, entityName);
            }
        }

        /// <summary>Adds an action to the actionSet.</summary>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="actionKind">The action kind.</param>
        /// <param name="selectors">The selection of entities to perform the action kind on.</param>
        public void AddAction(string mapperKey, DapperPlusActionKind actionKind, string entityName = null, params Func<TEntity, object>[] selectors)
        {
            // FROM: AlsoBulkAction

            if (selectors == null) return;

            if (Current != null)
            {
                var childs = selectors.Select(x => Current.Select(x).ToList()).ToList();
                AddAction(mapperKey, actionKind, childs, entityName);
            }
            else if (CurrentItem != null)
            {
                var childs = selectors.Select(x => x(CurrentItem)).ToList();
                AddAction(mapperKey, actionKind, childs, entityName);
            }
        }

        /// <summary>Adds an action to the actionSet.</summary>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="actionKind">The action kind.</param>
        /// <param name="item">The item to perform the action kind on.</param>
        public void AddAction(string mapperKey, DapperPlusActionKind actionKind, IEnumerable<TEntity> item, string entityName = null)
        {
            // FROM: Constructor
            // FROM: CreateDapperAction

            if (item == null) return;

            Actions.Add(new DapperPlusAction(this, mapperKey, actionKind, item, entityName));
        }

        /// <summary>Adds an action to the actionSet.</summary>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="actionKind">The action kind.</param>
        /// <param name="item">The item to perform the action kind on.</param>
        public void AddAction(string mapperKey, DapperPlusActionKind actionKind, TEntity item, string entityName = null)
        {
            // FROM: Constructor

            if (item == null) return;

            Actions.Add(new DapperPlusAction(this, mapperKey, actionKind, item, entityName));
        }

        /// <summary>Adds an action to the actionSet.</summary>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="actionKind">The action kind.</param>
        /// <param name="childs">The childs to perform the action kind on.</param>
        public void AddAction(string mapperKey, DapperPlusActionKind actionKind, IEnumerable<object> childs, string entityName = null)
        {
            if (childs == null) return;

            childs.Where(x => x != null)
                .ToList()
                .ForEach(x => Actions.Add(new DapperPlusAction(this, mapperKey, actionKind, x, entityName)));
        }
    }
}