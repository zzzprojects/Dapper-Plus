---
permalink: include-actions
---

## Include Actions

The Dapper Plus Include method allow resolving issues with multiple "ThenBulk[Action]" method.

### Example

Without include method (The invoice cannot be chained to last action)

{% include template-example.html title='Without include Example' %} 
{% highlight csharp %}
connection.BulkInsert(orders)
          .ThenInsert(order => order.Items)
          .ThenInsert(orderItem => orderItem.Metas)	  
          // Oops! The related invoice cannot be chained.
          //.ThenInsert(orderItemMeta => ...);
{% endhighlight %}

With include method

{% include template-example.html title='With include Example' %} 
{% highlight csharp %}
connection.BulkInsert(orders)
          .Include(x => x.ThenInsert(order => order.Items)
                         .ThenInsert(orderItem => orderItem.Metas))
          .Include(x => x.ThenInsert(order => order.Invoice)
                         .ThenInsert(Invoice => invoice.Items));
{% endhighlight %}