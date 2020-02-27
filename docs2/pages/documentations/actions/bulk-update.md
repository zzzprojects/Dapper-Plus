# Bulk Update


## Definition

The Dapper Plus BulkUpdate method allows to UPDATE entities in a database table or a view.

## Bulk Update Entity

The Dapper Plus BulkUpdate method allows updating a single or multiple entities of the same type.


```csharp

//Update a single order.
connection.BulkUpdate(order);

//Update multiple orders.
connection.BulkUpdate(order1, order2, order3);
```

## Bulk Update IEnumerable<TEntity>

The Dapper Plus BulkUpdate method allows updating a single enumerable or multiple enumerable of entities of the same type.


```csharp

//Update a list of orders.
connection.BulkUpdate(orders);

//Update multiple list of orders.
connection.BulkUpdate(orders1, orders2, orders3);
```

## Bulk Update with "One to One" Relation

The Dapper Plus BulkUpdate method allows updating a related item with a "One to One" relation.


```csharp

//Update an order and the related invoice.
connection.BulkUpdate(order, order => order.Invoice);

//Update a list of orders and the related invoice to every order.
connection.BulkUpdate(orders, order => order.Invoice);
```

## Bulk Update with "One to Many" Relation

The Dapper Plus BulkUpdate method allows updating related items with a "One to Many" relation.


```csharp

//Update an order and all related items.
connection.BulkUpdate(order, order => order.Items);

//Update a list of orders and all related items to every order.
connection.BulkUpdate(orders, order => order.Items);
```

## Bulk Update with "Mixed" Relation

The Dapper Plus BulkUpdate method allows updating related item(s) with any relation.


```csharp

//Update an order, all related items, and the related invoice.
connection.BulkUpdate(order, order => order.Items, order => order.Invoice);

//Update a list of orders, all related items to every order, and the related invoice to every order.
connection.BulkUpdate(orders, order => order.Items, order => order.Invoice);
```

## Bulk Update Chain Action

The Dapper Plus BulkUpdate method allows chaining multiple bulk action methods.


```csharp

//Update an order and all related items. Update an invoice and all related invoice items.
connection.BulkUpdate(order, order => order.Items)
          .BulkUpdate(invoice, invoice => invoice.Items);

//Update a list of orders and all related items to every order. Update a list of invoices and 
//all related items to every invoice.
connection.BulkUpdate(orders, order => order.Items)
          .BulkUpdate(invoices, invoice => invoice.Items);

```

