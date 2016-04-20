using System.Data.SqlClient;

namespace Z.Dapper.Plus
{
    public partial class DapperPlusEntityMapper
    {
        /// <summary>Gets the Sql bulk copy options.</summary>
        /// <returns>The Sql bulk copy options.</returns>
        public SqlBulkCopyOptions? SqlBulkCopyOptions()
        {
            return _sqlBulkCopyOptions ?? (!_isMasterConfig ? _masterConfig._sqlBulkCopyOptions : null);
        }

        /// <summary>Sets the Sql bulk copy options.</summary>
        /// <param name="sqlBulkCopyOptions">The Sql bulk copy options.</param>
        /// <returns>A DapperPlusActionSet.</returns>
        public DapperPlusEntityMapper SqlBulkCopyOptions(SqlBulkCopyOptions sqlBulkCopyOptions)
        {
            _sqlBulkCopyOptions = sqlBulkCopyOptions;
            return this;
        }
    }
}