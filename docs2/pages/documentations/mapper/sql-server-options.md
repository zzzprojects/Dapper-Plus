# SQL Server Options

## Definition

Dapper Plus Mapper allows to configure SqlServer options.

| Name	   | Description |
| :--------| :-----------|
|SqlBulkCopyOptions	|Sets the SqlBulkCopyOptions to use if SqlBulkCopy is used to insert directly in the table.|

## SqlBulkCopyOptions

Sets the SqlBulkCopyOptions to use if SqlBulkCopy is used to insert directly in the table. For example, configure the entity order to use CheckConstraint, FireTrigger and TableLock.


```csharp
//Default
var options = SqlBulkCopyOptions.CheckConstraints |
              SqlBulkCopyOptions.FireTriggers |
              SqlBulkCopyOptions.TableLock;

DapperPlusManager.MapperFactory = mapper => mapper.SqlBulkCopyOptions(options);

//Instance
var options = SqlBulkCopyOptions.CheckConstraints |
              SqlBulkCopyOptions.FireTriggers |
              SqlBulkCopyOptions.TableLock;

DapperPlusManager.Entity<Order>().SqlBulkCopyOptions(options);
```
