using Microsoft.Extensions.Logging;
using PersonalityCheck.BLL.DataTransferObjects;
using PersonalityCheck.BLL.Interface;
using PersonalityCheck.BLL.Models;
using System.Collections.Generic;
using System.Web;

namespace PersonalityCheck.BLL.Service
{
    public class PersonalityCheckService : IPersonalityCheckService
    {
        private readonly IPersonalityCheckDALService _httpClientService;
        private readonly ILogger<PersonalityCheckService> _logger;

        public PersonalityCheckService(IPersonalityCheckDALService httpClientService, ILogger<PersonalityCheckService> logger)
        {
            _httpClientService = httpClientService;
            _logger = logger;
        }

        public async Task<Response<List<QuestionAndAnswersDto>>> GetAllQuestionsAndAnswers(string email)
        {
            try
            {
                List<Question> questions = await _httpClientService.GetAllQuestions();
                List<Answer> answers = await _httpClientService.GetAllAnswers();
                List<QuestionAndAnswersDto> questionAndAnswersDto = new List<QuestionAndAnswersDto>();                
                foreach (var question in questions)
                {
                    List<Answer> currentAnswers = answers.Where(x => x.QuestionId == question.Id).ToList();
                    questionAndAnswersDto.Add(new QuestionAndAnswersDto(question, currentAnswers));
                }

                return Response<List<QuestionAndAnswersDto>>.Successful(questionAndAnswersDto);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Something went wrong with getting questions and answers. Exception: {ex}");
                return Response<List<QuestionAndAnswersDto>>.Failed("Internal server error"); ;
            }

        }
    }
}
