# Dapper Plus - Mapper

## Definition
Dapper Plus Mapper allows to map the conceptual model (Entity) with the storage model (Database) and configure options to perform Bulk Actions.

 - Map
   - Identity
   - Ignore
   - Key
   - Map
   - Output
   - Table
 - Batch Options
   - Batch Delay Interval
   - Batch Size
   - Batch Timeout
 - SQL Server Options
   - SqlBulkCopyOptions
 - Temporary Table Options
   - Temporary Table Batch by Table
   - Temporary Table Insert Batch Size
   - Temporary Table Min Record
   - Temporary Table Schema Name
 - Transient Error Options
   - Retry Count
   - Retry Interval


### Mapper Examples
```csharp
DapperPlusManager.Entity<Order>().Table("Orders")
                                 .Identity(x => x.ID)
                                 .BatchSize(200);
```

