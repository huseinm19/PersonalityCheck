using Evv.SelfRegistrationDAL.API.Interfaces;
using PersonalityCheckDAL.API.DatabaseContexts;
using PersonalityCheckDAL.API.Entities;

namespace PersonalityCheckDAL.API.Repositories
{
    public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(PersonalityCheckContext context)
            : base(context)
        {
        }
    }
}
