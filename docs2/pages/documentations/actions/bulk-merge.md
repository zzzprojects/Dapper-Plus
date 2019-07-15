# Bulk Merge


## Definition

The Dapper Plus BulkMerge method allows to MERGE entities in a database table or a view.

## Bulk Merge Entity

The Dapper Plus BulkMerge method allows merging a single or multiple entities of the same type.


```csharp

//Merge a single order.
connection.BulkMerge(order);

//Merge multiple orders.
connection.BulkMerge(order1, order2, order3);
```

## Bulk Merge IEnumerable<TEntity>

The Dapper Plus BulkMerge method allows merging a single enumerable or multiple enumerable of entities of the same type.


```csharp

//Merge a list of orders.
connection.BulkMerge(orders);

//Merge multiple list of orders.
connection.BulkMerge(orders1, orders2, orders3);
```

## Bulk Merge with "One to One" Relation

The Dapper Plus BulkMerge method allows merging a related item with a "One to One" relation.


```csharp

//Merge an order and the related invoice.
connection.BulkMerge(order, order => order.Invoice);

//Merge a list of orders and the related invoice to every order.
connection.BulkMerge(orders, order => order.Invoice);
```

## Bulk Merge with "One to Many" Relation

The Dapper Plus BulkMerge method allows merging related items with a "One to Many" relation.


```csharp

//Merge an order and all related items.
connection.BulkMerge(order, order => order.Items);

//Merge a list of orders and all related items to every order.
connection.BulkMerge(orders, order => order.Items);
```

## Bulk Merge with "Mixed" Relation

The Dapper Plus BulkMerge method allows merging related item(s) with any relation.


```csharp

//Merge an order, all related items, and the related invoice.
connection.BulkMerge(order, order => order.Items, order => order.Invoice);

//Merge a list of orders, all related items to every order, and the related invoice to every order.
connection.BulkMerge(orders, order => order.Items, order => order.Invoice);
```

## Bulk Merge Chain Action

The Dapper Plus BulkMerge method allows chaining multiple bulk action methods.


```csharp

//Merge an order and all related items. Merge an invoice and all related invoice items.
connection.BulkMerge(order, order => order.Items)
          .BulkMerge(invoice, invoice => invoice.Items);

//Merge a list of orders and all related items to every order. Merge a list of invoices and 
//all related items to every invoice.
connection.BulkMerge(orders, order => order.Items)
          .BulkMerge(invoices, invoice => invoice.Items);

```

