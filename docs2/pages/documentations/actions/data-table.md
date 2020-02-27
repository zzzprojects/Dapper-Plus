# Datatable


## Definition

Dapper Plus can also perform operations on DataTable


```csharp

var dt = new DataTable();
dt.Columns.Add("ID", typeof(int));
dt.Columns.Add("IntColumn", typeof(int));

for (int i = 0; i < 5; i++)
{
	dt.Rows.Add(DBNull.Value, i);
}

DapperPlusManager.Entity<DataTable>("Map_01")
	.Table("Left")
	.Identity("ID")
	.Map("IntColumn");

using (var conn = My.ConnectionFactory())
{
	conn.Open();
	
	conn.BulkInsert("Map_01", dt);
}

```
