using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPN.Core.Entities;
using VPN.Core.IRepositories;
using VPN.Core.IServices;

namespace VPN.Core.Services
{
    /// <summary>
    /// 服务基类
    /// <remarks>创建：2014.02.03</remarks>
    /// </summary>
    public abstract class ServiceBase<TEntity, TKey> : IServiceBase<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        protected IBaseRepository<TEntity, TKey> CurrentRepository { get; set; }
        protected ServiceBase(IBaseRepository<TEntity, TKey> currentRepository)
        {
            CurrentRepository = currentRepository;
        }
        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>操作影响的行数</returns>
        public TKey Insert(TEntity entity)
        {
            return CurrentRepository.Insert(entity);
        }

        public bool Update(TEntity entity)
        {
            return CurrentRepository.Update(entity);
        }

        public bool Delete(TEntity entity)
        {
            return CurrentRepository.Delete(entity);
        }

        public bool Exist(System.Linq.Expressions.Expression<Func<TEntity, bool>> anyLambda)
        {
            throw new NotImplementedException();
        }

        public TEntity Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> whereLambda)
        {
            return CurrentRepository.Find(whereLambda);
        }

        public IQueryable<TEntity> FindList(System.Linq.Expressions.Expression<Func<TEntity, bool>> whereLamdba, string orderName, bool isAsc)
        {
            return CurrentRepository.FindList(whereLamdba, orderName, isAsc);
        }

    }
}
