---
permalink: map
---

## Definition

Dapper Plus Mapper allow mapping the conceptual model (Entity) with the storage model (Database).


| Name	   | Description |
| :--------| :-----------|
|Identity	|Sets column(s) which the database generates value. The value is outputted from the destination table (insert and merge action).|
|Ignore	  |Sets column(s) to ignore.|
|Key	  |Sets column(s) to use for Primary Key (update, delete, and merge action).|
|Map	  |Sets column(s) to input to the destination table.|
|MapValue |Sets value to map to the destination table.|
|Output	  |Sets column(s) to output from the destination table (insert, update, and merge action).|
|Table	  |Sets the destination table or view name (including schema).|

## Mapper - Identity

Sets column(s) which the database generates value. The value is outputted from the destination table (insert and merge action).

{% include template-example.html %} 
{% highlight csharp %}
DapperPlusManager.Entity<Order>()
                 .Identity(x => x.OrderID);
{% endhighlight %}

## Mapper - Ignore

Sets column(s) to ignore.

{% include template-example.html %} 
{% highlight csharp %}
//Ignore single column
DapperPlusManager.Entity<Order>()
                 .Ignore(x => x.Column1);

//Ignore many columns
DapperPlusManager.Entity<Order>()
                 .Ignore(x => new { x.Column1, x.Column2, x.Column3 });
{% endhighlight %}

## Mapper - Key

Sets column(s) to use for Primary Key (update, delete, and merge action).

{% include template-example.html %} 
{% highlight csharp %}
//Single Key
DapperPlusManager.Entity<Order>()
                 .Key(order => order.OrderID);

//Composite Key
DapperPlusManager.Entity<Order>()
                 .Key(order => new { order.ApplicationID, order.OrderCode });
{% endhighlight %}

## Mapper - Map

Sets column(s) to input to the destination table. 

Map with an anonymous type. Sets the property name only if different from the database.

{% include template-example.html %} 
{% highlight csharp %}
DapperPlusManager.Entity<Order>()
                 .Map(order => new { qty = order.TotalQuantity, order.TotalPrice });
{% endhighlight %}

Map with hardcoded string

{% include template-example.html %} 
{% highlight csharp %}
DapperPlusManager.Entity<Order>()
                 .Map(order => order.TotalQuantity, "qty")
				 .Map(order => order.TotalPrice, "TotalPrice");
{% endhighlight %}

Map with constant value

{% include template-example.html %} 
{% highlight csharp %}
DapperPlusManager.Entity<Order>()
                 .Map(order => new { ConstantColumn1 = 1)
				 .Map(order => 2, "ConstantColumn2");
{% endhighlight %}

{% include template-example.html %} 
{% highlight csharp %}
DapperPlusManager.Entity<Order>()
                 .Map(order => new { AvgPrice1 = order.TotalPrice/order.TotalQuantity })
                 .Map(order => order.TotalPrice / order.TotalQuantity, "AvgPrice2");

DapperPlusManager.Entity<Order>()
                 .Map(order => order.TotalQuantity, "qty")
				 .Map(order => order.TotalPrice, "TotalPrice");
{% endhighlight %}

## Mapper - MapValue
Sets value to map to the destination table.

Map with constant value

{% include template-example.html %} 
{% highlight csharp %}
DapperPlusManager.Entity<Order>()
		 .MapValue(2, "ConstantColumn2");
{% endhighlight %}

Map with variable

{% include template-example.html %} 
{% highlight csharp %}
var constantValue = 2;
DapperPlusManager.Entity<Order>()
		 .MapValue(constantValue, "ConstantColumn2");
{% endhighlight %}
	
## Mapper - Output

Sets column(s) to output from the destination table (insert, update, and merge action).

{% include template-example.html %} 
{% highlight csharp %}
//Output single column
DapperPlusManager.Entity<Order>()
                 .Output(order => order.Column1);

//Output many columns
DapperPlusManager.Entity<Order>()
                 .Output(order => new { order.Column1, order.Column2, order.Column3 });
{% endhighlight %}

## Mapper - Table

Sets the destination table or view name (including schema). By default, the name mapped is singular.

{% include template-example.html %} 
{% highlight csharp %}
DapperPlusManager.Entity<Order>()
                 .Table("zzz.customers");
{% endhighlight %}
