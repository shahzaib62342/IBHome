using IBHome.DataAccess.Data;
using IBHome.DataAccess.Infrastructure.IRepository;
using IBHome.Models;


namespace IBHome.DataAccess.Infrastructure.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context= context;
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }
    }
}
