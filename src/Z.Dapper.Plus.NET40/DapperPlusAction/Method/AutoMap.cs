using System.Collections.Generic;

#if NET45
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
#endif

namespace Z.Dapper.Plus
{
    public partial class DapperPlusAction
    {
        /// <summary>Automatic map.</summary>
        /// <param name="entityMapper">The entity mapper.</param>
        public void AutoMap(DapperPlusEntityMapper entityMapper)
        {
            var entityType = entityMapper.GetType().GetGenericArguments()[0];
            var properties = entityType.GetProperties();

#if NET45
    // Key
            if (entityMapper._keyAccessors.Count == 0)
            {
                foreach (var property in properties)
                {
                    if (property.GetIndexParameters().Length == 0

                        && !property.IsDefined(typeof (NotMappedAttribute))
                        && property.IsDefined(typeof (KeyAttribute))
                        )
                    {
                        var destinationName = property.Name;

#if NET45
                        if (property.IsDefined(typeof (ColumnAttribute)))
                        {
                            var attribute = (ColumnAttribute) property.GetCustomAttribute(typeof (ColumnAttribute));
                            if (!string.IsNullOrEmpty(attribute.Name))
                            {
                                destinationName = attribute.Name;
                            }
                        }
#endif

                        entityMapper._keyAccessors.Add(new PropertyOrFieldAccessor(property) {Member = destinationName});
                    }
                }
            }
#endif

#if NET45
    // Identity
            if (entityMapper._identityAccessors.Count == 0)
            {
                foreach (var property in properties)
                {
                    if (property.GetIndexParameters().Length == 0
                        && !property.IsDefined(typeof (NotMappedAttribute))
                        && property.IsDefined(typeof (DatabaseGeneratedAttribute))
                        && ((DatabaseGeneratedAttribute) property.GetCustomAttribute(typeof (DatabaseGeneratedAttribute))).DatabaseGeneratedOption == DatabaseGeneratedOption.Identity)
                    {
                        var destinationName = property.Name;

#if NET45
                        if (property.IsDefined(typeof (ColumnAttribute)))
                        {
                            var attribute = (ColumnAttribute) property.GetCustomAttribute(typeof (ColumnAttribute));
                            if (!string.IsNullOrEmpty(attribute.Name))
                            {
                                destinationName = attribute.Name;
                            }
                        }
#endif

                        entityMapper._identityAccessors.Add(new PropertyOrFieldAccessor(property) {Member = destinationName});
                    }
                }
            }
#endif

#if NET45
    // Output
            if (entityMapper._outputAccessors.Count == 0)
            {
                foreach (var property in properties)
                {
                    if (property.GetIndexParameters().Length == 0
                        && !property.IsDefined(typeof (NotMappedAttribute))
                        && property.IsDefined(typeof (DatabaseGeneratedAttribute))
                        && ((DatabaseGeneratedAttribute) property.GetCustomAttribute(typeof (DatabaseGeneratedAttribute))).DatabaseGeneratedOption == DatabaseGeneratedOption.Computed)
                    {
                        var destinationName = property.Name;

#if NET45
                        if (property.IsDefined(typeof (ColumnAttribute)))
                        {
                            var attribute = (ColumnAttribute) property.GetCustomAttribute(typeof (ColumnAttribute));
                            if (!string.IsNullOrEmpty(attribute.Name))
                            {
                                destinationName = attribute.Name;
                            }
                        }
#endif

                        entityMapper._outputAccessors.Add(new PropertyOrFieldAccessor(property) {Member = destinationName});
                    }
                }
            }
#endif

            // Map
            if (entityMapper._mapAccessors.Count == 0)
            {
                var ignoreAccessors = new HashSet<string>();
                var outputAccessors = new HashSet<string>();
                var identityAccessors = new HashSet<string>();

                if (entityMapper._ignoreAccessors.Count > 0)
                {
                    entityMapper._ignoreAccessors.ForEach(x => ignoreAccessors.Add(x.ToString()));
                }

                if (entityMapper._outputAccessors.Count > 0)
                {
                    entityMapper._outputAccessors.ForEach(x => outputAccessors.Add(x.ToString()));
                }

                if (entityMapper._identityAccessors.Count > 0)
                {
                    entityMapper._identityAccessors.ForEach(x => identityAccessors.Add(x.ToString()));
                }

                foreach (var property in properties)
                {
                    if (property.GetIndexParameters().Length == 0
#if NET45
                        && !property.IsDefined(typeof (NotMappedAttribute))
#endif
                        && !ignoreAccessors.Contains(property.Name)
                        && !outputAccessors.Contains(property.Name))
                    {
                        var destinationName = property.Name;

#if NET45
                        if (property.IsDefined(typeof (ColumnAttribute)))
                        {
                            var attribute = (ColumnAttribute) property.GetCustomAttribute(typeof (ColumnAttribute));
                            if (!string.IsNullOrEmpty(attribute.Name))
                            {
                                destinationName = attribute.Name;
                            }
                        }
#endif

                        entityMapper._mapAccessors.Add(new PropertyOrFieldAccessor(property) {Member = destinationName});
                    }
                }
            }
        }
    }
}