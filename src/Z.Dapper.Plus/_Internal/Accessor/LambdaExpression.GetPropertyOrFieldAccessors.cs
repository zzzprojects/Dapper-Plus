// Copyright (c) 2014 Jonathan Magnan (http://jonathanmagnan.com).
// All rights reserved (http://zzzproject.com/linq-expressions-extensions/).
// Licensed under MIT License (MIT) (https://zlinqexpressionsextensions.codeplex.com/license).

using System.Linq;
using System.Linq.Expressions;

namespace Z.Dapper.Plus
{
    internal static class LambdaExpressionExtensions
    {
        /// <summary>
        ///     Gets the property or field accessors in this collection.
        /// </summary>
        /// <param name="expression">The expression to act on.</param>
        /// <returns>An array of property or field accessor.</returns>
        internal static PropertyOrFieldAccessor[] GetPropertyOrFieldAccessors(this LambdaExpression expression)
        {
            PropertyOrFieldAccessor[] memberAccessors;
            var parameterExpression = expression.Parameters.Single();
            var newExpression = expression.Body.RemoveConvert() as NewExpression;

            if (newExpression != null)
            {
                var arguments = newExpression.Arguments;
                var members = newExpression.Members;
                memberAccessors = arguments.Select((x, i) => x.GetPropertyOrFieldAccess(parameterExpression, members[i])).ToArray();
            }
            else
            {
                var memberAccesor = expression.Body.GetPropertyOrFieldAccess(parameterExpression);
                memberAccessors = new[] {memberAccesor};
            }

            return memberAccessors;
        }
    }
}