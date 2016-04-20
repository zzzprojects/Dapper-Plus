using System;

namespace Z.Dapper.Plus
{
    public partial class DapperPlusEntityMapper<T>
    {
        /// <summary>Set the delete configuration with a lambda expression.</summary>
        /// <param name="actionConfigurationFactory">The action delete configuration factory.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public DapperPlusEntityMapper<T> Delete(Action<DapperPlusEntityMapper<T>> actionConfigurationFactory)
        {
            if (actionConfigurationFactory != null)
            {
                actionConfigurationFactory((DapperPlusEntityMapper<T>) _configDelete);
            }
            return this;
        }

        /// <summary>Set the insert configuration with a lambda expression.</summary>
        /// <param name="actionConfigurationFactory">The action insert configuration factory.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public DapperPlusEntityMapper<T> Insert(Action<DapperPlusEntityMapper<T>> actionConfigurationFactory)
        {
            if (actionConfigurationFactory != null)
            {
                actionConfigurationFactory((DapperPlusEntityMapper<T>) _configInsert);
            }
            return this;
        }

        /// <summary>Set the merge configuration with a lambda expression.</summary>
        /// <param name="actionConfigurationFactory">The action merge configuration factory.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public DapperPlusEntityMapper<T> Merge(Action<DapperPlusEntityMapper<T>> actionConfigurationFactory)
        {
            if (actionConfigurationFactory != null)
            {
                actionConfigurationFactory((DapperPlusEntityMapper<T>) _configMerge);
            }
            return this;
        }

        /// <summary>Set the update configuration with a lambda expression.</summary>
        /// <param name="actionConfigurationFactory">The action update configuration factory.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public DapperPlusEntityMapper<T> Update(Action<DapperPlusEntityMapper<T>> actionConfigurationFactory)
        {
            if (actionConfigurationFactory != null)
            {
                actionConfigurationFactory((DapperPlusEntityMapper<T>) _configUpdate);
            }
            return this;
        }
    }
}