using PersonalityCheck.BLL.DataTransferObjects;
using PersonalityCheck.BLL.Models;

namespace PersonalityCheck.BLL.Interface
{
    public interface IPersonalityCheckService
    {
        Task<Response<List<QuestionAndAnswersDto>>> GetAllQuestionsAndAnswers(string email);
        Task<Response<bool>> SaveResult(User user);
    }
}
