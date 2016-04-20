namespace Z.Dapper.Plus
{
    /// <summary>A dapper plus column mapping.</summary>
    public class DapperPlusColumnMapping
    {
        /// <summary>Gets or sets the column source name.</summary>
        /// <value>The column source name.</value>
        public string SourceName { get; set; }

        /// <summary>Gets or sets the column destination name.</summary>
        /// <value>The column destination name.</value>
        public string DestinationName { get; set; }

        /// <summary>Gets or sets a value indicating whether this column is primary key.</summary>
        /// <value>true if this column is primary key, false if not.</value>
        public bool IsPrimaryKey { get; set; }

        /// <summary>Gets or sets a value indicating whether this column is identity.</summary>
        /// <value>true if this column is identity, false if not.</value>
        public bool IsIdentity { get; set; }

        /// <summary>Gets or sets a value indicating whether this column use the direction input.</summary>
        /// <value>true if the column use the direction input, false if not.</value>
        public bool Input { get; set; }

        /// <summary>Gets or sets a value indicating whether this column use the direction output.</summary>
        /// <value>true if the column use the direction output, false if not.</value>
        public bool Output { get; set; }
    }
}