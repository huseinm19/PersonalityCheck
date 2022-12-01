using PersonalityCheck.BLL.Interface;
using PersonalityCheck.BLL.Models;
using PersonalityCheck.BLL.Service;

namespace PersonalityCheck.BLL.Service
{
    public class PersonalityCheckDALService : RequestService, IPersonalityCheckDALService
    {

        public PersonalityCheckDALService(IHttpClientFactory clientFactory) : base(clientFactory, Enums.NamedClient.PersonalityCheckDALClient)
        { }

        public async Task<List<Question>> GetAllQuestions()
        {
            try
            {
                return (await Get<List<Question>>("api/PersonalityCheckDAL/GetAllQuestions")).Data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Answer>> GetAllAnswers()
        {
            try
            {
                return (await Get<List<Answer>>("api/PersonalityCheckDAL/GetAllAnswers")).Data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
