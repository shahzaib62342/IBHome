using IBHome.DataAccess.Data;
using IBHome.DataAccess.Infrastructure.IRepository;
using IBHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBHome.DataAccess.Infrastructure.Repository
{
    public class UserTypeRepository : Repository<UserType>, IUserTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public UserTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context= context;
        }

        public void Update(UserType userType)
        {
            _context.UserTypes.Update(userType);
        }
    }
}
