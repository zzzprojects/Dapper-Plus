---
permalink: overview
---

## Definition

**Dapper Plus** is a library that dramatically improves dapper performances by using high efficient Bulk Actions Helpers (Insert, Update, Delete, and Merge).

People using this library often report performance enhancement by 50x times and more!

The library is installed through <a href="/installing">NuGet</a>. Extension methods are added automatically to your IDbConnection interface.

It can be used with or without Dapper, and it's compatible with all others Dapper packages.

{% include template-example.html %} 

{% highlight csharp %}
// CONFIGURE & MAP entity
DapperPlusManager.Entity<Order>().Table("Orders").Identity(x => x.ID);

// CHAIN & SAVE entity
connection.BulkInsert(orders)
          .AlsoInsert(order => order.Items);
          .Include(order => order.ThenMerge(order => order.Invoice)
                                 .AlsoMerge(invoice => invoice.Items))
          .AlsoMerge(order => order.ShippingAddress);
{% endhighlight %}

## Mapper

**Dapper Plus Mapper** allow to map the conceptual model (Entity) with the storage model (Database) and configure options to perform Bulk Actions.

{% include template-example.html title='Mapper Examples'%} 

{% highlight csharp %}
DapperPlusManager.Entity<Order>().Table("Orders")
                                 .Identity(x => x.ID)
                                 .BatchSize(200);
{% endhighlight %}

## Bulk Actions

**Bulk Actions** allow to perform a bulk insert, update, delete or merge and include related child items.

Bulk Actions Available:

- [BulkInsert](/bulk-insert)
- [BulkUpdate](/bulk-update)
- [BulkDelete](/bulk-delete)
- [BulkMerge](/bulk-merge) (UPSERT operation)

{% include template-example.html title='Bulk Actions Examples' %} 
{% highlight csharp %}
connection.BulkInsert(orders, order => order.Items)
          .BulkInsert(invoices, invoice => invoice.Items)
          .BulkMerge(shippingAddresses);

{% endhighlight %}

### Performance Comparisons

| Operations      | 1,000 Rows     | 10,000 Rows    | 100,000 Rows   | 1,000,000 Rows | 
| :-------------- | -------------: | -------------: | -------------: | -------------: |
| Insert          | 9 ms           | 25 ms          | 200 ms         | 2,000 ms       |
| Update          | 50 ms          | 80 ms          | 575 ms         | 6,500 ms       |
| Delete          | 45 ms          | 70 ms          | 625 ms         | 6,800 ms       |
| Merge           | 65 ms          | 160 ms         | 1,200 ms       | 12,000 ms      |

## Also Bulk Actions

**Also Bulk Actions** allow to perform bulk action with a lambda expression using entities from the last Bulk[Action] or ThenBulk[Action] used.

{% include template-example.html title='Also Bulk Actions Examples' %} 
{% highlight csharp %}
connection.BulkInsert(orders)
          .AlsoInsert(order => order.Items)
          .AlsoInsert(order => order.Invoice)
          .AlsoInsert(order => order.Invoice.Items);
{% endhighlight %}

## Then Bulk Actions

**Then Bulk Actions** is similar to Also Bulk Actions but modify entities used for the next bulk action using a lambda expression.

{% include template-example.html title='Then Bulk Actions Examples' %} 
{% highlight csharp %}
connection.BulkInsert(orders)
          .AlsoInsert(order => order.Items)
          .ThenInsert(order => order.Invoice)
          .ThenInsert(invoice => invoice.Items);
{% endhighlight %}

## Include Actions

The Dapper Plus **Include** method allow resolving issues with multiple "ThenBulk[Action]" method.

{% include template-example.html title='Include Actions Examples' %} 
{% highlight csharp %}
connection.BulkInsert(orders)
          .Include(x => x.ThenInsert(order => order.Items)
                         .ThenInsert(orderItem => orderItem.Metas))
          .Include(x => x.ThenInsert(order => order.Invoice)
                         .ThenInsert(Invoice => invoice.Items));
{% endhighlight %}
