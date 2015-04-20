using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;
using VPN.Core.Entities;
using VPN.Core.IRepositories;

namespace VPN.Core.Repositories
{
    /// <summary>
    /// 仓储基类
    /// <remarks>创建：2015.4.9</remarks>
    /// </summary>
    public class RepositoryBase<TEntity,TKey> : IBaseRepository<TEntity,TKey> where TEntity : EntityBase<TKey> where TKey : new()
    {
        protected ISession CurrentSession; 
        public RepositoryBase(ISession session)
        {
            CurrentSession = session;
        }

        public TKey Insert(TEntity entity)
        { 
            using (ITransaction transaction = CurrentSession.BeginTransaction())
            {
                try
                {
                    var newId = (TKey)CurrentSession.Save(entity);
                    CurrentSession.Flush();
                    transaction.Commit();
                    return newId;
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    return new TKey();
                }
            } 
        }

        public int Insert(System.Collections.Generic.IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public bool Update(TEntity entity)
        {
            using (ITransaction transaction = CurrentSession.BeginTransaction())
            {
                try
                {
                    CurrentSession.Update(entity);
                    CurrentSession.Flush();
                    transaction.Commit();
                    return true;
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool Delete(TEntity entity)
        {
            using (ITransaction transaction = CurrentSession.BeginTransaction())
            {
                try
                {
                    CurrentSession.Delete(entity);
                    CurrentSession.Flush();
                    transaction.Commit();
                    return true;
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool Delete(TKey key)
        {
            throw new NotImplementedException();
        }

        bool IBaseRepository<TEntity, TKey>.Delete(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        bool IBaseRepository<TEntity, TKey>.Delete(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public bool Exist(Expression<Func<TEntity, bool>> anyLambda)
        {
            return false; //return NContext.Set<T>().Any(anyLambda);
        } 

        public TEntity Find(Expression<Func<TEntity, bool>> whereLambda)
        {
            using (ITransaction transaction = CurrentSession.BeginTransaction())
            {
                try
                {
                    object returnEntity = CurrentSession.Query<TEntity>().FirstOrDefault(whereLambda);
                    CurrentSession.Flush();
                    transaction.Commit();
                    return (TEntity)returnEntity;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public IQueryable<TEntity> FindList(Expression<Func<TEntity, bool>> whereLamdba, string orderName, bool isAsc)
        {
            var list = CurrentSession.Query<TEntity>().Where(whereLamdba);
            list = OrderBy(list, orderName, isAsc);
            return list;
        }

        public IQueryable<TEntity> FindPageList(int pageIndex, int pageSize, out int totalRecord, Expression<Func<TEntity, bool>> whereLamdba, string orderName, bool isAsc)
        {
            var _list = CurrentSession.Query<TEntity>().Where<TEntity>(whereLamdba);
            totalRecord = _list.Count();
            _list = OrderBy(_list, orderName, isAsc).Skip<TEntity>((pageIndex - 1) * pageSize).Take<TEntity>(pageSize);
            return _list;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="source">原IQueryable</param>
        /// <param name="propertyName">排序属性名</param>
        /// <param name="isAsc">是否正序</param>
        /// <returns>排序后的IQueryable<T></returns>
        private IQueryable<TEntity> OrderBy(IQueryable<TEntity> source, string propertyName, bool isAsc)
        {
            if (source == null) throw new ArgumentNullException("source", "不能为空");
            if (string.IsNullOrEmpty(propertyName)) return source;
            var _parameter = Expression.Parameter(source.ElementType);
            var _property = Expression.Property(_parameter, propertyName);
            if (_property == null) throw new ArgumentNullException("propertyName", "属性不存在");
            var _lambda = Expression.Lambda(_property, _parameter);
            var _methodName = isAsc ? "OrderBy" : "OrderByDescending";
            var _resultExpression = Expression.Call(typeof(Queryable), _methodName, new Type[] { source.ElementType, _property.Type }, source.Expression, Expression.Quote(_lambda));
            return source.Provider.CreateQuery<TEntity>(_resultExpression);
        }
          
        public int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Delete(System.Collections.Generic.IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        } 
    }
}
