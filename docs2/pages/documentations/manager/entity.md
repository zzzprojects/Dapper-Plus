# Entity

## Definition

Adds or updates the mapper associated with the type and mapping key.

### Entity

Adds or updates the mapper associated with the type.

### Entity Examples
```csharp

DapperPlusManager.Entity<Order>()
                 .Table("Orders");

connection.BulkInsert(orders);
```

### Entity with Mapping Key

Adds or updates the mapper associated with the type and mapping key.

### Entity with Mapping Key Examples
```csharp
DapperPlusManager.Entity<Order>("CustomKey")
                 .Table("CustomOrders");

connection.BulkInsert("CustomKey", orders);
```

We highly recommend using an enum value for the mapping key

### BulkSaveChanges Examples 
```csharp

DapperPlusManager.Entity<Order>(MappingKey.CustomKey1.ToString())
                 .Table("CustomOrders");

connection.BulkInsert(MappingKey.CustomKey1.ToString(), orders);
```
