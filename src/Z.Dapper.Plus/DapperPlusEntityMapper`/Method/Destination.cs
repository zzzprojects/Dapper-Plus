namespace Z.Dapper.Plus
{
    public partial class DapperPlusEntityMapper<T>
    {
        /// <summary>Sets the destination table name.</summary>
        /// <param name="name">The destination table name.</param>
        /// <returns>A DapperPlusEntityMapper&lt;T&gt;</returns>
        public new DapperPlusEntityMapper<T> Table(string name)
        {
            _table = name;
            return this;
        }
    }
}