using System.Collections.Generic;
using Z.Dapper.Plus.DapperPlusExpressionMapper;

namespace Z.Dapper.Plus
{
    public partial class DapperPlusEntityMapper<T>
    {
        /// <summary>The identity.</summary>
        internal List<DapperPlusExpressionMapper<T>> _identity = new List<DapperPlusExpressionMapper<T>>();

        /// <summary>The ignore.</summary>
        internal List<DapperPlusExpressionMapper<T>> _ignore = new List<DapperPlusExpressionMapper<T>>();

        /// <summary>The key.</summary>
        internal List<DapperPlusExpressionMapper<T>> _key = new List<DapperPlusExpressionMapper<T>>();

        /// <summary>The map.</summary>
        internal List<DapperPlusExpressionMapper<T>> _map = new List<DapperPlusExpressionMapper<T>>();

        /// <summary>The output.</summary>
        internal List<DapperPlusExpressionMapper<T>> _output = new List<DapperPlusExpressionMapper<T>>();
    }
}