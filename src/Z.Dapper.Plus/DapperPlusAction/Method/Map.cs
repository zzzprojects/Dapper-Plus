using System.Collections.Generic;
using Z.BulkOperations;

namespace Z.Dapper.Plus
{
    public partial class DapperPlusAction
    {
        /// <summary>Maps.</summary>
        /// <param name="bulkOperation">The bulk operation.</param>
        /// <param name="config">The configuration.</param>
        public void Map(BulkOperation bulkOperation, DapperPlusEntityMapper config)
        {
            var isMapModified = config.IsMapModified();
            var isKeyModified = config.IsKeyModified();
            var isOutputModified = config.IsOutputModified();
            var isIdentityModified = config.IsIdentityModified();
            var isIgnoreModified = config.IsIgnoreModified();

            var isModified = isMapModified.HasValue && isMapModified.Value
                             || isKeyModified.HasValue && isKeyModified.Value
                             || isOutputModified.HasValue && isOutputModified.Value
                             || isIdentityModified.HasValue && isIdentityModified.Value
                             || isIgnoreModified.HasValue && isIgnoreModified.Value;

            if (!isModified) return;

            config._mapAccessors = config.GetMapAccessors();
            config._keyAccessors = config.GetKeyAccessors();
            config._outputAccessors = config.GetOutputAccessors();
            config._identityAccessors = config.GetIdentityAccessors();
            config._ignoreAccessors = config.GetIgnoreAccessors();

            // SET AutoMap value
            AutoMap(config);

            var columnMappings = new List<DapperPlusColumnMapping>();
            config._columnMappings = columnMappings;

            foreach (var accessor in config._mapAccessors)
            {
                if (accessor.IsCalculated)
                {
                    // NOT Supported yet
                }
                else
                {
                    columnMappings.Add(new DapperPlusColumnMapping {SourceName = accessor.ToString(), DestinationName = accessor.Member, Input = true});
                }
            }

            foreach (var accessor in config._outputAccessors)
            {
                var columnMapping = columnMappings.Find(x => x.SourceName == accessor.ToString() && x.DestinationName == accessor.Member);
                if (columnMapping != null)
                {
                    columnMapping.Output = true;
                }
                else
                {
                    columnMappings.Add(new DapperPlusColumnMapping {SourceName = accessor.ToString(), DestinationName = accessor.Member, Output = true});
                }
            }

            foreach (var accessor in config._keyAccessors)
            {
                var columnMapping = columnMappings.Find(x => x.SourceName == accessor.ToString() && x.DestinationName == accessor.Member);
                if (columnMapping != null)
                {
                    columnMapping.IsPrimaryKey = true;
                }
                else
                {
                    columnMappings.Add(new DapperPlusColumnMapping {SourceName = accessor.ToString(), DestinationName = accessor.Member, IsPrimaryKey = true});
                }
            }

            foreach (var accessor in config._identityAccessors)
            {
                var columnMapping = columnMappings.Find(x => x.SourceName == accessor.ToString() && x.DestinationName == accessor.Member);
                if (columnMapping != null)
                {
                    columnMapping.IsIdentity = true;
                }
                else
                {
                    columnMappings.Add(new DapperPlusColumnMapping {SourceName = accessor.ToString(), DestinationName = accessor.Member, IsIdentity = true});
                }
            }

            config._isIdentityModified = false;
            config._isIgnoreModified = false;
            config._isKeyModified = false;
            config._isMapModified = false;
            config._isOutputModified = false;
        }
    }
}