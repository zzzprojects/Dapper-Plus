# Dapper Plus - Actions

## Bulk Actions
The Dapper Plus Bulk[Action] method allows to [Action] entities in a database table or a view.

 - [Bulk Insert](/bulk-insert)
 - [Bulk Update](/bulk-update)
 - [Bulk Delete](/bulk-delete)
 - [Bulk Merge](/bulk-merge)


```csharp

connection.BulkInsert(orders, order => order.Items)
          .BulkInsert(invoices, invoice => invoice.Items)
          .BulkMerge(shippingAddresses);

```

## Also Bulk Actions

The Dapper Plus AlsoBulk[Action] method allows to [Action] entities in a database table or a view using a lambda expression.

The lambda expression use the entity or the IEnumerable from the last Bulk[Action] or ThenBulk[Action] chained method. (The action can be an insert, update, delete or merge operation).

 - [Also Bulk Insert](/also-bulk-insert)
 - [Also Bulk Update](/also-bulk-update)
 - [Also Bulk Delete](/also-bulk-delete)
 - [Also Bulk Merge](/also-bulk-merge)


```csharp
connection.BulkInsert(orders)
          .AlsoInsert(order => order.Items)
          .AlsoInsert(order => order.Invoice)
          .AlsoInsert(order => order.Invoice.Items);
```

## Then Bulk Actions

The Dapper Plus ThenBulk[Action] method allows to [Action] entities in a database table or a view using a lambda expression.

The lambda expression use the entity or the IEnumerable from the last Bulk[Action] or ThenBulk[Action] chained method. (The action can be an insert, update, delete or merge operation).

 - [Then Bulk Insert](/then-bulk-insert)
 - [Then Bulk Update](/then-bulk-update)
 - [Then Bulk Delete](/then-bulk-delete)
 - [Then Bulk Merge](/then-bulk-merge)


```csharp
connection.BulkInsert(orderTransaction)
          .ThenBulkInsert(transaction => transaction.order)
          .ThenBulkInsert(order => order.Invoice);

```

## Include Actions

The Dapper Plus Include method allows resolving issues with multiple "ThenBulk[Action]" methods.

 - [Include Actions](/include-actions)


```csharp
connection.BulkInsert(orders)
          .Include(x => x.ThenInsert(order => order.Items)
                         .ThenInsert(orderItem => orderItem.Metas))
          .Include(x => x.ThenInsert(order => order.Invoice)
                         .ThenInsert(Invoice => invoice.Items));
```

## Transaction

All Dapper Plus extension methods are also available on the IDbTransaction interface


```csharp
transaction.BulkInsert(orders)
          .Include(x => x.ThenInsert(order => order.Items)
                         .ThenInsert(orderItem => orderItem.Metas))
          .Include(x => x.ThenInsert(order => order.Invoice)
                         .ThenInsert(Invoice => invoice.Items));
```
