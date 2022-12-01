using Evv.SelfRegistrationDAL.API.Interfaces;
using PersonalityCheckDAL.API.DatabaseContexts;
using PersonalityCheckDAL.API.Entities;

namespace PersonalityCheckDAL.API.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(PersonalityCheckContext context)
            : base(context)
        {
        }
    }
}
