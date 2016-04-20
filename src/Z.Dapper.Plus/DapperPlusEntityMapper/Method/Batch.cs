namespace Z.Dapper.Plus
{
    public partial class DapperPlusEntityMapper
    {
        /// <summary>Gets the batch delay interval.</summary>
        /// <returns>The batch delay interval</returns>
        public int? BatchDelayInterval()
        {
            return _batchDelayInterval ?? (!_isMasterConfig ? _masterConfig._batchDelayInterval : null);
        }

        /// <summary>Gets the batch size.</summary>
        /// <summary>The batch size.</summary>
        public int? BatchSize()
        {
            return _batchSize ?? (!_isMasterConfig ? _masterConfig._batchSize : null);
        }

        /// <summary>Gets the batch timeout.</summary>
        /// <summary>The batch timeout.</summary>
        public int? BatchTimeout()
        {
            return _batchTimeout ?? (!_isMasterConfig ? _masterConfig._batchTimeout : null);
        }

        /// <summary>Sets the batch delay interval.</summary>
        /// <param name="batchDelayInterval">The batch delay interval.</param>
        /// <returns>A DapperPlusActionSet.</returns>
        public DapperPlusEntityMapper BatchDelayInterval(int batchDelayInterval)
        {
            _batchDelayInterval = batchDelayInterval;
            return this;
        }

        /// <summary>Sets the batch size.</summary>
        /// <param name="batchSize">The batch size.</param>
        /// <returns>A DapperPlusActionSet.</returns>
        public DapperPlusEntityMapper BatchSize(int batchSize)
        {
            _batchSize = batchSize;
            return this;
        }

        /// <summary>Sets the batch timeout.</summary>
        /// <param name="batchTimeout">The batch timeout.</param>
        /// <returns>A DapperPlusActionSet.</returns>
        public DapperPlusEntityMapper BatchTimeout(int batchTimeout)
        {
            _batchTimeout = batchTimeout;
            return this;
        }
    }
}