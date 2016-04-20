using System;
using System.Linq.Expressions;

namespace Z.Dapper.Plus.DapperPlusExpressionMapper
{
    /// <summary>A dapper plus expression mapper.</summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    public class DapperPlusExpressionMapper<T>
    {
        /// <summary>Constructor.</summary>
        /// <param name="selectorFactory">The selector factory.</param>
        public DapperPlusExpressionMapper(Expression<Func<T, object>> selectorFactory)
        {
            SelectorFactory = selectorFactory;
        }

        /// <summary>Constructor.</summary>
        /// <param name="selectorFactory">The selector factory.</param>
        /// <param name="destinationName">The destination name.</param>
        public DapperPlusExpressionMapper(Expression<Func<T, object>> selectorFactory, string destinationName)
        {
            SelectorFactory = selectorFactory;
            DestinationName = destinationName;
        }

        /// <summary>Gets or sets the selector factory.</summary>
        /// <value>The selector factory.</value>
        public Expression<Func<T, object>> SelectorFactory { get; set; }

        /// <summary>Gets or sets the destination name.</summary>
        /// <value>The destination name.</value>
        public string DestinationName { get; set; }
    }
}