# Batch Options

## Definition

Dapper Plus Mapper allows configuring batch options.

| Name	   | Description |
| :--------| :-----------|
|BatchDelayInterval	|Sets the delay interval to wait between every batch (in milliseconds)|
|BatchSize	|Sets the size of the batch.|
|BatchTimeout	|Sets the batch timeout (in seconds).|

## Batch Delay Interval

Sets the delay interval to wait between every batch (in milliseconds). For example, configure order to wait for 1 second (1000 milliseconds) between every batch.


```csharp
//Default
DapperPlusManager.MapperFactory = mapper => mapper.BatchDelayInterval(1000);

//Instance
DapperPlusManager.Entity<Order>().BatchDelayInterval(1000);
```

## Batch Size

Sets the size of the batch. Configure the entity order to save entities in a batch of 500 records.


```csharp
//Default
DapperPlusManager.MapperFactory = mapper => mapper.BatchSize(500);

//Instance
DapperPlusManager.Entity<Order>().BatchSize(500);
```

## Batch Timeout

Sets the batch timeout (in seconds). Configure the entity order to timeout after 3 minutes (180 seconds).


```csharp
//Default
DapperPlusManager.MapperFactory = mapper => mapper.BatchTimeout(180);

//Instance
DapperPlusManager.Entity<Order>().BatchTimeout(180);
```

