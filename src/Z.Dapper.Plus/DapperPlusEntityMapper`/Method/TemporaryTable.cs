namespace Z.Dapper.Plus
{
    public partial class DapperPlusEntityMapper<T>
    {
        /// <summary>Sets the temporary table batch by table.</summary>
        /// <param name="temporaryTableBatchByTable">The temporary table batch by table.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public new DapperPlusEntityMapper<T> TemporaryTableBatchByTable(int temporaryTableBatchByTable)
        {
            _temporaryTableBatchByTable = temporaryTableBatchByTable;
            return this;
        }

        /// <summary>Sets the temporary table insert batch size.</summary>
        /// <param name="temporaryTableInsertBatchSize">Size of the temporary table insert batch.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public new DapperPlusEntityMapper<T> TemporaryTableInsertBatchSize(int temporaryTableInsertBatchSize)
        {
            _temporaryTableInsertBatchSize = temporaryTableInsertBatchSize;
            return this;
        }

        /// <summary>Sets the Temporary table minimum record.</summary>
        /// <param name="temporaryTableMinRecord">The temporary table minimum record.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public new DapperPlusEntityMapper<T> TemporaryTableMinRecord(int temporaryTableMinRecord)
        {
            _temporaryTableMinRecord = temporaryTableMinRecord;
            return this;
        }

        /// <summary>Sets the temporary table schema name.</summary>
        /// <param name="temporaryTableSchemaName">Name of the temporary table schema.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public new DapperPlusEntityMapper<T> TemporaryTableSchemaName(string temporaryTableSchemaName)
        {
            _temporaryTableSchemaName = temporaryTableSchemaName;
            return this;
        }
    }
}