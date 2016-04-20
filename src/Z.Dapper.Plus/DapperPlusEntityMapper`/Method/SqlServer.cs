using System.Data.SqlClient;

namespace Z.Dapper.Plus
{
    public partial class DapperPlusEntityMapper<T>
    {
        /// <summary>Sets the Sql bulk copy options.</summary>
        /// <param name="sqlBulkCopyOptions">The Sql bulk copy options.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public new DapperPlusEntityMapper<T> SqlBulkCopyOptions(SqlBulkCopyOptions sqlBulkCopyOptions)
        {
            _sqlBulkCopyOptions = sqlBulkCopyOptions;
            return this;
        }
    }
}