using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Z.BulkOperations;
using Z.Dapper.Plus.DapperPlusExpressionMapper;

namespace Z.Dapper.Plus
{
    public partial class DapperPlusEntityMapper<T>
    {
        /// <summary>Copy identity configuration from an existing mapper.</summary>
        /// <param name="copyFromConfiguration">The configuration to copy from.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public DapperPlusEntityMapper<T> Identity(DapperPlusEntityMapper<T> copyFromConfiguration)
        {
            IsIdentityModified(true);
            _identity.AddRange(copyFromConfiguration._identity);
            return this;
        }

        /// <summary>Sets identity accessor from the selectors.</summary>
        /// <param name="selectors">The identity selectors.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public DapperPlusEntityMapper<T> Identity(Expression<Func<T, object>> selectors)
        {
            IsIdentityModified(true);
            _identity.Add(new DapperPlusExpressionMapper<T>(selectors));
            return this;
        }

        /// <summary>Sets identity accessor from the selectors.</summary>
        /// <param name="selector">The identity selector.</param>
        /// <param name="destinationName">The destination name.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public DapperPlusEntityMapper<T> Identity(Expression<Func<T, object>> selector, string destinationName)
        {
            IsIdentityModified(true);
            _identity.Add(new DapperPlusExpressionMapper<T>(selector, destinationName));
            return this;
        }

        /// <summary>Copy ignore configuration from an existing mapper.</summary>
        /// <param name="copyFromConfiguration">The configuration to copy from.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public DapperPlusEntityMapper<T> Ignore(DapperPlusEntityMapper<T> copyFromConfiguration)
        {
            IsIgnoreModified(true);
            _ignore.AddRange(copyFromConfiguration._ignore);
            return this;
        }

        /// <summary>Sets ignore accessor from the selectors.</summary>
        /// <param name="selectors">The ignore selectors.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public DapperPlusEntityMapper<T> Ignore(Expression<Func<T, object>> selectors)
        {
            IsIgnoreModified(true);
            _ignore.Add(new DapperPlusExpressionMapper<T>(selectors));
            return this;
        }

        /// <summary>Copy key configuration from an existing mapper.</summary>
        /// <param name="copyFromConfiguration">The configuration to copy from.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public DapperPlusEntityMapper<T> Key(DapperPlusEntityMapper<T> copyFromConfiguration)
        {
            IsKeyModified(true);
            _key.AddRange(copyFromConfiguration._key);
            return this;
        }

        /// <summary>Sets key accessor from the selectors.</summary>
        /// <param name="selectors">The key selectors.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public DapperPlusEntityMapper<T> Key(Expression<Func<T, object>> selectors)
        {
            IsKeyModified(true);
            _key.Add(new DapperPlusExpressionMapper<T>(selectors));
            return this;
        }

        /// <summary>Sets key accessor from the selectors.</summary>
        /// <param name="selector">The key selector.</param>
        /// <param name="destinationName">The destination name.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public DapperPlusEntityMapper<T> Key(Expression<Func<T, object>> selector, string destinationName)
        {
            IsKeyModified(true);
            _key.Add(new DapperPlusExpressionMapper<T>(selector, destinationName));
            return this;
        }

        /// <summary>Copy map configuration from an existing mapper.</summary>
        /// <param name="copyFromConfiguration">The configuration to copy from.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public DapperPlusEntityMapper<T> Map(DapperPlusEntityMapper<T> copyFromConfiguration)
        {
            IsMapModified(true);
            _map.AddRange(copyFromConfiguration._map);
            return this;
        }

        /// <summary>Sets map accessor from the selectors.</summary>
        /// <param name="selectors">The map selectors.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public DapperPlusEntityMapper<T> Map(Expression<Func<T, object>> selectors)
        {
            IsMapModified(true);
            _map.Add(new DapperPlusExpressionMapper<T>(selectors));
            return this;
        }

        /// <summary>Sets map accessor from the selectors.</summary>
        /// <param name="selector">The map selector.</param>
        /// <param name="destinationName">The destination name.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public DapperPlusEntityMapper<T> Map(Expression<Func<T, object>> selector, string destinationName)
        {
            IsMapModified(true);
            _map.Add(new DapperPlusExpressionMapper<T>(selector, destinationName));
            return this;
        }

        /// <summary>Copy output configuration from an existing mapper.</summary>
        /// <param name="copyFromConfiguration">The configuration to copy from.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public DapperPlusEntityMapper<T> Output(DapperPlusEntityMapper<T> copyFromConfiguration)
        {
            IsOutputModified(true);
            _output.AddRange(copyFromConfiguration._output);
            return this;
        }

        /// <summary>Sets output accessor from the selectors.</summary>
        /// <param name="selectors">The output selectors.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public DapperPlusEntityMapper<T> Output(Expression<Func<T, object>> selectors)
        {
            IsOutputModified(true);
            _output.Add(new DapperPlusExpressionMapper<T>(selectors));
            return this;
        }

        /// <summary>Sets output accessor from the selectors.</summary>
        /// <param name="selector">The output selector.</param>
        /// <param name="destinationName">The destination name.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public DapperPlusEntityMapper<T> Output(Expression<Func<T, object>> selector, string destinationName)
        {
            IsOutputModified(true);
            _output.Add(new DapperPlusExpressionMapper<T>(selector, destinationName));
            return this;
        }

        /// <summary>Gets key accessors.</summary>
        /// <returns>The key accessors.</returns>
        internal override List<PropertyOrFieldAccessor> GetKeyAccessors()
        {
            var key = _key.Count > 0 ? _key : ((DapperPlusEntityMapper<T>) _masterConfig)._key;
            return GetAccessors(key);
        }

        /// <summary>Gets identity accessors.</summary>
        /// <returns>The identity accessors.</returns>
        internal override List<PropertyOrFieldAccessor> GetIdentityAccessors()
        {
            var identity = _identity.Count > 0 ? _identity : ((DapperPlusEntityMapper<T>) _masterConfig)._identity;
            return GetAccessors(identity);
        }

        /// <summary>Gets map accessors.</summary>
        /// <returns>The map accessors.</returns>
        internal override List<PropertyOrFieldAccessor> GetMapAccessors()
        {
            var map = _map.Count > 0 ? _map : ((DapperPlusEntityMapper<T>) _masterConfig)._map;
            return GetAccessors(map);
        }

        /// <summary>Gets ignore accessors.</summary>
        /// <returns>The ignore accessors.</returns>
        internal override List<PropertyOrFieldAccessor> GetIgnoreAccessors()
        {
            var ignore = _ignore.Count > 0 ? _ignore : ((DapperPlusEntityMapper<T>) _masterConfig)._ignore;
            return GetAccessors(ignore);
        }

        /// <summary>Gets output accessors.</summary>
        /// <returns>The output accessors.</returns>
        internal override List<PropertyOrFieldAccessor> GetOutputAccessors()
        {
            var output = _output.Count > 0 ? _output : ((DapperPlusEntityMapper<T>) _masterConfig)._output;
            return GetAccessors(output);
        }

        /// <summary>Gets the accessors.</summary>
        /// <exception cref="Exception">Thrown when an exception error condition occurs.</exception>
        /// <param name="mapper">The mapper.</param>
        /// <returns>The accessors.</returns>
        internal List<PropertyOrFieldAccessor> GetAccessors(List<DapperPlusExpressionMapper<T>> mapper)
        {
            var accessors = new List<PropertyOrFieldAccessor>();
            mapper.ForEach(x =>
            {
                if (!string.IsNullOrEmpty(x.DestinationName))
                {
                    var list = x.SelectorFactory.GetPropertyOrFieldAccessors();

                    if (list.Length == 0 || list.Length > 1)
                    {
                        throw new Exception(ExceptionMessage.GeneralException);
                    }

                    list[0].Member = x.DestinationName;
                    accessors.Add(list[0]);
                }
                else
                {
                    accessors.AddRange(x.SelectorFactory.GetPropertyOrFieldAccessors());
                }
            });
            return accessors;
        }
    }
}