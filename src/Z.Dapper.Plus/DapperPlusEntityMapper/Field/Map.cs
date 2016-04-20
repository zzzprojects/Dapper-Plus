using System.Collections.Generic;

namespace Z.Dapper.Plus
{
    public partial class DapperPlusEntityMapper
    {
        /// <summary>The column mappings.</summary>
        internal List<DapperPlusColumnMapping> _columnMappings;

        /// <summary>The identity accessors.</summary>
        internal List<PropertyOrFieldAccessor> _identityAccessors = new List<PropertyOrFieldAccessor>();

        /// <summary>The ignore accessors.</summary>
        internal List<PropertyOrFieldAccessor> _ignoreAccessors = new List<PropertyOrFieldAccessor>();

        /// <summary>The value indicating if identity configuration is modified.</summary>
        internal bool? _isIdentityModified;

        /// <summary>The value indicating if ignore configuration is modified.</summary>
        internal bool? _isIgnoreModified;

        /// <summary>The value indicating if key configuration is modified.</summary>
        internal bool? _isKeyModified;

        /// <summary>The value indicating if map configuration is modified.</summary>
        internal bool? _isMapModified;

        /// <summary>The value indicating if output configuration is modified.</summary>
        internal bool? _isOutputModified;

        /// <summary>The key accessors.</summary>
        internal List<PropertyOrFieldAccessor> _keyAccessors = new List<PropertyOrFieldAccessor>();

        /// <summary>The map accessors.</summary>
        internal List<PropertyOrFieldAccessor> _mapAccessors = new List<PropertyOrFieldAccessor>();

        /// <summary>The output accessors.</summary>
        internal List<PropertyOrFieldAccessor> _outputAccessors = new List<PropertyOrFieldAccessor>();
    }
}