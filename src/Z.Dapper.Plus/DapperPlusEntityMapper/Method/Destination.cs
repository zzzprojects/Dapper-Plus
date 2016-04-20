namespace Z.Dapper.Plus
{
    public partial class DapperPlusEntityMapper
    {
        /// <summary>Gets the destination table name.</summary>
        /// <returns>The destination table name.</returns>
        public string Table()
        {
            return _table ?? (!_isMasterConfig ? _masterConfig._table : null);
        }

        /// <summary>Sets the destination table name.</summary>
        /// <param name="name">The destination table name.</param>
        /// <returns>A DapperPlusActionSet.</returns>
        public DapperPlusEntityMapper Table(string name)
        {
            _table = name;
            return this;
        }
    }
}