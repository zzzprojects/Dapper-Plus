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
[Introduction][dapper_plus_introduction]

**Dapper Plus -  Actions**
- [Introduction][dapper_plus_actions_introduction]
- Bulk Actions
   - [Bulk Insert][dapper_plus_bulk_insert]
   - [Bulk Update][dapper_plus_bulk_update]
   - [Bulk Delete][dapper_plus_bulk_delete]
   - [Bulk Merge][dapper_plus_bulk_merge]
- Also Bulk Actions
   - [Also Bulk Insert][dapper_plus_also_bulk_insert]
   - [Also Bulk Update][dapper_plus_also_bulk_update]
   - [Also Bulk Delete][dapper_plus_also_bulk_delete]
   - [Also Bulk Merge][dapper_plus_also_bulk_merge]
- Then Bulk Actions
   - [Then Bulk Insert][dapper_plus_then_bulk_insert]
   - [Then Bulk Update][dapper_plus_then_bulk_update]
   - [Then Bulk Delete][dapper_plus_then_bulk_delete]
   - [Then Bulk Merge][dapper_plus_then_bulk_merge]
- [Include Actions][dapper_plus_include_actions]
- [Transaction][dapper_plus_transaction]

**Dapper Plus - Mapper**
- [Introduction][dapper_plus_mapper_introduction]
- [Map][dapper_plus_mapper_map]
- Options
   - [Action][dapper_plus_mapper_action]
   - [Batch][dapper_plus_mapper_batch]
   - [SQL Server][dapper_plus_mapper_sql_server]
   - [Temporary Table][dapper_plus_mapper_temporary_table]
   - [Transient Error][dapper_plus_mapper_transient_error]
 
**Dapper Plus - Manager**
- [Entity][dapper_plus_manager_entity]
- [MapperFactory][dapper_plus_manager_mapperfactory]

[PRO License][dapper_plus_pro_license]

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

[dapper_plus_introduction]:https://github.com/zzzprojects/Dapper-Plus/wiki/dapper-plus-introduction

[dapper_plus_actions_introduction]:https://github.com/zzzprojects/Dapper-Plus/wiki/dapper-plus-actions-introduction

[dapper_plus_bulk_insert]:https://github.com/zzzprojects/Dapper-Plus/wiki/dapper-plus-bulk-insert
[dapper_plus_bulk_update]:https://github.com/zzzprojects/Dapper-Plus/wiki/dapper-plus-bulk-update
[dapper_plus_bulk_delete]:https://github.com/zzzprojects/Dapper-Plus/wiki/dapper-plus-bulk-delete
[dapper_plus_bulk_merge]:https://github.com/zzzprojects/Dapper-Plus/wiki/dapper-plus-bulk-merge

[dapper_plus_also_bulk_insert]:https://github.com/zzzprojects/Dapper-Plus/wiki/dapper-plus-also-bulk-insert
[dapper_plus_also_bulk_update]:https://github.com/zzzprojects/Dapper-Plus/wiki/dapper-plus-also-bulk-update
[dapper_plus_also_bulk_delete]:https://github.com/zzzprojects/Dapper-Plus/wiki/dapper-plus-also-bulk-delete
[dapper_plus_also_bulk_merge]:https://github.com/zzzprojects/Dapper-Plus/wiki/dapper-plus-also-bulk-merge

[dapper_plus_then_bulk_insert]:https://github.com/zzzprojects/Dapper-Plus/wiki/dapper-plus-then-bulk-insert
[dapper_plus_then_bulk_update]:https://github.com/zzzprojects/Dapper-Plus/wiki/dapper-plus-then-bulk-update
[dapper_plus_then_bulk_delete]:https://github.com/zzzprojects/Dapper-Plus/wiki/dapper-plus-then-bulk-delete
[dapper_plus_then_bulk_merge]:https://github.com/zzzprojects/Dapper-Plus/wiki/dapper-plus-then-bulk-merge

[dapper_plus_include_actions]:https://github.com/zzzprojects/Dapper-Plus/wiki/dapper-plus-include-actions

[dapper_plus_transaction]:https://github.com/zzzprojects/Dapper-Plus/wiki/dapper-plus-transaction

[dapper_plus_mapper_introduction]:https://github.com/zzzprojects/Dapper-Plus/wiki/dapper-plus-mapper-introduction
[dapper_plus_mapper_map]:https://github.com/zzzprojects/Dapper-Plus/wiki/dapper-plus-mapper-map

[dapper_plus_mapper_action]:https://github.com/zzzprojects/Dapper-Plus/wiki/dapper-plus-mapper-action
[dapper_plus_mapper_batch]:https://github.com/zzzprojects/Dapper-Plus/wiki/dapper-plus-mapper-batch
[dapper_plus_mapper_sql_server]:https://github.com/zzzprojects/Dapper-Plus/wiki/dapper-plus-mapper-sql-server
[dapper_plus_mapper_temporary_table]:https://github.com/zzzprojects/Dapper-Plus/wiki/dapper-plus-mapper-temporary-table
[dapper_plus_mapper_transient_error]:https://github.com/zzzprojects/Dapper-Plus/wiki/dapper-plus-mapper-transient-error

[dapper_plus_manager_entity]:https://github.com/zzzprojects/Dapper-Plus/wiki/dapper-plus-manager-entity
[dapper_plus_manager_mapperfactory]:https://github.com/zzzprojects/Dapper-Plus/wiki/dapper-plus-manager-mapper-factory

[dapper_plus_pro_license]:https://github.com/zzzprojects/Dapper-Plus/wiki/dapper-plus-pro-license

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

- [Dapper Plus](https://dapper-plus.net/)
- [Bulk Operations](https://bulk-operations.net/)
- [C# Eval Expression](https://eval-expression.net/)
- and much more!

To view all our free and paid projects, visit our [website](https://zzzprojects.com/).

Contact our outstanding **[customer support](https://entityframework-extensions.net/contact-us)** for any request. We usually answer within the next day, hour, or minutes!
