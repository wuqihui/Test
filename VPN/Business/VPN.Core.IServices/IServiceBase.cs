using System;
using System.Linq;
using System.Linq.Expressions;
using VPN.Core.Entities;

namespace VPN.Core.IServices
{
    /// <summary>
    /// 接口基类
    /// <remarks>创建：2014.02.03</remarks>
    /// </summary>
    public interface IServiceBase<TEntity,TKey> where TEntity : EntityBase<TKey>
    {
        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>操作影响的行数</returns>
        TKey Insert(TEntity entity);

        /// <summary>
        ///     更新
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        bool Update(TEntity entity);

        /// <summary>
        ///     删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        bool Delete(TEntity entity);

        /// <summary>
        ///     是否存在
        /// </summary>
        /// <param name="anyLambda">查询表达式</param>
        /// <returns>布尔值</returns>
        bool Exist(Expression<Func<TEntity, bool>> anyLambda);

        /// <summary>
        ///     查询数据
        /// </summary>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns>实体</returns>
        TEntity Find(Expression<Func<TEntity, bool>> whereLambda);

        /// <summary>
        ///     查找数据列表
        /// </summary>
        /// <typeparam name="S">排序</typeparam>
        /// <param name="whereLamdba">查询表达式</param>
        /// <param name="orderName">排序名称</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        IQueryable<TEntity> FindList(Expression<Func<TEntity, bool>> whereLamdba, string orderName, bool isAsc);

    }
}
