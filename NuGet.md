Extend your IDbConnection with high-performance bulk operations

## Url

- [Website](https://dapper-plus.net/)
- [Getting Started](https://dapper-plus.net/overview)
- [Documentation](https://dapper-plus.net/bulk-insert)
- [Online Examples](https://dapper-plus.net/online-examples)

## Example

```csharp
DapperPlusManager.Entity<Invoice>().Identity(x => x.InvoiceID, true);
DapperPlusManager.Entity<InvoiceItem>().Identity(x => x.InvoiceItemID, true);

// ...code...

connection.BulkInsert(invoices, x => x.InvoiceMeta, x => x.InvoiceItems);
```

Try it: [https://dotnetfiddle.net/LBfItU](https://dotnetfiddle.net/LBfItU)
