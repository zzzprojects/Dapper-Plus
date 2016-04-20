namespace Z.Dapper.Plus
{
    public partial class DapperPlusEntityMapper<T>
    {
        /// <summary>Sets the batch delay interval.</summary>
        /// <param name="batchDelayInterval">The batch delay interval.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public new DapperPlusEntityMapper<T> BatchDelayInterval(int batchDelayInterval)
        {
            _batchDelayInterval = batchDelayInterval;
            return this;
        }

        /// <summary>Sets the batch size.</summary>
        /// <param name="batchSize">The batch size.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public new DapperPlusEntityMapper<T> BatchSize(int batchSize)
        {
            _batchSize = batchSize;
            return this;
        }

        /// <summary>Sets the batch timeout.</summary>
        /// <param name="batchTimeout">The batch timeout.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public new DapperPlusEntityMapper<T> BatchTimeout(int batchTimeout)
        {
            _batchTimeout = batchTimeout;
            return this;
        }
    }
}