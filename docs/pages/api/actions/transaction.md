---
permalink: transaction
---

## Definition

All Dapper Plus extension methods are also available on the IDbTransaction interface.

{% include template-example.html %} 
{% highlight csharp %}
transaction.BulkInsert(orders)
          .Include(x => x.ThenInsert(order => order.Items)
                         .ThenInsert(orderItem => orderItem.Metas))
          .Include(x => x.ThenInsert(order => order.Invoice)
                         .ThenInsert(Invoice => invoice.Items));
{% endhighlight %}

