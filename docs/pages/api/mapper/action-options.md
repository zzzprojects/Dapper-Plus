---
permalink: action-options
---

## InsertIfNotExists

Insert entities only when no entities with the same key already exists in the destination.

{% include template-example.html %} 
{% highlight csharp %}
DapperPlusManager.Entity<Order>()
                 .InsertIfNotExists();

connection.BulkInsert(orders);

{% endhighlight %}
