using IBHome.DataAccess.Data;
using IBHome.DataAccess.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBHome.DataAccess.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private  ApplicationDbContext _context;
        public IUserRepository User { get; private set; }

        public IUserTypeRepository UserType { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
           _context= context;
            User = new UserRepository(context);
            UserType = new UserTypeRepository(context);
        }

        public void Save()
        {
           _context.SaveChanges();
        }
    }
}
