using Evv.SelfRegistrationDAL.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalityCheckDAL.API.Entities;

namespace PersonalityCheckDAL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalityCheckDALController : ControllerBase
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IUserRepository _userRepository;
        public PersonalityCheckDALController(IAnswerRepository answerRepository, IQuestionRepository questionRepository, IUserRepository userRepository)
        {
            _answerRepository = answerRepository;
            _questionRepository = questionRepository;
            _userRepository = userRepository;
        }

        [HttpGet("GetAllQuestions")]
        public async Task<IActionResult> GetAllQuestions()
        {
            try
            {
                var response = await _questionRepository.GetAllAsync();

                return (ActionResult)new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Unable to get questions from DB");
            }
        }

        [HttpGet("GetAllAnswers")]
        public async Task<IActionResult> GetAllAnswers()
        {
            try
            {
                var response = await _answerRepository.GetAllAsync();

                return (ActionResult)new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Unable to get answers from DB");
            }
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var response = await _userRepository.GetAllAsync();

                return (ActionResult)new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Unable to get users from DB");
            }
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            try
            {
                var response = await _userRepository.FindByConditionAsync(user => user.Email == email);

                return (ActionResult)new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Unable to get users from DB");
            }
        }

        [HttpPost("AddState")]
        public async Task<IActionResult> AddNewUser([FromBody] User user)
        {
            try
            {
                _userRepository.Add(user);

                bool response = await _userRepository.SaveChangesAsync();

                return (ActionResult)new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Unable to add new user to DB");
            }
        }
    }
}
