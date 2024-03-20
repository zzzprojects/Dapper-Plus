# What's Dapper Plus?

Like [Dapper](https://github.com/StackExchange/dapper-dot-net), **Dapper Plus** is a [NuGet library](https://www.nuget.org/packages/Z.Dapper.Plus/) where you can add to your project that will extend your `IDbConnection` and `IDbTransaction` interface with high efficient Bulk Actions Helpers (Insert, Update, Delete, and Merge).

It can be used with or without Dapper, and it's compatible with all other Dapper packages.

### Example
```csharp
// CONFIGURE & MAP entity
DapperPlusManager.Entity<Order>().Table("Orders").Identity(x => x.ID);

// CHAIN & SAVE entity
connection.BulkInsert(orders)
          .AlsoInsert(order => order.Items);
          .Include(order => order.ThenMerge(order => order.Invoice)
                                 .AlsoMerge(invoice => invoice.Items))
          .AlsoMerge(order => order.ShippingAddress);	
```

## Download
<a href="https://www.nuget.org/packages/Z.Dapper.Plus/" target="_blank"><img src="https://zzzprojects.github.io/images/nuget/dapper-plus-v.svg" alt="download" /></a>
<a href="https://www.nuget.org/packages/Z.Dapper.Plus/" target="_blank"><img src="https://zzzprojects.github.io/images/nuget/dapper-plus-d.svg" alt="" /></a>

```
PM> Install-Package Z.Dapper.Plus
```

_* PRO Version unlocked for the current month_

## Wiki
[Introduction](https://dapper-plus.net/overview)

- Bulk Actions
   - [Bulk Insert](https://dapper-plus.net/bulk-insert)
   - [Bulk Update](https://dapper-plus.net/bulk-update)
   - [Bulk Delete](https://dapper-plus.net/bulk-delete)
   - [Bulk Merge](https://dapper-plus.net/bulk-merge)
- Also Bulk Actions
   - [Also Bulk Insert](https://dapper-plus.net/also-bulk-insert)
   - [Also Bulk Update](https://dapper-plus.net/also-bulk-update)
   - [Also Bulk Delete](https://dapper-plus.net/also-bulk-delete)
   - [Also Bulk Merge](https://dapper-plus.net/also-bulk-merge)
- Then Bulk Actions
   - [Then Bulk Insert](https://dapper-plus.net/then-bulk-insert)
   - [Then Bulk Update](https://dapper-plus.net/then-bulk-update)
   - [Then Bulk Delete](https://dapper-plus.net/then-bulk-delete)
   - [Then Bulk Merge](https://dapper-plus.net/then-bulk-merge)
- [Include Actions](https://dapper-plus.net/include-actions)
- [Transaction](https://dapper-plus.net/transaction)

**Dapper Plus - Mapper**
- [Map](https://dapper-plus.net/map)
- Options
   - [Action](https://dapper-plus.net/action-options)
   - [Batch](https://dapper-plus.net/batch-options)
   - [SQL Server](https://dapper-plus.net/sql-server-options)
   - [Temporary Table](https://dapper-plus.net/temporary-table-options)
   - [Transient Error](https://dapper-plus.net/transient-error-options)

[PRO License](https://dapper-plus.net/licensing)

## Mapper
Dapper Plus Mapper allows to map the conceptual model (Entity) with the storage model (Database) and configure options to perform Bulk Actions.
```csharp
DapperPlusManager.Entity<Order>().Table("Orders")
                                 .Identity(x => x.ID)
                                 .BatchSize(200);
```

## Bulk Actions
**Bulk Actions** allow to perform a bulk insert, update, delete or merge and include related child items.
```csharp
connection.BulkInsert(orders, order => order.Items)
          .BulkInsert(invoices, invoice => invoice.Items)
          .BulkMerge(shippingAddresses);
```
### Also Bulk Actions
**Also Bulk Actions** allow to perform bulk action with a lambda expression using entities from the last Bulk[Action] or ThenBulk[Action] used.

```csharp
connection.BulkInsert(orders)
          .AlsoInsert(order => order.Items)
          .AlsoInsert(order => order.Invoice)
          .AlsoInsert(order => order.Invoice.Items);
```
### Then Bulk Actions
**Then Bulk Actions** is similar to Also Bulk Actions but modifies entities used for the next bulk action using a lambda expression.

```csharp
connection.BulkInsert(orders)
          .AlsoInsert(order => order.Items)
          .ThenInsert(order => order.Invoice)
          .ThenInsert(invoice => invoice.Items);
```

### Include Actions
The Dapper Plus Include method allows resolving issues with multiple "ThenBulk[Action]" methods.

```csharp
connection.BulkInsert(orders)
          .Include(x => x.ThenInsert(order => order.Items)
                         .ThenInsert(orderItem => orderItem.Metas))
          .Include(x => x.ThenInsert(order => order.Invoice)
                         .ThenInsert(Invoice => invoice.Items));   	
```

### Transaction
All Dapper Plus extension methods are also available on the `IDbTransaction` interface
```csharp
transaction.BulkInsert(orders)
          .Include(x => x.ThenInsert(order => order.Items)
                         .ThenInsert(orderItem => orderItem.Metas))
          .Include(x => x.ThenInsert(order => order.Invoice)
                         .ThenInsert(Invoice => invoice.Items));   	
```

## DB Provider Supported
All major database providers are supported or under development.
- SQL Server 2008+
- SQL Azure
- SQL Compact
- SQLite
- MySQL
- PostgreSQL
- Oracle

## PRO
_PRO Version unlocked for the current month_

Features                    | [PRO Version](https://dapper-plus.net/#pro)
--------                    | :-------------: |
Bulk Insert                 | Yes
Bulk Update                 | Yes
Bulk Delete                 | Yes
Bulk Merge                  | Yes
Bulk Action Async           | Yes
Bulk Also Action            | Yes
Bulk Then Action            | Yes
Commercial License          | Yes
Royalty-Free                | Yes
Support & Upgrades (1 year) | Yes

Learn more about the **[PRO Version](https://dapper-plus.net/#pro)**.

## Contribute

The best way to contribute is by **spreading the word** about the library:

 - Blog it
 - Comment it
 - Star it
 - Share it
 
A **HUGE THANKS** for your help.

## More Projects

- Projects:
   - [EntityFramework Extensions](https://entityframework-extensions.net/)
   - [Dapper Plus](https://dapper-plus.net/)
   - [C# Eval Expression](https://eval-expression.net/)
- Learn Websites
   - [Learn EF Core](https://www.learnentityframeworkcore.com/)
   - [Learn Dapper](https://www.learndapper.com/)
- Online Tools:
   - [.NET Fiddle](https://dotnetfiddle.net/)
   - [SQL Fiddle](https://sqlfiddle.com/)
   - [ZZZ Code AI](https://zzzcode.ai/)
- and much more!

To view all our free and paid projects, visit our website [ZZZ Projects](https://zzzprojects.com/).
