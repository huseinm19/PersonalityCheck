using Evv.SelfRegistrationDAL.API.Interfaces;
using PersonalityCheckDAL.API.DatabaseContexts;
using PersonalityCheckDAL.API.Entities;

namespace PersonalityCheckDAL.API.Repositories
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(PersonalityCheckContext context)
            : base(context)
        {
        }
    }
}
