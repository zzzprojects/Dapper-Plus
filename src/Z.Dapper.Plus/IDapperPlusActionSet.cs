using System;

namespace Z.Dapper.Plus
{
    /// <summary>Interface for DapperPlusActionSet.</summary>
    /// <remarks>
    ///     This interface is used in extension method to allow chaining. The out parameter modifier
    ///     allow to support multiple type like IDapperPlusActionSet&lt;IEnumerable&lt;T&gt;&gt;. The
    ///     interface may look worthless but is very useful for keeping the IntelliSense with the lambda
    ///     expression.
    /// </remarks>
    /// <typeparam name="TEntity">Type of the entity.</typeparam>
    public interface IDapperPlusActionSet<out TEntity>
    {
        /// <summary>Adds an action to the action set.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="mapperKey">The mapper key.</param>
        /// <param name="actionKind">The action kind.</param>
        /// <param name="selectors">The selection of entities to perform an action on.</param>
        void AddAction<T>(string mapperKey, DapperPlusActionKind actionKind, params Func<T, object>[] selectors);

        /// <summary>Creates a new dapper action and perform an action on the selection of entities.</summary>
        /// <typeparam name="T1">Generic type parameter.</typeparam>
        /// <typeparam name="T2">Generic type parameter.</typeparam>
        /// <param name="mapperKey">The key.</param>
        /// <param name="actionKind">The action kind.</param>
        /// <param name="selectors">The selection of entities to perform an action on.</param>
        /// <returns>The new dapper action.</returns>
        DapperPlusActionSet<T2> CreateDapperAction<T1, T2>(string mapperKey, DapperPlusActionKind actionKind, params Func<T1, T2>[] selectors);
    }
}