namespace Z.Dapper.Plus
{
    public partial class DapperPlusEntityMapper
    {
        /// <summary>The configuration delete.</summary>
        internal DapperPlusEntityMapper _configDelete;

        /// <summary>The configuration insert.</summary>
        internal DapperPlusEntityMapper _configInsert;

        /// <summary>The configuration merge.</summary>
        internal DapperPlusEntityMapper _configMerge;

        /// <summary>The configuration update.</summary>
        internal DapperPlusEntityMapper _configUpdate;

        /// <summary>true if this object is master configuration.</summary>
        internal bool _isMasterConfig;

        /// <summary>The master configuration.</summary>
        internal DapperPlusEntityMapper _masterConfig;
    }
}