---
permalink: bulk-delete
---

## Definition

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
