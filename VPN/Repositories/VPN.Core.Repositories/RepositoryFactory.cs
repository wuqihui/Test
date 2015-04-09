using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPN.Core.Repositories
{
    /// <summary>
    /// 简单工厂？
    /// </summary>
    class RepositoryFactory
    {
        /// <summary>
        /// 用户仓储
        /// </summary>
        public static IUserRepository UserRepository { get { return new UserRepository(); } }
    }
}
