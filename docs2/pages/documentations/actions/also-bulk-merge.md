# Also Bulk Merge

## Definition

The Dapper Plus AlsoBulkMerge method allows to MERGE entities in a database table or a view using a lambda expression.

The lambda expression uses the entity or the IEnumerable<TEntity> from the last Bulk[Action] or ThenBulk[Action] chained method. (The action can be an insert, update, delete or merge operation).

## Also Bulk Merge with "One to One" Relation

The Dapper Plus AlsoBulkMerge method allows merging a related item with a "One to One" relation.


```csharp

//Merge an order and also the related invoice.
connection.BulkMerge(order)
          .AlsoBulkMerge(order => order.Invoice);

//Merge a list of orders and also the related invoice to every order.
connection.BulkMerge(orders)
          .AlsoBulkMerge(order => order.Invoice);
```

## Also Bulk Merge with "One to Many" Relation

The Dapper Plus AlsoBulkMerge method allows merging related items with a "One to Many" relation.


```csharp

//Merge an order and also all related items.
connection.BulkMerge(order)
          .AlsoBulkMerge(order => order.Items);

//Merge a list of orders and also all related items to every order.
connection.BulkMerge(orders);
          .AlsoBulkMerge(order => order.Items);
```

## Also Bulk Merge and Mixed Relation

The Dapper Plus AlsoBulkMerge method allows merging related item(s) with any relation.


```csharp

//Merge an order, also all related items and also the related invoice.
connection.BulkMerge(order)
          .AlsoBulkMerge(order => order.Items, order => order.Invoice);

//Merge a list of orders, also all related items to every order and also the related invoice to every order.
connection.BulkMerge(orders)
          .AlsoBulkMerge(order => order.Items, order => order.Invoice);
```

## Also Bulk Merge Chain Action

The Dapper Plus AlsoBulkMerge method allows chaining multiple bulk action methods.


```csharp

//Merge an order and also all related items. Merge an invoice and also all related invoice items.
connection.BulkMerge(order)
          .AlsoBulkMerge(order => order.Items)
          .BulkMerge(invoice)
          .AlsoBulkMerge(invoice => invoice.Items);

//Merge a list of orders and also all related items to every order. Merge a list of invoices and also all related items to every invoice.
connection.BulkMerge(orders)
          .AlsoBulkMerge(order => order.Items)
          .BulkMerge(invoices)
          .AlsoBulkMerge(invoice => invoice.Items);

```
