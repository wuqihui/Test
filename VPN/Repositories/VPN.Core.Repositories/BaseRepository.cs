using System; 
using System.Linq;
using System.Linq.Expressions; 
using VPN.Core.IRepositories;

namespace VPN.Core.Repositories
{  
    /// <summary>
    /// 仓储基类
    /// <remarks>创建：2015.4.9</remarks>
    /// </summary>
    public class BaseRepository<T>:IBaseRepository<T> where T : class 
    {
        protected readonly VpnDbContext NContext = ContextFactory.GetCurrentContext();

        public T Add(T entity)
        {
            NContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Added;
            NContext.SaveChanges();
            return entity;
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return NContext.Set<T>().Count(predicate);
        }

        public bool Update(T entity)
        {
            NContext.Set<T>().Attach(entity);
            NContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            return NContext.SaveChanges() > 0;
        }

        public bool Delete(T entity)
        {
            NContext.Set<T>().Attach(entity);
            NContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            return NContext.SaveChanges() > 0;
        }

        public bool Exist(Expression<Func<T, bool>> anyLambda)
        {
            return NContext.Set<T>().Any(anyLambda);
        }

        public T Find(Expression<Func<T, bool>> whereLambda)
        {
            T _entity = NContext.Set<T>().FirstOrDefault<T>(whereLambda);
            return _entity;
        }

        public IQueryable<T> FindList<S>(Expression<Func<T, bool>> whereLamdba, bool isAsc, Expression<Func<T, S>> orderLamdba)
        {
            var _list = NContext.Set<T>().Where<T>(whereLamdba);
            if (isAsc) _list = _list.OrderBy<T, S>(orderLamdba);
            else _list = _list.OrderByDescending<T, S>(orderLamdba);
            return _list;
        }

        public IQueryable<T> FindPageList<S>(int pageIndex, int pageSize, out int totalRecord, Expression<Func<T, bool>> whereLamdba, bool isAsc, Expression<Func<T, S>> orderLamdba)
        {
            var _list = NContext.Set<T>().Where<T>(whereLamdba);
            totalRecord = _list.Count();
            if (isAsc) _list = _list.OrderBy<T, S>(orderLamdba).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            else _list = _list.OrderByDescending<T, S>(orderLamdba).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            return _list;
        }
    }
}
}
