using BaseProject.Domain.Entities.Auth;
using BaseProject.Domain.Interfaces.Repositories;
using BaseProject.Infrastructure.Persistence;

namespace BaseProject.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BaseDbContext context) : base(context)
        {
        }
    }
}