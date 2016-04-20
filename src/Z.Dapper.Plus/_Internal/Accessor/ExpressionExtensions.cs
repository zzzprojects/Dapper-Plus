// Copyright (c) 2014 Jonathan Magnan (http://jonathanmagnan.com).
// All rights reserved (http://zzzproject.com/linq-expressions-extensions/).
// Licensed under MIT License (MIT) (https://zlinqexpressionsextensions.codeplex.com/license).

using System.Linq.Expressions;

namespace Z.Dapper.Plus
{
    internal static partial class ExpressionExtensions
    {
        /// <summary>
        ///     An Expression extension method that removes convert expression from the expression.
        /// </summary>
        /// <param name="expression">The expression to act on.</param>
        /// <returns>An Expression without convert expression.</returns>
        internal static Expression RemoveConvert(this Expression expression)
        {
            while (expression.NodeType == ExpressionType.Convert || expression.NodeType == ExpressionType.ConvertChecked)
            {
                expression = ((UnaryExpression) expression).Operand;
            }

            return expression;
        }
    }
}