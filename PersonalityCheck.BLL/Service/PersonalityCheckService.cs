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

        public async Task<Response<List<QuestionAndAnswersDto>>> GetAllQuestionsAndAnswers()
        {
            try
            {
                List<Question> questions = await _httpClientService.GetAllQuestions();
                if (questions == null)
                    return Response<List<QuestionAndAnswersDto>>.Failed("There is no questions in database");
                List<Answer> answers = await _httpClientService.GetAllAnswers();
                if (answers == null)
                    return Response<List<QuestionAndAnswersDto>>.Failed("There is no answers in database");
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
                return Response<List<QuestionAndAnswersDto>>.Failed("Internal server error");
            }

        }
        public async Task<Response<bool>> SaveResult(User user)
        {
            try
            {              
                bool response = await _httpClientService.AddNewUser(user);
                if (!response)
                    return Response<bool>.Failed("User can't be saved in database.");

                return Response<bool>.Successful(response);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Something went wrong with adding result. Exception: {ex}");
                return Response<bool>.Failed("Internal server error");
            }

        }
    }
}
