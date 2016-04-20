namespace Z.Dapper.Plus
{
    /// <summary>A dapper plus entity mapper.</summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    public partial class DapperPlusEntityMapper<T> : DapperPlusEntityMapper
    {
        /// <summary>Default constructor.</summary>
        public DapperPlusEntityMapper()
        {
            _isMasterConfig = true;
            _configDelete = new DapperPlusEntityMapper<T>(this);
            _configInsert = new DapperPlusEntityMapper<T>(this);
            _configMerge = new DapperPlusEntityMapper<T>(this);
            _configUpdate = new DapperPlusEntityMapper<T>(this);
        }

        /// <summary>Constructor.</summary>
        /// <param name="master">The master.</param>
        public DapperPlusEntityMapper(DapperPlusEntityMapper<T> master)
        {
            _masterConfig = master;
        }
    }
}