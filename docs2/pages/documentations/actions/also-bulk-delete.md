# Also Bulk Delete

## Definition

The Dapper Plus AlsoBulkDelete method allows to DELETE entities in a database table or a view using a lambda expression.

The lambda expression uses the entity or the IEnumerable<TEntity> from the last Bulk[Action] or ThenBulk[Action] chained method. (The action can be an insert, update, delete or merge operation).

## Also Bulk Delete with "One to One" Relation

The Dapper Plus AlsoBulkDelete method allows deleting a related item with a "One to One" relation.


```csharp

//Delete an order and also the related invoice.
connection.BulkDelete(order)
          .AlsoBulkDelete(order => order.Invoice);

//Delete a list of orders and also the related invoice to every order.
connection.BulkDelete(orders)
          .AlsoBulkDelete(order => order.Invoice);
```

## Also Bulk Delete with "One to Many" Relation

The Dapper Plus AlsoBulkDelete method allows deleting related items with a "One to Many" relation.


```csharp

//Delete an order and also all related items.
connection.BulkDelete(order)
          .AlsoBulkDelete(order => order.Items);

//Delete a list of orders and also all related items to every order.
connection.BulkDelete(orders);
          .AlsoBulkDelete(order => order.Items);
```

## Also Bulk Delete and Mixed Relation

The Dapper Plus AlsoBulkDelete method allows deleting related item(s) with any relation.


```csharp

//Delete an order, also all related items and also the related invoice.
connection.BulkDelete(order)
          .AlsoBulkDelete(order => order.Items, order => order.Invoice);

//Delete a list of orders, also all related items to every order and also the related invoice 
//to every order.
connection.BulkDelete(orders)
          .AlsoBulkDelete(order => order.Items, order => order.Invoice);
```

## Also Bulk Delete Chain Action

The Dapper Plus AlsoBulkDelete method allows chaining multiple bulk action methods.


```csharp

//Delete an order and also all related items. Delete an invoice and also all related invoice items.
connection.BulkDelete(order)
          .AlsoBulkDelete(order => order.Items)
          .BulkDelete(invoice)
          .AlsoBulkDelete(invoice => invoice.Items);
//Delete a list of orders and also all related items to every order. Delete a list of invoices and 
//also all related items to every invoice.
connection.BulkDelete(orders)
          .AlsoBulkDelete(order => order.Items)
          .BulkDelete(invoices)
          .AlsoBulkDelete(invoice => invoice.Items);

```
