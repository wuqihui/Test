using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace VPN.Core.Repositories
{
    /// <summary>
    /// 上下文简单工厂
    /// <remarks>
    /// 创建：2014.02.05
    /// </remarks>
    /// </summary>
    public class ContextFactory
    { 
        /// <summary>
        /// 获取当前数据上下文
        /// </summary>
        /// <returns></returns>
        public static VpnDbContext GetCurrentContext()
        {
            VpnDbContext nContext = CallContext.GetData("VpnDbContext") as VpnDbContext;
            if (nContext == null)
            {
                nContext = new VpnDbContext();
                CallContext.SetData("NineskyContext", nContext);
            }
            return nContext;
        }
    }
}
