---
permalink: also-bulk-delete
---

## Definition

The Dapper Plus AlsoBulkDelete method allow to DELETE entities in a database table or a view using a lambda expression.

The lambda expression use the entity or the IEnumerable<TEntity> from the last Bulk[Action] or ThenBulk[Action] chained method. (The action can be an insert, update, delete or merge operation).

## Also Bulk Delete with "One to One" Relation

The Dapper Plus AlsoBulkDelete method allow deleting a related item with a "One to One" relation.

{% include template-example.html %} 
{% highlight csharp %}

//Delete an order and also the related invoice.
connection.BulkDelete(order)
          .AlsoBulkDelete(order => order.Invoice);

//Delete a list of orders and also the related invoice to every order.
connection.BulkDelete(orders)
          .AlsoBulkDelete(order => order.Invoice);
{% endhighlight %}

## Also Bulk Delete with "One to Many" Relation

The Dapper Plus AlsoBulkDelete method allow deleting related items with a "One to Many" relation.

{% include template-example.html %} 
{% highlight csharp %}

//Delete an order and also all related items.
connection.BulkDelete(order)
          .AlsoBulkDelete(order => order.Items);

//Delete a list of orders and also all related items to every order.
connection.BulkDelete(orders);
          .AlsoBulkDelete(order => order.Items);
{% endhighlight %}

## Also Bulk Delete and Mixed Relation

The Dapper Plus AlsoBulkDelete method allow deleting related item(s) with any relation.

{% include template-example.html %} 
{% highlight csharp %}

//Delete an order, also all related items and also the related invoice.
connection.BulkDelete(order)
          .AlsoBulkDelete(order => order.Items, order => order.Invoice);

//Delete a list of orders, also all related items to every order and also the related invoice 
//to every order.
connection.BulkDelete(orders)
          .AlsoBulkDelete(order => order.Items, order => order.Invoice);
{% endhighlight %}

## Also Bulk Delete Chain Action

The Dapper Plus AlsoBulkDelete method allow chaining multiple bulk action methods.

{% include template-example.html %} 
{% highlight csharp %}

//Delete an order and also all related items. Delete an invoice and also all related invoice items.
connection.BulkDelete(order)
          .AlsoBulkDelete(order => order.Items)
          .BulkDelete(invoice)
          .AlsoBulkDelete(invoice => invoice.Items);
//Delete a list of orders and also all related items to every order. Delete a list of invoices and 
//also all related items to every invoice.
connection.BulkDelete(orders)
          .AlsoBulkDelete(order => order.Items)
          .BulkDelete(invoices)
          .AlsoBulkDelete(invoice => invoice.Items);

{% endhighlight %}

************************
The Dapper Plus BulkDelete method allow to DELETE entities in a database table or a view.

## Bulk Delete Entity

The Dapper Plus BulkDelete method allow deleting a single or multiple entities of the same type.

{% include template-example.html %} 
{% highlight csharp %}

//Delete a single order.
connection.BulkDelete(order);

//Delete multiple orders.
connection.BulkDelete(order1, order2, order3);
{% endhighlight %}

## Bulk Delete IEnumerable<TEntity>

The Dapper Plus BulkDelete method allow deleting a single enumerable or multiple enumerable of entities of the same type.

{% include template-example.html %} 
{% highlight csharp %}

//Delete a list of orders.
connection.BulkDelete(orders);

//Delete multiple list of orders.
connection.BulkDelete(orders1, orders2, orders3);
{% endhighlight %}

## Bulk Delete with "One to One" Relation

The Dapper Plus BulkDelete method allow deleting a related item with a "One to One" relation.

{% include template-example.html %} 
{% highlight csharp %}

//Delete an order and the related invoice.
connection.BulkDelete(order, order => order.Invoice);

//Delete a list of orders and the related invoice to every order.
connection.BulkDelete(orders, order => order.Invoice);
{% endhighlight %}

## Bulk Delete with "One to Many" Relation

The Dapper Plus BulkDelete method allow deleting related items with a "One to Many" relation.

{% include template-example.html %} 
{% highlight csharp %}

//Delete an order and all related items.
connection.BulkDelete(order, order => order.Items);

//Delete a list of orders and all related items to every order.
connection.BulkDelete(orders, order => order.Items);
{% endhighlight %}

## Bulk Delete with "Mixed" Relation

The Dapper Plus BulkDelete method allow deleting related item(s) with any relation.


{% include template-example.html %} 
{% highlight csharp %}

//Delete an order, all related items, and the related invoice.
connection.BulkDelete(order, order => order.Items, order => order.Invoice);

//Delete a list of orders, all related items to every order, and the related invoice to every order.
connection.BulkDelete(orders, order => order.Items, order => order.Invoice);
{% endhighlight %}

## Bulk Delete Chain Action

The Dapper Plus BulkDelete method allow chaining multiple bulk action methods.

{% include template-example.html %} 
{% highlight csharp %}
//Delete an order and all related items. Delete an invoice and all related invoice items.
connection.BulkDelete(order, order => order.Items)
          .BulkDelete(invoice, invoice => invoice.Items);

//Delete a list of orders and all related items to every order. Delete a list of invoices and 
//all related items to every invoice.
connection.BulkDelete(orders, order => order.Items)
          .BulkDelete(invoices, invoice => invoice.Items);
{% endhighlight %}
