namespace Z.Dapper.Plus
{
    public partial class DapperPlusEntityMapper
    {
        /// <summary>Gets the retry count.</summary>
        /// <returns>The retry count.</returns>
        public int? RetryCount()
        {
            return _retryCount ?? (!_isMasterConfig ? _masterConfig._retryCount : null);
        }

        /// <summary>Gets the retry interval.</summary>
        /// <returns>The retry interval.</returns>
        public int? RetryInterval()
        {
            return _retryInterval ?? (!_isMasterConfig ? _masterConfig._retryInterval : null);
        }

        /// <summary>Sets the retry count.</summary>
        /// <param name="retryCount">The retry count.</param>
        /// <returns>A DapperPlusActionSet.</returns>
        public DapperPlusEntityMapper RetryCount(int retryCount)
        {
            _retryCount = retryCount;
            return this;
        }

        /// <summary>Sets the retry interval.</summary>
        /// <param name="retryInterval">The retry interval.</param>
        /// <returns>A DapperPlusActionSet.</returns>
        public DapperPlusEntityMapper RetryInterval(int retryInterval)
        {
            _retryInterval = retryInterval;
            return this;
        }
    }
}