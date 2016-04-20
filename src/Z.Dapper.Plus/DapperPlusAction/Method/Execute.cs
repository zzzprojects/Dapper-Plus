using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
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
                var elementType = DataSource.GetType().GetElementType();
                var constructor = typeof (DapperPlusEntityMapper<>).MakeGenericType(elementType).GetConstructor(new Type[0]);
                config = (DapperPlusEntityMapper) constructor.Invoke(new object[0]);
            }

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