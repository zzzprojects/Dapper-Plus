# Bulk Delete

## Definition

The Dapper Plus BulkDelete method allows to DELETE entities in a database table or a view.

## Bulk Delete Entity

The Dapper Plus BulkDelete method allows deleting a single or multiple entities of the same type.


```csharp

//Delete a single order.
connection.BulkDelete(order);

//Delete multiple orders.
connection.BulkDelete(order1, order2, order3);
```

## Bulk Delete IEnumerable<TEntity>

The Dapper Plus BulkDelete method allows deleting a single enumerable or multiple enumerable of entities of the same type.


```csharp

//Delete a list of orders.
connection.BulkDelete(orders);

//Delete multiple list of orders.
connection.BulkDelete(orders1, orders2, orders3);
```

## Bulk Delete with "One to One" Relation

The Dapper Plus BulkDelete method allows deleting a related item with a "One to One" relation.


```csharp

//Delete an order and the related invoice.
connection.BulkDelete(order, order => order.Invoice);

//Delete a list of orders and the related invoice to every order.
connection.BulkDelete(orders, order => order.Invoice);
```

## Bulk Delete with "One to Many" Relation

The Dapper Plus BulkDelete method allows deleting related items with a "One to Many" relation.


```csharp

//Delete an order and all related items.
connection.BulkDelete(order, order => order.Items);

//Delete a list of orders and all related items to every order.
connection.BulkDelete(orders, order => order.Items);
```

## Bulk Delete with "Mixed" Relation

The Dapper Plus BulkDelete method allows deleting related item(s) with any relation.



```csharp

//Delete an order, all related items, and the related invoice.
connection.BulkDelete(order, order => order.Items, order => order.Invoice);

//Delete a list of orders, all related items to every order, and the related invoice to every order.
connection.BulkDelete(orders, order => order.Items, order => order.Invoice);
```

## Bulk Delete Chain Action

The Dapper Plus BulkDelete method allows chaining multiple bulk action methods.


```csharp
//Delete an order and all related items. Delete an invoice and all related invoice items.
connection.BulkDelete(order, order => order.Items)
          .BulkDelete(invoice, invoice => invoice.Items);

//Delete a list of orders and all related items to every order. Delete a list of invoices and 
//all related items to every invoice.
connection.BulkDelete(orders, order => order.Items)
          .BulkDelete(invoices, invoice => invoice.Items);
```
