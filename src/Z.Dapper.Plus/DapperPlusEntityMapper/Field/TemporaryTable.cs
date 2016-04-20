namespace Z.Dapper.Plus
{
    public partial class DapperPlusEntityMapper
    {
        /// <summary>The temporary table batch by table.</summary>
        internal int? _temporaryTableBatchByTable;

        /// <summary>Size of the temporary table insert batch.</summary>
        internal int? _temporaryTableInsertBatchSize;

        /// <summary>The temporary table minimum record.</summary>
        internal int? _temporaryTableMinRecord;

        /// <summary>Name of the temporary table schema.</summary>
        internal string _temporaryTableSchemaName;
    }
}