using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Z.BulkOperations;

namespace Z.Dapper.Plus
{
    public partial class DapperPlusAction
    {
        /// <summary>Executes this object.</summary>
        public void Execute()
        {
            if (IsExecuted) return;

            if (DataSource == null)
            {
                IsExecuted = true;
                return;
            }

            var bulkOperation = new BulkOperation
            {
                Connection = (DbConnection) Connection
            };

            var mapperKey = "";

            var enumerableDataSource = DataSource as IEnumerable<object>;
            if (enumerableDataSource != null)
            {
                var first = enumerableDataSource.FirstOrDefault();

                if (first == null)
                {
                    IsExecuted = true;
                    return;
                }

                var enumerableFirst = first as IEnumerable<object>;
                if (enumerableFirst != null)
                {
                    // List<List<Entity>>
                    var list = enumerableDataSource.Where(x => x != null).Cast<IEnumerable<object>>().SelectMany(x => x).ToList();

                    var firstElement = list[0];

                    // GET mapper key
                    mapperKey = DapperPlusManager.GetFullMapperKey(firstElement.GetType(), Key);

                    // Convert DataSource to List<Entity>
                    var castMethod = typeof (Enumerable).GetMethod("Cast");
                    castMethod = castMethod.MakeGenericMethod(firstElement.GetType());
                    var toListMethod = typeof (Enumerable).GetMethod("ToList");
                    toListMethod = toListMethod.MakeGenericMethod(firstElement.GetType());
                    var obj = castMethod.Invoke(null, new[] {list});
                    obj = toListMethod.Invoke(null, new[] {obj});
                    DataSource = obj;
                }
                else if (DataSource.GetType().GetGenericArguments()[0] == typeof (object))
                {
                    // List<object> => List<Entity>
                    var type = first.GetType();

                    // GET mapper key
                    mapperKey = DapperPlusManager.GetFullMapperKey(type, Key);

                    // Convert DataSource to List<Entity>
                    var castMethod = typeof (Enumerable).GetMethod("Cast");
                    castMethod = castMethod.MakeGenericMethod(type);
                    var toListMethod = typeof (Enumerable).GetMethod("ToList");
                    toListMethod = toListMethod.MakeGenericMethod(type);
                    var obj = castMethod.Invoke(null, new[] {DataSource});
                    obj = toListMethod.Invoke(null, new[] {obj});
                    DataSource = obj;
                }
                else
                {
                    // List<Entity>

                    // GET mapper key
                    mapperKey = DapperPlusManager.GetFullMapperKey(first.GetType(), Key);
                }
            }
            else
            {
                // item

                // GET mapper key
                mapperKey = DapperPlusManager.GetFullMapperKey(DataSource.GetType(), Key);

                // CREATE list
                var list = new List<object> {DataSource};

                // Convert List<object> to List<Entity>
                var castMethod = typeof (Enumerable).GetMethod("Cast");
                castMethod = castMethod.MakeGenericMethod(DataSource.GetType());
                var toListMethod = typeof (Enumerable).GetMethod("ToList");
                toListMethod = toListMethod.MakeGenericMethod(DataSource.GetType());
                var obj = castMethod.Invoke(null, new[] {list});
                obj = toListMethod.Invoke(null, new[] {obj});
                DataSource = obj;
            }

            DapperPlusEntityMapper config;

            if (!DapperPlusManager.MapperCache.TryGetValue(mapperKey, out config))
            {
                // CHECK for Entity Framework Proxy Type
                if (mapperKey.StartsWith("zzz_proxy;"))
                {
                    var mapperProxy = new List<DapperPlusEntityMapper>();
                    // Try to find if one mapping could correspond
                    foreach (var keyValue in DapperPlusManager.MapperCache)
                    {
                        var key = keyValue.Key;
                        var prefix = string.IsNullOrEmpty(Key) ? "zzz_null" : Key;

                        // MUST start with the same suffix
                        if (!key.StartsWith(prefix)) continue;

                        var suffix = key.Split('.').Last().Split('+').Last();
                        var mapperSuffix = mapperKey.Split(';').Last();

                        if (suffix.Length < 20)
                        {
                            // MUST BE Equal
                            if (suffix != mapperSuffix) continue;
                        }
                        else
                        {
                            // MUST START with same name but only one!
                            if (!suffix.StartsWith(mapperSuffix)) continue;
                        }

                        mapperProxy.Add(keyValue.Value);
                    }

                    if (mapperProxy.Count == 1)
                    {
                        config = mapperProxy[0];
                    }
                }

                if (config == null)
                {
                    if (DapperPlusManager.ThrowErrorIfNotMapped)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("Mapping Not Found!");
                        sb.AppendLine("Current MapperKey: " + mapperKey);
                        sb.AppendLine("Possible Mapping:");
                        foreach (var keyValue in DapperPlusManager.MapperCache)
                        {
                            sb.AppendLine("   - " + keyValue.Key);
                        }

                        throw new Exception(sb.ToString());
                    }
                    else
                    {
                        var type = DataSource.GetType();
                        var elementType = type.GetGenericArguments()[0];
                        var constructor = typeof(DapperPlusEntityMapper<>).MakeGenericType(elementType).GetConstructor(new Type[0]);
                        config = (DapperPlusEntityMapper)constructor.Invoke(new object[0]);
                    }
 
                }
            }

            bulkOperation._isDapperPlus = true;
            bulkOperation.DataSource = DataSource;
            bulkOperation.AllowDuplicateKeys = true;
            bulkOperation.CaseSensitive = CaseSensitiveType.DestinationInsensitive;

            if (Kind == DapperPlusActionKind.Insert)
            {
                ApplyConfig(bulkOperation, config._configInsert);
                bulkOperation.BulkInsert();
            }
            else if (Kind == DapperPlusActionKind.Update)
            {
                ApplyConfig(bulkOperation, config._configInsert);
                bulkOperation.BulkUpdate();
            }
            else if (Kind == DapperPlusActionKind.Delete)
            {
                ApplyConfig(bulkOperation, config._configInsert);
                bulkOperation.BulkDelete();
            }
            else if (Kind == DapperPlusActionKind.Merge)
            {
                ApplyConfig(bulkOperation, config._configInsert);
                bulkOperation.BulkMerge();
            }

            IsExecuted = true;
        }
    }
}