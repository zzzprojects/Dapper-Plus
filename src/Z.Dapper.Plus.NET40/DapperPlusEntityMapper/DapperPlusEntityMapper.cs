namespace Z.Dapper.Plus
{
    /// <summary>A dapper plus entity mapper.</summary>
    public abstract partial class DapperPlusEntityMapper
    {
        /// <summary>Default constructor.</summary>
        protected DapperPlusEntityMapper()
        {
            if (DapperPlusManager.MapperFactory != null)
            {
                DapperPlusManager.MapperFactory(this);
            }
        }
    }
}