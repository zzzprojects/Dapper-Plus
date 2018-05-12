# Bulk Insert

## Definition

The Dapper Plus BulkInsert method allow to INSERT entities in a database table or a view.

## Bulk Insert Entity

The Dapper Plus BulkInsert method allow inserting a single or multiple entities of the same type.


```csharp

//Insert a single order.
connection.BulkInsert(order);

//Insert multiple orders.
connection.BulkInsert(order1, order2, order3);
```

## Bulk Insert IEnumerable<TEntity>

The Dapper Plus BulkInsert method allow inserting a single enumerable or multiple enumerable of entities of the same type.


```csharp

//Insert a list of orders.
connection.BulkInsert(orders);

//Insert multiple list of orders.
connection.BulkInsert(orders1, orders2, orders3);
```

## Bulk Insert with "One to One" Relation

The Dapper Plus BulkInsert method allow inserting a related item with a "One to One" relation.


```csharp

//Insert an order and the related invoice.
connection.BulkInsert(order, order => order.Invoice);

//Insert a list of orders and the related invoice to every order.
connection.BulkInsert(orders, order => order.Invoice);
```

## Bulk Insert with "One to Many" Relation

The Dapper Plus BulkInsert method allow inserting related items with a "One to Many" relation.


```csharp

//Insert an order and all related items.
connection.BulkInsert(order, order => order.Items);

//Insert a list of orders and all related items to every order.
connection.BulkInsert(orders, order => order.Items);
```

## Bulk Insert with "Mixed" Relation

The Dapper Plus BulkInsert method allow inserting related item(s) with any relation.


```csharp

//Insert an order, all related items, and the related invoice.
connection.BulkInsert(order, order => order.Items, order => order.Invoice);

//Insert a list of orders, all related items to every order, and the related invoice to every order.
connection.BulkInsert(orders, order => order.Items, order => order.Invoice);
```

## Bulk Insert Chain Action

The Dapper Plus BulkInsert method allow chaining multiple bulk action methods.


```csharp

//Insert an order and all related items. Insert an invoice and all related invoice items.
connection.BulkInsert(order, order => order.Items)
          .BulkInsert(invoice, invoice => invoice.Items);

//Insert a list of orders and all related items to every order. Insert a list of invoices and 
//all related items to every invoice.
connection.BulkInsert(orders, order => order.Items)
          .BulkInsert(invoices, invoice => invoice.Items);

```