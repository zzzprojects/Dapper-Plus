# Mapper Factory

## Definition

Sets the mapper factory to use to create a new Mapper.

Existing Mapper instance is not affected by the change from mapper factory.

### Mapper Factory Examples
```csharp
// Use default batch size (Mapper created before MapperFactory configuration)
DapperPlusManager.Entity<Order>();

DapperPlusManager.MapperFactory = mapper => mapper.BatchSize(500);

// Use batch size = 500; (Mapper created after MapperFactory configuration)
DapperPlusManager.Entity<Customer>();
```
