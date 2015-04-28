using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace VPN.Core.IRepositories
{
    public interface IBaseRepository<TEntity, TKey>
    {

        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>操作影响的行数</returns>
        TKey Insert(TEntity entity);

        /// <summary>
        /// 更新实体对象
        /// </summary>
        /// <param name="entity">更新后的实体对象</param>
        /// <returns>是否更新成功</returns>
        bool Update(TEntity entity);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>操作影响的行数</returns>
        bool Delete(TEntity entity);

        /// <summary>
        /// 删除指定编号的实体
        /// </summary>
        /// <param name="key">实体编号</param>
        /// <returns>操作影响的行数</returns>
        bool Delete(TKey key);

        /// <summary>
        /// 删除所有符合特定条件的实体
        /// </summary>
        /// <param name="predicate">查询条件谓语表达式</param>
        /// <returns>操作影响的行数</returns>
        bool Delete(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 批量删除删除实体
        /// </summary>
        /// <param name="entities">实体对象集合</param>
        /// <returns>操作影响的行数</returns>
        bool Delete(IEnumerable<TEntity> entities);

        /// <summary>
        ///     查询记录数
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns>记录数</returns>
        int Count(Expression<Func<TEntity, bool>> predicate);

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
        IQueryable<TEntity> FindList(Expression<Func<TEntity, bool>> whereLamdba, string orderName = "CreateTime", bool isAsc = false);


        /// <summary>
        ///     查找分页数据列表
        /// </summary>
        /// <typeparam name="S">排序</typeparam>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="totalRecord">总记录数</param>
        /// <param name="whereLamdba">查询表达式</param>
        /// <param name="orderName">排序名称</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        IQueryable<TEntity> FindPageList(int pageIndex, int pageSize, out int totalRecord,
            Expression<Func<TEntity, bool>> whereLamdba, string orderName, bool isAsc);
    }
}