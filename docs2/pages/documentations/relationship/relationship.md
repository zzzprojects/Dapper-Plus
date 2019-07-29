# Relationship

In our examples, you often see us chaining multiple actions without specifying the relation parent/child even when the parent use an auto-generated identity value.


```csharp
connection.BulkInsert(lefts, left => left.Rights);

connection.BulkInsert(lefts)
          .ThenBulkInsert(left => left.Rights);
```


In this tutorial, you will learn how to handle this kind of relation:
- [Foreign Key Property](#foreign-key-property)
- [Navigation Property](#navigation-property)

## Foreign Key Property
A foreign key property happens when the child entity duplicates the value of the parent.

### Example

```csharp
public class Left
{
    public int ID { get; set; }
    public int IntColumn { get; set; }
    public List<Right> Rights { get; set; }
}

public class Right
{
    public int ID { get; set; }
    public int IntColumn { get; set; }

    // Foreign Key to Left Entity
    public int LeftID { get; set; }
}
```


### With AfterAction Event
After an insert or merge happen on the parent, we assign the "LeftID" value of the child using the value generated "ID" from the parent.

#### Example

```csharp
// MAP
DapperPlusManager.Entity<Left>().Table("Left")
    .Identity(x => x.ID)
    .Ignore(x => x.Rights)
    .AfterAction((kind, x) =>
    {
        if (kind == DapperPlusActionKind.Insert || kind == DapperPlusActionKind.Merge)
        {
            x.Rights.ForEach(y => y.LeftID = x.ID);
        }
    });

DapperPlusManager.Entity<Right>().Table("Right");

// EXECUTE
connection.BulkInsert(lefts)
          .ThenBulkInsert(left => left.Rights);
```

### With ThenForEach Method
After an insert or merge happen on the parent, we assign the "LeftID" value of the child using the value generated "ID" from the parent.

#### Example

```csharp
// MAP
DapperPlusManager.Entity<Left>().Table("Left")
    .Identity(x => x.ID)
    .Ignore(x => x.Rights);

DapperPlusManager.Entity<Right>().Table("Right");

// EXECUTE
connection.BulkInsert(lefts)
          .ThenForEach(x => x.Rights.ForEach(y => y.LeftID = x.ID))
          .ThenBulkInsert(x => x.Rights);
```

## Navigation Property
A navigation property happens when the child has a reference to the parent.

### Example

```csharp
public class Left
{
    public int ID { get; set; }
    public int IntColumn { get; set; }
    public List<Right> Rights { get; set; }
}

public class Right
{
    public int ID { get; set; }
    public int IntColumn { get; set; }

    // Navigation Property
    public Left Left { get; set; }
}
```

### With AfterAction Event
After the action happens, we assign the Left navigation property with the parent.

#### Example

```csharp
// MAP
DapperPlusManager.Entity<Left>().Table("Left")
    .Identity(x => x.ID)
    .Ignore(x => x.Rights)
    .AfterAction((kind, x) =>
    {
        if (kind == DapperPlusActionKind.Insert || kind == DapperPlusActionKind.Merge)
        {
            x.Rights.ForEach(y => y.Left = x);
        }
    });

DapperPlusManager.Entity<Right>().Table("Right")
    .Map(x => new
    {
        x.ID,
        LeftID = x.Left.ID,
        x.IntColumn
    });

// EXECUTE
connection.BulkInsert(lefts)
          .ThenBulkInsert(left => left.Rights);
```

### With ThenForEach Method
After the action happens, we assign the Left navigation property with the parent.

#### Example

```csharp
// MAP
DapperPlusManager.Entity<Left>().Table("Left")
    .Identity(x => x.ID)
    .Ignore(x => x.Rights);

DapperPlusManager.Entity<Right>().Table("Right")
    .Map(x => new
    {
        x.ID,
        LeftID = x.Left.ID,
        x.IntColumn
    });

// EXECUTE
connection.BulkInsert(lefts)
          .ThenForEach(x => x.Rights.ForEach(y => y.Left = x))
          .ThenBulkInsert(x => x.Rights);
```
