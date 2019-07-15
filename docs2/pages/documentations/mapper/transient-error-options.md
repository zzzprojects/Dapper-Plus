# Transient Error Options

## Definition

Dapper Plus Mapper method allows configuring transient options.

| Name	   | Description |
| :--------| :-----------|
|RetryCount	|Set the number of retries when a transient error occurs.|
|RetryInterval	|Set the interval to wait before performing a retry when a transient error occurs.|

## RetryCount

Set the number of retries when a transient error occurs. For example, configure the order entity to retry three times if a transient error occurs.


```csharp
//Default
DapperPlusManager.MapperFactory = mapper => mapper.RetryCount(3);

//Instance
DapperPlusManager.Entity<Order>().RetryCount(3);
```

## RetryInterval

Set the interval to wait before performing a retry when a transient error occurs. For example, configure the order entity to wait for 1 second (1000 milliseconds) before retrying if a transient error occurs.


```csharp
//Default
DapperPlusManager.MapperFactory = mapper => mapper.RetryInterval(1000);

//Instance
DapperPlusManager.Entity<Order>().RetryInterval(1000);
```

## Provider Supported

 - SQL Server
 - SQL Azure
