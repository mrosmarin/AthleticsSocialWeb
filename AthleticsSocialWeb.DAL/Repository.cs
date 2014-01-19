using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using AthleticsSocialWeb.Common.Entities;
using AthleticsSocialWeb.Common.Repository;
using AthleticsSocialWeb.Common.Specification;

namespace AthleticsSocialWeb.DAL
{
    public class Repository<T> : IRepository<T>
        where T : IEntity
    {
        #region Members

        public DbContext Context { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Create a new instance of repository
        /// </summary>
        public Repository(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            Context = context;
        }

        #endregion

        //#region IRepository Members

        /////// <summary>
        /////// 
        /////// </summary>
        ////public IUnitOfWork UnitOfWork
        ////{
        ////    get
        ////    {
        ////        return _UnitOfWork;
        ////    }
        ////}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="item"></param>
        //public virtual void Add(T item)
        //{

        //    if (item != (T)null)
        //        GetSet().Add(item); // add new item in this set
        //    else
        //    {
        //        //LoggerFactory.CreateLog()
        //        //          .LogInfo(Message.info_CannotAddNullEntity, typeof(T).ToString());

        //    }

        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="item"></param>
        //public virtual void Remove(T item)
        //{
        //    //if (item != (T)null)
        //    //{
        //    //    //attach item if not exist
        //    //    _UnitOfWork.Attach(item);

        //    //    //set as "removed"
        //    //    GetSet().Remove(item);
        //    //}
        //    //else
        //    //{
        //    //    LoggerFactory.CreateLog()
        //    //              .LogInfo(Message.info_CannotRemoveNullEntity, typeof(T).ToString());
        //    //}
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="item"></param>
        //public virtual void TrackItem(T item)
        //{
        //    //if (item != (T)null)
        //    //    _UnitOfWork.Attach<T>(item);
        //    //else
        //    //{
        //    //    LoggerFactory.CreateLog()
        //    //              .LogInfo(Message.info_CannotRemoveNullEntity, typeof(T).ToString());
        //    //}
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="item"></param>
        //public virtual void Modify(T item)
        //{
        //    //if (item != (T)null)
        //    //    _UnitOfWork.SetModified(item);
        //    //else
        //    //{
        //    //    LoggerFactory.CreateLog()
        //    //              .LogInfo(Message.info_CannotRemoveNullEntity, typeof(T).ToString());
        //    //}
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public virtual T Get(int id)
        //{
        //    if (id != 0)
        //        return GetSet().Find(id);
        //    else
        //        return null;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public virtual IEnumerable<T> GetAll()
        //{
        //    return GetSet();
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="specification"></param>
        ///// <returns></returns>
        //public virtual IEnumerable<T> AllMatching(ISpecification<T> specification)
        //{
        //    return GetSet().Where(t => specification.IsSatisfiedBy(t));
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="KProperty"></typeparam>
        ///// <param name="pageIndex"></param>
        ///// <param name="pageCount"></param>
        ///// <param name="orderByExpression"></param>
        ///// <param name="ascending"></param>
        ///// <returns></returns>
        //public virtual IEnumerable<T> GetPaged<KProperty>(int pageIndex, int pageCount, System.Linq.Expressions.Expression<Func<T, KProperty>> orderByExpression, bool ascending)
        //{
        //    var set = GetSet();

        //    if (ascending)
        //    {
        //        return set.OrderBy(orderByExpression)
        //                  .Skip(pageCount * pageIndex)
        //                  .Take(pageCount);
        //    }
        //    else
        //    {
        //        return set.OrderByDescending(orderByExpression)
        //                  .Skip(pageCount * pageIndex)
        //                  .Take(pageCount);
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="filter"></param>
        ///// <returns></returns>
        //public virtual IEnumerable<T> GetFiltered(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        //{
        //    return GetSet().Where(filter);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="persisted"></param>
        ///// <param name="current"></param>
        //public virtual void Merge(T persisted, T current)
        //{
        //    _UnitOfWork.ApplyCurrentValues(persisted, current);
        //}

        //#endregion

        //#region IDisposable Members

        ///// <summary>
        ///// <see cref="M:System.IDisposable.Dispose"/>
        ///// </summary>
        //public void Dispose()
        //{
        //    if (_UnitOfWork != null)
        //        _UnitOfWork.Dispose();
        //}

        //#endregion

        //#region Private Methods

        //IDbSet<T> GetSet()
        //{
        //    return _UnitOfWork.CreateSet<T>();
        //}
        //#endregion

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetFiltered(ISpecification<T> specification)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetFiltered<TProperty>(ISpecification<T> specification, int? pageIndex = null, int? pageCount = null,
            Expression<Func<T, TProperty>> orderByExpression = null, bool? @ascending = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetFiltered<TProperty>(Expression<Func<T, bool>> filter, int? pageIndex = null, int? pageCount = null,
            Expression<Func<T, TProperty>> orderByExpression = null, bool? @ascending = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetFiltered(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}


