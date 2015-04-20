using System;
using Castle.Windsor;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;
using VPN.Core.Mapping;

namespace VPN.Setting
{
    public class Ioc
    {
        private static Ioc _instance;
        private static readonly object SyncRoot = new Object();
        public IWindsorContainer Container;
        private readonly ISessionFactory _sessionFactory;
        private Ioc()
        {
            Container = new WindsorContainer();

            var config = MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("DefaultConnection"));

            _sessionFactory = Fluently.Configure()
                //配置数据库
                .Database(config)
                //指定需要映射的程序集
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<VpnInfoMap>())
                .CurrentSessionContext<WebSessionContext>()
                //创建session工厂
                .BuildSessionFactory();
        }



        public ISessionFactory SessionFactory
        {
            get { return _sessionFactory; }
        }

        public static T Resolve<T>()
        {
            return Instance.Container.Resolve<T>();
        }

        public static Ioc Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new Ioc();
                        }
                    }
                }
                return _instance;
            }
        }

        public void StartUp(Bootstrapper bootstrapper)
        {
            bootstrapper.RegisterComponents(Container, SessionFactory);
        }
    }
}
