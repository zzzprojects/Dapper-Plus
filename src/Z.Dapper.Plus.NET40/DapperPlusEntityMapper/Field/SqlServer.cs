using System.Data.SqlClient;

namespace Z.Dapper.Plus
{
    public partial class DapperPlusEntityMapper
    {
        /// <summary>Options for controlling the Sql bulk copy.</summary>
        internal SqlBulkCopyOptions? _sqlBulkCopyOptions;
    }
}