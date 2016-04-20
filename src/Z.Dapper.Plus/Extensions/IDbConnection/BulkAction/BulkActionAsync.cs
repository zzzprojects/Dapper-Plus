using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Z.Dapper.Plus
{
    public static partial class DapperPlusExtensions
    {
#if NET45
        /// <summary>An IDbConnection extension method that bulk action asynchronous.</summary>
        /// <param name="connection">The connection to act on.</param>
        /// <param name="asyncAction">The asynchronous action.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task.</returns>
        public static Task BulkActionAsync(this IDbConnection connection, Action<DapperPlusActionSet<object>> asyncAction, CancellationToken cancellationToken = default(CancellationToken))
        {
            var actionSet = new DapperPlusActionSet<object>(connection, cancellationToken);
            return Task.Run(() => asyncAction(actionSet), cancellationToken);
        }
#endif
    }
}