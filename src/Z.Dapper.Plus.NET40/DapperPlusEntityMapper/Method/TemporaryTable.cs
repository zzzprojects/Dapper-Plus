namespace Z.Dapper.Plus
{
    public partial class DapperPlusEntityMapper
    {
        /// <summary>Gets the temporary table batch by table.</summary>
        /// <returns>The temporary table batch by table.</returns>
        public int? TemporaryTableBatchByTable()
        {
            return _temporaryTableBatchByTable ?? (!_isMasterConfig ? _masterConfig._temporaryTableBatchByTable : null);
        }

        /// <summary>Gets the temporary table insert batch size.</summary>
        /// <returns>The temporary table insert batch size.</returns>
        public int? TemporaryTableInsertBatchSize()
        {
            return _temporaryTableInsertBatchSize ?? (!_isMasterConfig ? _masterConfig._temporaryTableInsertBatchSize : null);
        }

        /// <summary>Gets the temporary table minimum record.</summary>
        /// <returns>The tTemporary table minimum record.</returns>
        public int? TemporaryTableMinRecord()
        {
            return _temporaryTableMinRecord ?? (!_isMasterConfig ? _masterConfig._temporaryTableMinRecord : null);
        }

        /// <summary>Gets the temporary table schema name.</summary>
        /// <returns>The temporary table schema name.</returns>
        public string TemporaryTableSchemaName()
        {
            return _temporaryTableSchemaName ?? (!_isMasterConfig ? _masterConfig._temporaryTableSchemaName : null);
        }

        /// <summary>Sets the temporary table batch by table.</summary>
        /// <param name="temporaryTableBatchByTable">The temporary table batch by table.</param>
        /// <returns>A DapperPlusActionSet.</returns>
        public DapperPlusEntityMapper TemporaryTableBatchByTable(int temporaryTableBatchByTable)
        {
            _temporaryTableBatchByTable = temporaryTableBatchByTable;
            return this;
        }

        /// <summary>Sets the temporary table insert batch size.</summary>
        /// <param name="temporaryTableInsertBatchSize">Size of the temporary table insert batch.</param>
        /// <returns>A DapperPlusActionSet.</returns>
        public DapperPlusEntityMapper TemporaryTableInsertBatchSize(int temporaryTableInsertBatchSize)
        {
            _temporaryTableInsertBatchSize = temporaryTableInsertBatchSize;
            return this;
        }

        /// <summary>Sets the Temporary table minimum record.</summary>
        /// <param name="temporaryTableMinRecord">The temporary table minimum record.</param>
        /// <returns>A DapperPlusActionSet.</returns>
        public DapperPlusEntityMapper TemporaryTableMinRecord(int temporaryTableMinRecord)
        {
            _temporaryTableMinRecord = temporaryTableMinRecord;
            return this;
        }

        /// <summary>Sets the temporary table schema name.</summary>
        /// <param name="temporaryTableSchemaName">Name of the temporary table schema.</param>
        /// <returns>A DapperPlusActionSet.</returns>
        public DapperPlusEntityMapper TemporaryTableSchemaName(string temporaryTableSchemaName)
        {
            _temporaryTableSchemaName = temporaryTableSchemaName;
            return this;
        }
    }
}