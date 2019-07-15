# Then Bulk Update

## Definition

The Dapper Plus ThenBulkUpdate method allows to UPDATE entities in a database table or a view using a lambda expression.

The lambda expression uses the entity or the IEnumerable<TEntity> from the last Bulk[Action] or ThenBulk[Action] chained method. (The action can be an insert, update, delete or merge operation).

## Then Bulk Update with "One to One" Relation

The Dapper Plus ThenBulkUpdate method allows updating a related item with a "One to One" relation.


```csharp

//Update an order and then the related invoice.
connection.BulkUpdate(orderTransaction)
          .ThenBulkUpdate(transaction => transaction.order)
          .ThenBulkUpdate(order => order.Invoice);

//Update a list of orders and then the related invoice to every order.
connection.BulkUpdate(orderTransaction)
          .ThenBulkUpdate(transaction => transaction.orders)
          .ThenBulkUpdate(order => order.Invoice);
```

## Then Bulk Update with "One to Many" Relation

The Dapper Plus ThenBulkUpdate method allows updating related items with a "One to Many" relation.


```csharp

//Update an order and then all related items.
connection.BulkUpdate(orderTransaction)
          .ThenBulkUpdate(transaction => transaction.order)
          .ThenBulkUpdate(order => order.Items);

//Update a list of orders and then all related items to every order.
connection.BulkUpdate(orderTransaction)
          .ThenBulkUpdate(transaction => transaction.orders);
          .ThenBulkUpdate(order => order.Items);
```

## Then Bulk Update Chaining

The Dapper Plus ThenBulkUpdate method allows chaining multiple bulk action methods.


```csharp

//Update an order and then all related items. Update an invoice and then all related items.
connection.BulkUpdate(orderTransaction)
          .ThenBulkUpdate(transaction => transaction.order)
          .ThenBulkUpdate(order => order.Items)
          .BulkUpdate(invoiceTransaction)
          .ThenBulkUpdate(transaction => transaction.invoice)
          .ThenBulkUpdate(invoice => invoice.Items);

//Update a list of orders and then all related items to every order. Update a list of invoices 
//and then all related items to every invoice.
connection.BulkUpdate(orderTransaction)
          .ThenBulkUpdate(transaction => transaction.orders)
          .ThenBulkUpdate(order => order.Items)
          .BulkUpdate(invoiceTransaction)
          .ThenBulkUpdate(transaction => transaction.invoices)
          .ThenBulkUpdate(invoice => invoice.Items);
```
