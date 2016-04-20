namespace Z.Dapper.Plus
{
    public partial class DapperPlusEntityMapper<T>
    {
        /// <summary>Sets the retry count.</summary>
        /// <param name="retryCount">The retry count.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public new DapperPlusEntityMapper<T> RetryCount(int retryCount)
        {
            _retryCount = retryCount;
            return this;
        }

        /// <summary>Sets the retry interval.</summary>
        /// <param name="retryInterval">The retry interval.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public new DapperPlusEntityMapper<T> RetryInterval(int retryInterval)
        {
            _retryInterval = retryInterval;
            return this;
        }
    }
}