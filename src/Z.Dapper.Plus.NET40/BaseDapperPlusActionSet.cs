using System.Collections.Generic;
using System.Data;

namespace Z.Dapper.Plus
{
    /// <summary>A base dapper plus action set.</summary>
    public class BaseDapperPlusActionSet
    {
        /// <summary>The actions.</summary>
        public List<DapperPlusAction> Actions = new List<DapperPlusAction>();

        /// <summary>Gets or sets the connection.</summary>
        /// <value>The connection.</value>
        public IDbConnection Connection { get; set; }
    }
}