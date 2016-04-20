using System;
using Z.BulkOperations;

namespace Z.Dapper.Plus
{
    public partial class DapperPlusAction
    {
        /// <summary>Applies the configuration.</summary>
        /// <param name="bulkOperation">The bulk operation.</param>
        /// <param name="config">The configuration.</param>
        public void ApplyConfig(BulkOperation bulkOperation, DapperPlusEntityMapper config)
        {
            if (config == null)
            {
                return;
            }

            // Verify Column Mappings
            Map(bulkOperation, config);

            // Batch
            {
                var batchDelayInterval = config.BatchDelayInterval();
                var batchSize = config.BatchSize();
                var batchTimeout = config.BatchTimeout();

                if (batchDelayInterval.HasValue)
                {
                    bulkOperation.BatchDelayInterval = batchDelayInterval.Value;
                }

                if (batchSize.HasValue)
                {
                    bulkOperation.BatchSize = batchSize.Value;
                }

                if (batchTimeout.HasValue)
                {
                    bulkOperation.BatchTimeout = batchTimeout.Value;
                }
            }

            // Destination
            {
                var table = config.Table();

                if (!string.IsNullOrEmpty(table))
                {
                    bulkOperation.DestinationTableName = table;
                }
            }

            // SqlServer
            {
                var sqlBulkCopyOptions = config.SqlBulkCopyOptions();

                if (sqlBulkCopyOptions.HasValue)
                {
                    bulkOperation.SqlBulkCopyOptions = sqlBulkCopyOptions.Value;
                }
            }

            // TemproaryTable
            {
                var temporaryTableBatchByTable = config.TemporaryTableBatchByTable();
                var temporaryTableInsertBatchSize = config.TemporaryTableInsertBatchSize();
                var temporaryTableMinRecord = config.TemporaryTableMinRecord();
                var temporaryTableSchemaName = config.TemporaryTableSchemaName();

                if (temporaryTableBatchByTable.HasValue)
                {
                    bulkOperation.TemporaryTableBatchByTable = temporaryTableBatchByTable.Value;
                }

                if (temporaryTableInsertBatchSize.HasValue)
                {
                    bulkOperation.TemporaryTableInsertBatchSize = temporaryTableInsertBatchSize.Value;
                }

                if (temporaryTableMinRecord.HasValue)
                {
                    bulkOperation.TemporaryTableMinRecord = temporaryTableMinRecord.Value;
                }

                if (!string.IsNullOrEmpty(temporaryTableSchemaName))
                {
                    bulkOperation.TemporaryTableSchemaName = temporaryTableSchemaName;
                }
            }

            // Transient
            {
                var retryCount = config.RetryCount();
                var retryInterval = config.RetryInterval();

                if (retryCount.HasValue)
                {
                    bulkOperation.RetryCount = retryCount.Value;
                }

                if (retryInterval.HasValue)
                {
                    bulkOperation.RetryInterval = new TimeSpan(0, 0, 0, 0, retryInterval.Value);
                }
            }

            // Column Mapping
            {
                foreach (var column in config._columnMappings)
                {
                    var bulkMapping = new ColumnMapping
                    {
                        SourceName = column.SourceName,
                        DestinationName = column.DestinationName
                    };

                    if (column.IsPrimaryKey)
                    {
                        bulkMapping.IsPrimaryKey = true;
                    }

                    if (column.Input && column.Output)
                    {
                        bulkMapping.Direction = ColumnMappingDirectionType.InputOutput;
                    }
                    else if (column.Output)
                    {
                        bulkMapping.Direction = ColumnMappingDirectionType.Output;
                    }

                    if (column.IsIdentity &&
                        (config == config._masterConfig._configInsert) ||
                        (config == config._masterConfig._configMerge))
                    {
                        bulkMapping.Direction = ColumnMappingDirectionType.Output;
                    }

                    bulkOperation.ColumnMappings.Add(bulkMapping);
                }
            }
        }
    }
}