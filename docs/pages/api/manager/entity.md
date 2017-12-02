---
permalink: entity
---

## Definition

Adds or updates the mapper associated with the type and mapping key.

### Entity

Adds or updates the mapper associated with the type.

{% include template-example.html title='Entity Examples' %} 
{% highlight csharp %}

DapperPlusManager.Entity<Order>()
                 .Table("Orders");

connection.BulkInsert(orders);
{% endhighlight %}

### Entity with Mapping Key

Adds or updates the mapper associated with the type and mapping key.

{% include template-example.html title='Entity with Mapping Key Examples' %} 
{% highlight csharp %}
DapperPlusManager.Entity<Order>("CustomKey")
                 .Table("CustomOrders");

connection.BulkInsert("CustomKey", orders);
{% endhighlight %}

We highly recommend using an enum value for the mapping key

{% include template-example.html title='BulkSaveChanges Examples' %} 
{% highlight csharp %}

DapperPlusManager.Entity<Order>(MappingKey.CustomKey1.ToString())
                 .Table("CustomOrders");

connection.BulkInsert(MappingKey.CustomKey1.ToString(), orders);
{% endhighlight %}
