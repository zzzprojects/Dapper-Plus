# Then Bulk Update

## Definition

The Dapper Plus ThenBulkDelete method allows to DELETE entities in a database table or a view using a lambda expression.

The lambda expression uses the entity or the IEnumerable<TEntity> from the last Bulk[Action] or ThenBulk[Action] chained method. (The action can be an insert, update, delete or merge operation).

## Then Bulk Delete with "One to One" Relation

The Dapper Plus ThenBulkDelete method allows deleting a related item with a "One to One" relation.


```csharp

//Delete an order and then the related invoice.
connection.BulkDelete(orderTransaction)
          .ThenBulkDelete(transaction => transaction.order)
          .ThenBulkDelete(order => order.Invoice);

//Delete a list of orders and then the related invoice to every order.
connection.BulkDelete(orderTransaction)
          .ThenBulkDelete(transaction => transaction.orders)
          .ThenBulkDelete(order => order.Invoice);
```

## Then Bulk Delete with "One to Many" Relation

The Dapper Plus ThenBulkDelete method allows deleting related items with a "One to Many" relation.


```csharp

//Delete an order and then all related items.
connection.BulkDelete(orderTransaction)
          .ThenBulkDelete(transaction => transaction.order)
          .ThenBulkDelete(order => order.Items);

//Delete a list of orders and then all related items to every order.
connection.BulkDelete(orderTransaction)
          .ThenBulkDelete(transaction => transaction.orders);
          .ThenBulkDelete(order => order.Items);
```

## Then Bulk Delete Chaining

The Dapper Plus ThenBulkDelete method allows chaining multiple bulk action methods.


```csharp

//Delete an order and then all related items. Delete an invoice and then all related items.
connection.BulkDelete(orderTransaction)
          .ThenBulkDelete(transaction => transaction.order)
          .ThenBulkDelete(order => order.Items)
          .BulkDelete(invoiceTransaction)
          .ThenBulkDelete(transaction => transaction.invoice)
          .ThenBulkDelete(invoice => invoice.Items);

//Delete a list of orders and then all related items to every order. Delete a list of invoices and 
//then all related items to every invoice.
connection.BulkDelete(orderTransaction)
          .ThenBulkDelete(transaction => transaction.orders)
          .ThenBulkDelete(order => order.Items)
          .BulkDelete(invoiceTransaction)
          .ThenBulkDelete(transaction => transaction.invoices)
          .ThenBulkDelete(invoice => invoice.Items);

```
