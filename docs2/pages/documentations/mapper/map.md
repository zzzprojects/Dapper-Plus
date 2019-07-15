# Map

## Definition

Dapper Plus Mapper allows mapping the conceptual model (Entity) with the storage model (Database).


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


```csharp
DapperPlusManager.Entity<Order>()
                 .Identity(x => x.OrderID);
```

## Mapper - Ignore

Sets column(s) to ignore.


```csharp
//Ignore single column
DapperPlusManager.Entity<Order>()
                 .Ignore(x => x.Column1);

//Ignore many columns
DapperPlusManager.Entity<Order>()
                 .Ignore(x => new { x.Column1, x.Column2, x.Column3 });
```

## Mapper - Key

Sets column(s) to use for Primary Key (update, delete, and merge action).


```csharp
//Single Key
DapperPlusManager.Entity<Order>()
                 .Key(order => order.OrderID);

//Composite Key
DapperPlusManager.Entity<Order>()
                 .Key(order => new { order.ApplicationID, order.OrderCode });
```

## Mapper - Map

Sets column(s) to input to the destination table. 

Map with an anonymous type. Sets the property name only if different from the database.


```csharp
DapperPlusManager.Entity<Order>()
                 .Map(order => new { qty = order.TotalQuantity, order.TotalPrice });
```

Map with hardcoded string


```csharp
DapperPlusManager.Entity<Order>()
                 .Map(order => order.TotalQuantity, "qty")
				 .Map(order => order.TotalPrice, "TotalPrice");
```

Map with constant value


```csharp
DapperPlusManager.Entity<Order>()
                 .Map(order => new { ConstantColumn1 = 1)
				 .Map(order => 2, "ConstantColumn2");
```


```csharp
DapperPlusManager.Entity<Order>())
                 .Map(order => order.TotalPrice / order.TotalQuantity, "AvgPrice2");

DapperPlusManager.Entity<Order>()
                 .Map(order => order.TotalQuantity, "qty")
				 .Map(order => order.TotalPrice, "TotalPrice");
```

## Mapper - MapValue
Sets value to map to the destination table.

Map with constant value


```csharp
DapperPlusManager.Entity<Order>()
		 .MapValue(2, "ConstantColumn2");
```

Map with variable


```csharp
var constantValue = 2;
DapperPlusManager.Entity<Order>()
		 .MapValue(constantValue, "ConstantColumn2");
```
	
## Mapper - Output

Sets column(s) to output from the destination table (insert, update, and merge action).


```csharp
//Output single column
DapperPlusManager.Entity<Order>()
                 .Output(order => order.Column1);

//Output many columns
DapperPlusManager.Entity<Order>()
                 .Output(order => new { order.Column1, order.Column2, order.Column3 });
```

## Mapper - Table

Sets the destination table or view name (including schema). By default, the name mapped is singular.


```csharp
DapperPlusManager.Entity<Order>()
                 .Table("zzz.customers");
```
