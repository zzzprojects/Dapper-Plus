using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z.Dapper.Plus.Mapper
{
    internal static class AutoMapper
    {
        internal static string GetEntityName(Type entityType)
        {
            var tableAttribute = GetTableAttribute(entityType);

            return tableAttribute != null ? $"[{tableAttribute.Schema}].[{tableAttribute.Name}]" : null;
        }

        private static TableAttribute GetTableAttribute(Type type)
        {
            return (TableAttribute)Attribute.GetCustomAttribute(type, typeof(TableAttribute));
        }
    }
}
