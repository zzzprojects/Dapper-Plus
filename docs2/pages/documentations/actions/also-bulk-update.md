# Also Bulk Update

## Definition

The Dapper Plus AlsoBulkUpdate method allow to UPDATE entities in a database table or a view using a lambda expression.

The lambda expression uses the entity or the IEnumerable<TEntity> from the last Bulk[Action] or ThenBulk[Action] chained method. (The action can be an insert, update, delete or merge operation).


## Also Bulk Update with "One to One" Relation

The Dapper Plus AlsoBulkUpdate method allows updating a related item with a "One to One" relation.


```csharp

//Update an order and also the related invoice.
connection.BulkUpdate(order)
          .AlsoBulkUpdate(order => order.Invoice);

//Update a list of orders and also the related invoice to every order.

connection.BulkUpdate(orders)
          .AlsoBulkUpdate(order => order.Invoice);
```

## Also Bulk Update with "One to Many" Relation

The Dapper Plus AlsoBulkUpdate method allows updating related items with a "One to Many" relation.


```csharp

//Update an order and also all related items.
connection.BulkUpdate(order)
          .AlsoBulkUpdate(order => order.Items);

//Update a list of orders and also all related items to every order.
connection.BulkUpdate(orders);
          .AlsoBulkUpdate(order => order.Items);
```

## Also Bulk Update and Mixed Relation

The Dapper Plus AlsoBulkUpdate method allows updating related item(s) with any relation.


```csharp

//Update an order, also all related items and also the related invoice.
connection.BulkUpdate(order)
          .AlsoBulkUpdate(order => order.Items, order => order.Invoice);

//Update a list of orders, also all related items to every order and also the related invoice
//to every order.
connection.BulkUpdate(orders)
          .AlsoBulkUpdate(order => order.Items, order => order.Invoice);
```

## Also Bulk Update Chain Action

The Dapper Plus AlsoBulkUpdate method allows chaining multiple bulk action methods.


```csharp

//Update an order and also all related items. Update an invoice and also all related invoice items.
connection.BulkUpdate(order)
          .AlsoBulkUpdate(order => order.Items)
          .BulkUpdate(invoice)
          .AlsoBulkUpdate(invoice => invoice.Items);

//Update a list of orders and also all related items to every order. Update a list of invoices 
//and also all related items to every invoice.
connection.BulkUpdate(orders)
          .AlsoBulkUpdate(order => order.Items)
          .BulkUpdate(invoices)
          .AlsoBulkUpdate(invoice => invoice.Items);

```
