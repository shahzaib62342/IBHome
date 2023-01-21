using IBHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBHome.DataAccess.Infrastructure.IRepository
{
    public interface IUserTypeRepository:IRepository<UserType> 
    {
        void Update(UserType userType);
    }
}
