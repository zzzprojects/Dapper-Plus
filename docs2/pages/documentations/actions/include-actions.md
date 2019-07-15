# Include Actions

## Include Actions

The Dapper Plus Include method allows resolving issues with multiple "ThenBulk[Action]" method.

### Example

Without include method (The invoice cannot be chained to last action)

#### Without include Example
```csharp
connection.BulkInsert(orders)
          .ThenInsert(order => order.Items)
          .ThenInsert(orderItem => orderItem.Metas)	  
          // Oops! The related invoice cannot be chained.
          //.ThenInsert(orderItemMeta => ...);
```

With include method

#### With include Example
```csharp
connection.BulkInsert(orders)
          .Include(x => x.ThenInsert(order => order.Items)
                         .ThenInsert(orderItem => orderItem.Metas))
          .Include(x => x.ThenInsert(order => order.Invoice)
                         .ThenInsert(Invoice => invoice.Items));
```
