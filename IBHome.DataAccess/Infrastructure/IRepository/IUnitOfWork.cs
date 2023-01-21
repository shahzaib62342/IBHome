
namespace IBHome.DataAccess.Infrastructure.IRepository
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        IUserTypeRepository UserType { get; }

        void Save();
    }
}
