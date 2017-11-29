---
permalink: also-bulk-insert
---

## Definition

The Dapper Plus AlsoBulkInsert method allow to INSERT entities in a database table or a view using a lambda expression.

The lambda expression use the entity or the IEnumerable<TEntity> from the last Bulk[Action] or ThenBulk[Action] chained method. (The action can be an insert, update, delete or merge operation).

## Also Bulk Insert with "One to One" Relation

The Dapper Plus AlsoBulkInsert method allow inserting a related item with a "One to One" relation.

{% include template-example.html %} 
{% highlight csharp %}

//Insert an order and also the related invoice.
connection.BulkInsert(order)
          .AlsoBulkInsert(order => order.Invoice);

//Insert a list of orders and also the related invoice to every order.
connection.BulkInsert(orders)
          .AlsoBulkInsert(order => order.Invoice);
{% endhighlight %}

## Also Bulk Insert with "One to Many" Relation

The Dapper Plus AlsoBulkInsert method allow inserting related items with a "One to Many" relation.

{% include template-example.html %} 
{% highlight csharp %}
//Insert an order and also all related items.
connection.BulkInsert(order)
          .AlsoBulkInsert(order => order.Items);

//Insert a list of orders and also all related items to every order.
connection.BulkInsert(orders);
          .AlsoBulkInsert(order => order.Items);
{% endhighlight %}

## Also Bulk Insert and Mixed Relation

The Dapper Plus AlsoBulkInsert method allow inserting related item(s) with any relation.

{% include template-example.html %} 
{% highlight csharp %}

//Insert an order, also all related items and also the related invoice.
connection.BulkInsert(order)
          .AlsoBulkInsert(order => order.Items, order => order.Invoice);

//Insert a list of orders, also all related items to every order and also the related invoice to every order.
connection.BulkInsert(orders)
          .AlsoBulkInsert(order => order.Items, order => order.Invoice);
{% endhighlight %}

## Also Bulk Insert Chain Action

The Dapper Plus AlsoBulkInsert method allow chaining multiple bulk action methods.

{% include template-example.html %} 
{% highlight csharp %}

//Insert an order and also all related items. Insert an invoice and also all related invoice items.
connection.BulkInsert(order)
          .AlsoBulkInsert(order => order.Items)
          .BulkInsert(invoice)
          .AlsoBulkInsert(invoice => invoice.Items);
//Insert a list of orders and also all related items to every order. Insert a list of invoices and also 
//all related items to every invoice.
connection.BulkInsert(orders)
          .AlsoBulkInsert(order => order.Items)
          .BulkInsert(invoices)
          .AlsoBulkInsert(invoice => invoice.Items);
{% endhighlight %}
