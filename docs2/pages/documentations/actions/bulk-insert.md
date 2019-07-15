# Bulk Insert

## Description

The Dapper Plus `BulkInsert` extension method lets you insert a large number of entities in your database.

```csharp
// Easy to use
connection.BulkInsert(orders);

// Easy to customize
connection.UseBulkOptions(options => options.InsertIfNotExists = true)
          .BulkInsert(orders);
```
[Try it](https://dotnetfiddle.net/ltIqrC)

### Performance Comparison

| Operations      | 1,000 Entities | 2,000 Entities | 5,000 Entities |
| :-------------- | -------------: | -------------: | -------------: |
| Execute (Many)  | 1,200 ms       | 2,400 ms       | 6,000 ms       |
| BulkInsert      | 50 ms          | 55 ms          | 75 ms          |

[Try this benchmark online](https://dotnetfiddle.net/CqTwfr)

> HINT: A lot of factors might affect the benchmark time such as index, column type, latency, throttling, etc.

## Bulk Insert Entity

The Dapper Plus BulkInsert method allows inserting a single or multiple entities of the same type.


```csharp

//Insert a single order.
connection.BulkInsert(order);

//Insert multiple orders.
connection.BulkInsert(order1, order2, order3);
```

## Bulk Insert IEnumerable<TEntity>

The Dapper Plus BulkInsert method allows inserting a single enumerable or multiple enumerable of entities of the same type.


```csharp

//Insert a list of orders.
connection.BulkInsert(orders);

//Insert multiple list of orders.
connection.BulkInsert(orders1, orders2, orders3);
```

## Bulk Insert with "One to One" Relation

The Dapper Plus BulkInsert method allows inserting a related item with a "One to One" relation.


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

The Dapper Plus BulkInsert method allows inserting related item(s) with any relation.


```csharp

//Insert an order, all related items, and the related invoice.
connection.BulkInsert(order, order => order.Items, order => order.Invoice);

//Insert a list of orders, all related items to every order, and the related invoice to every order.
connection.BulkInsert(orders, order => order.Items, order => order.Invoice);
```

## Bulk Insert Chain Action

The Dapper Plus BulkInsert method allows chaining multiple bulk action methods.


```csharp

//Insert an order and all related items. Insert an invoice and all related invoice items.
connection.BulkInsert(order, order => order.Items)
          .BulkInsert(invoice, invoice => invoice.Items);

//Insert a list of orders and all related items to every order. Insert a list of invoices and 
//all related items to every invoice.
connection.BulkInsert(orders, order => order.Items)
          .BulkInsert(invoices, invoice => invoice.Items);

```
