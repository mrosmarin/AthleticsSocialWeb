using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AthleticsSocialWeb.Common.Entities;
using AthleticsSocialWeb.Common.Specification;

namespace AthleticsSocialWeb.Common.Repository
{
    /// <summary>
    /// Base interface to implement Repository Pattern
    /// </summary>
    /// <remarks>
    /// <typeparam name="T">Type of entity for this repository </typeparam>
    /// </remarks>
    public interface IRepository<T> : IDisposable
        where T : IEntity
    {

        /// <summary>
        /// Get element by entity key
        /// </summary>
        /// <param name="id">Entity key value</param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        /// Get all elements of type T in repository
        /// </summary>
        /// <returns>List of selected elements</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Get all elements of type T that matching a
        /// Specification <paramref name="specification"/>
        /// </summary>
        /// <param name="specification">Specification that result meet</param>
        IEnumerable<T> GetFiltered(ISpecification<T> specification);

        /// <summary>
        /// Get all elements of type T that matching a
        /// Specification <paramref name="specification"/>
        /// </summary>
        /// <param name="specification">Specification that result meet</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageCount"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        IEnumerable<T> GetFiltered<TProperty>(ISpecification<T> specification, int? pageIndex = null,
            int? pageCount = null, Expression<Func<T, TProperty>> orderByExpression = null, bool? ascending = null);

        /// <summary>
        /// Get  elements of type T in repository
        /// </summary>
        /// <param name="filter">Filter that each element do match</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageCount"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="ascending"></param>
        /// <returns>List of selected elements</returns>
        IEnumerable<T> GetFiltered<TProperty>(Expression<Func<T, bool>> filter, int? pageIndex = null,
            int? pageCount = null, Expression<Func<T, TProperty>> orderByExpression = null, bool? ascending = null);

        /// <summary>
        /// Get  elements of type T in repository
        /// </summary>
        /// <param name="filter">Filter that each element do match</param>
        /// <returns>List of selected elements</returns>
        IEnumerable<T> GetFiltered(Expression<Func<T, bool>> filter);
    }
}
