// Copyright (c) 2014 Jonathan Magnan (http://jonathanmagnan.com).
// All rights reserved (http://zzzproject.com/linq-expressions-extensions/).
// Licensed under MIT License (MIT) (https://zlinqexpressionsextensions.codeplex.com/license).

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Z.Dapper.Plus
{
    internal static partial class ExpressionExtensions
    {
        /// <summary>
        ///     An Expression extension method that gets a property or field access from an expression.
        /// </summary>
        /// <exception cref="Exception">Thrown when an exception error condition occurs.</exception>
        /// <param name="expression">The expression to act on.</param>
        /// <param name="parameterExpression">The parameter expression.</param>
        /// <returns>The property or field access from the expression.</returns>
        internal static PropertyOrFieldAccessor GetPropertyOrFieldAccess(this Expression expression, ParameterExpression parameterExpression, MemberInfo member = null)
        {
            var memberName = member != null ? member.Name : "";

            var paths = new List<MemberInfo>();

            MemberExpression memberExpression;

            do
            {
                memberExpression = RemoveConvert(expression) as MemberExpression;

                if (memberExpression == null)
                {
                    return new PropertyOrFieldAccessor(true) {Member = memberName};
                }

                var propertyInfo = memberExpression.Member as PropertyInfo;
                var fieldInfo = memberExpression.Member as FieldInfo;

                if (propertyInfo != null)
                {
                    paths.Add(propertyInfo);
                }
                if (fieldInfo != null)
                {
                    paths.Add(fieldInfo);
                }

                expression = memberExpression.Expression;
            } while (memberExpression.Expression != parameterExpression);

            paths.Reverse();


            var accessor = new PropertyOrFieldAccessor(paths.AsReadOnly());

            if (memberName == "")
            {
                memberName = accessor.ToString();
            }

            accessor.Member = memberName;

            return accessor;
        }
    }
}