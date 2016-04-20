using System.Data;

namespace Z.Dapper.Plus
{
    public partial class DapperPlusAction
    {
        /// <summary>Constructor.</summary>
        /// <param name="action">The action.</param>
        /// <param name="key">The key.</param>
        /// <param name="kind">The kind.</param>
        /// <param name="dataSource">The data source.</param>
        public DapperPlusAction(BaseDapperPlusActionSet action, string key, DapperPlusActionKind kind, object dataSource)
        {
            Key = key;
            Connection = action.Connection;
            DataSource = dataSource;
            Kind = kind;

            Execute();
        }

        /// <summary>Gets or sets the key.</summary>
        /// <value>The key.</value>
        public string Key { get; set; }

        /// <summary>Gets or sets the kind.</summary>
        /// <value>The kind.</value>
        public DapperPlusActionKind Kind { get; set; }

        /// <summary>Gets or sets the connection.</summary>
        /// <value>The connection.</value>
        public IDbConnection Connection { get; set; }

        /// <summary>Gets or sets the configuration.</summary>
        /// <value>The configuration.</value>
        public DapperPlusEntityMapper Config { get; set; }

        /// <summary>Gets or sets the data source.</summary>
        /// <value>The data source.</value>
        public object DataSource { get; set; }

        /// <summary>Gets or sets a value indicating whether this object is executed.</summary>
        /// <value>true if this object is executed, false if not.</value>
        public bool IsExecuted { get; set; }
    }
}