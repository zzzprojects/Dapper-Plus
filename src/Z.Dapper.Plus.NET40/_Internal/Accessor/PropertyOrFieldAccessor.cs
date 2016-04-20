// Copyright (c) 2014 Jonathan Magnan (http://jonathanmagnan.com).
// All rights reserved (http://zzzproject.com/linq-expressions-extensions/).
// Licensed under MIT License (MIT) (https://zlinqexpressionsextensions.codeplex.com/license).

using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace Z.Dapper.Plus
{
    internal class PropertyOrFieldAccessor
    {
        /// <summary>Constructor.</summary>
        /// <param name="isCalculated">true if this object is calculated.</param>
        public PropertyOrFieldAccessor(bool isCalculated)
        {
            IsCalculated = isCalculated;
        }

        /// <summary>Constructor.</summary>
        /// <param name="propertyOrFieldPaths">The FieldPaths.</param>
        public PropertyOrFieldAccessor(ReadOnlyCollection<MemberInfo> propertyOrFieldPaths)
        {
            PropertyOrFieldPaths = propertyOrFieldPaths;
            PropertyOrField = propertyOrFieldPaths.LastOrDefault();
        }

        /// <summary>Constructor.</summary>
        /// <param name="property">The property.</param>
        public PropertyOrFieldAccessor(MemberInfo property)
        {
            if (property != null)
            {
                PropertyOrFieldPaths = new ReadOnlyCollection<MemberInfo>(new[] {property});
                PropertyOrField = property;
            }
        }

        /// <summary>Gets or sets the member.</summary>
        /// <value>The member.</value>
        public string Member { get; set; }

        /// <summary>Gets or sets a value indicating whether this object is calculated.</summary>
        /// <value>true if this object is calculated, false if not.</value>
        public bool IsCalculated { get; set; }

        /// <summary>Gets or sets the FieldPaths.</summary>
        /// <value>The FieldPaths.</value>
        public ReadOnlyCollection<MemberInfo> PropertyOrFieldPaths { get; internal set; }

        /// <summary>Gets or sets the property.</summary>
        /// <value>The property.</value>
        public MemberInfo PropertyOrField { get; set; }

        /// <summary>
        ///     Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return string.Join(".", PropertyOrFieldPaths.Select(x => x.Name).ToArray());
        }
    }
}