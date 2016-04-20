using System;

namespace Z.Dapper.Plus
{
    public partial class DapperPlusActionSet<TEntity>
    {
        /// <summary>Includes the given action.</summary>
        /// <param name="includeAction">The action to include.</param>
        /// <returns>A DapperPlusActionSet&lt;TEntity&gt;</returns>
        public DapperPlusActionSet<TEntity> Include(Action<DapperPlusActionSet<TEntity>> includeAction)
        {
            if (includeAction != null)
            {
                includeAction(this);
            }

            return this;
        }
    }
}