using System.Linq;
using NHibernate;
using NHibernate.Linq;
using VPN.Core.Entities;
using VPN.Core.IRepositories;

namespace VPN.Core.Repositories
{
    public class UserRepository : RepositoryBase<User,int>, IUserRepository
    {
        public UserRepository(ISession session):base(session)
        { 
        }

        public User FindUserByName(string userName)
        {
            return CurrentSession.Query<User>().FirstOrDefault(x => x.UserName.Equals(userName));
        }

        public int SaveOrders(Order order)
        {
          return  (int)CurrentSession.Save(order);
        }
    }
}
