using System.Collections.Generic;

namespace Z.Dapper.Plus
{
    public partial class DapperPlusEntityMapper
    {
        /// <summary>Gets the value indicating if identity configuration is modified.</summary>
        /// <returns>The value indicating if identity configuration is modified.</returns>
        public bool? IsIdentityModified()
        {
            return _isIdentityModified ?? (!_isMasterConfig ? _masterConfig._isIdentityModified : null);
        }

        /// <summary>Gets the value indicating if ignore configuration is modified.</summary>
        /// <returns>The value indicating if ignore configuration is modified.</returns>
        public bool? IsIgnoreModified()
        {
            return _isIgnoreModified ?? (!_isMasterConfig ? _masterConfig._isIgnoreModified : null);
        }

        /// <summary>Gets the value indicating if key configuration is modified.</summary>
        /// <returns>The value indicating if key configuration is modified.</returns>
        public bool? IsKeyModified()
        {
            return _isKeyModified ?? (!_isMasterConfig ? _masterConfig._isKeyModified : null);
        }

        /// <summary>Gets the value indicating if map configuration is modified.</summary>
        /// <returns>The value indicating if map configuration is modified.</returns>
        public bool? IsMapModified()
        {
            return _isMapModified ?? (!_isMasterConfig ? _masterConfig._isMapModified : null);
        }

        /// <summary>Gets the value indicating if output configuration is modified.</summary>
        /// <returns>The value indicating if output configuration is modified.</returns>
        public bool? IsOutputModified()
        {
            return _isOutputModified ?? (!_isMasterConfig ? _masterConfig._isOutputModified : null);
        }

        /// <summary>Gets the value indicating if identity configuration is modified.</summary>
        /// <param name="value">true if the identity is modified.</param>
        public void IsIdentityModified(bool value)
        {
            if (_isMasterConfig)
            {
                _configDelete._isIdentityModified = value;
                _configInsert._isIdentityModified = value;
                _configMerge._isIdentityModified = value;
                _configUpdate._isIdentityModified = value;
            }
            else
            {
                _isIdentityModified = value;
            }
        }

        /// <summary>Sets the value indicating if ignore configuration is modified.</summary>
        /// <param name="value">true if the ignore is modified.</param>
        public void IsIgnoreModified(bool value)
        {
            if (_isMasterConfig)
            {
                _configDelete._isIgnoreModified = value;
                _configInsert._isIgnoreModified = value;
                _configMerge._isIgnoreModified = value;
                _configUpdate._isIgnoreModified = value;
            }
            else
            {
                _isIgnoreModified = value;
            }
        }

        /// <summary>Sets the value indicating if key configuration is modified.</summary>
        /// <param name="value">true if the key is modified.</param>
        public void IsKeyModified(bool value)
        {
            if (_isMasterConfig)
            {
                _configDelete._isKeyModified = value;
                _configInsert._isKeyModified = value;
                _configMerge._isKeyModified = value;
                _configUpdate._isKeyModified = value;
            }
            else
            {
                _isKeyModified = value;
            }
        }

        /// <summary>Sets the value indicating if map configuration is modified.</summary>
        /// <param name="value">true if the map is modified.</param>
        public void IsMapModified(bool value)
        {
            if (_isMasterConfig)
            {
                _configDelete._isMapModified = value;
                _configInsert._isMapModified = value;
                _configMerge._isMapModified = value;
                _configUpdate._isMapModified = value;
            }
            else
            {
                _isMapModified = value;
            }
        }

        /// <summary>Sets the value indicating if output configuration is modified.</summary>
        /// <param name="value">true if the output is modified.</param>
        public void IsOutputModified(bool value)
        {
            if (_isMasterConfig)
            {
                _configDelete._isOutputModified = value;
                _configInsert._isOutputModified = value;
                _configMerge._isOutputModified = value;
                _configUpdate._isOutputModified = value;
            }
            else
            {
                _isKeyModified = value;
            }
        }

        /// <summary>Gets key accessors.</summary>
        /// <returns>The key accessors.</returns>
        internal abstract List<PropertyOrFieldAccessor> GetKeyAccessors();

        /// <summary>Gets identity accessors.</summary>
        /// <returns>The identity accessors.</returns>
        internal abstract List<PropertyOrFieldAccessor> GetIdentityAccessors();

        /// <summary>Gets map accessors.</summary>
        /// <returns>The map accessors.</returns>
        internal abstract List<PropertyOrFieldAccessor> GetMapAccessors();

        /// <summary>Gets output accessors.</summary>
        /// <returns>The output accessors.</returns>
        internal abstract List<PropertyOrFieldAccessor> GetOutputAccessors();

        /// <summary>Gets ignore accessors.</summary>
        /// <returns>The ignore accessors.</returns>
        internal abstract List<PropertyOrFieldAccessor> GetIgnoreAccessors();
    }
}