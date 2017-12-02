---
permalink: temporary-table-options
---

## Definition

Dapper Plus Mapper allow configuring temporary table options.

| Name	   | Description |
| :--------| :-----------|
|TemporaryTableBatchByTable	|Sets the number of batches a temporary table can hold.|
|TemporaryTableInsertBatchSize	|Sets the batch size for inserting in the temporary table.|
|TemporaryTableMinRecord	|Sets the minimum number of records before using the temporary table strategy.|
|TemporaryTableSchemaName	|Sets the temporary table schema name to use.|

## TemporaryTableBatchByTable

Sets the number of batches a temporary table can hold. For example, configure the entity order to create a temporary table every five batches.

{% include template-example.html %} 
{% highlight csharp %}
//Default
DapperPlusManager.MapperFactory = mapper => mapper.TemporaryTableBatchByTable(5);

//Instance
DapperPlusManager.Entity<Order>().TemporaryTableBatchByTable(5);
{% endhighlight %}

By default, only one temporary table is used.

## TemporaryTableInsertBatchSize

Sets the batch size for inserting in the temporary table. For example, configure the entity order to insert in the temporary table in a batch of 50,000 entities.

{% include template-example.html %} 
{% highlight csharp %}
//Default
DapperPlusManager.MapperFactory = mapper => mapper.TemporaryTableInsertBatchSize(50000);

//Instance
DapperPlusManager.Entity<Order>().TemporaryTableInsertBatchSize(50000);
{% endhighlight %}

The default value is 100,000.

## TemporaryTableMinRecord

Sets the minimum number of records before using the temporary table strategy. For example, configure the entity order to use the temporary table only when inserting 50 or more entities

{% include template-example.html %} 
{% highlight csharp %}
//Default
DapperPlusManager.MapperFactory = mapper => mapper.TemporaryTableMinRecord(50);

//Instance
DapperPlusManager.Entity<Order>().TemporaryTableMinRecord(50);
{% endhighlight %}

The default value is 10.

## TemporaryTableSchemaName

Sets the temporary table schema name to use. For example, configure the entity order to create the temporary table in the "zzz" schema.

{% include template-example.html %} 
{% highlight csharp %}
//Default
DapperPlusManager.MapperFactory = mapper => mapper.TemporaryTableSchemaName("zzz");

//Instance
DapperPlusManager.Entity<Order>().TemporaryTableSchemaName("zzz");
{% endhighlight %}

The default schema name is "dbo".

## Provider Supported

 - SQL Server
 - SQL Azure
