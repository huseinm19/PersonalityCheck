using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalityCheck.BLL.Interface;
using PersonalityCheck.BLL.Models;

namespace PersonalityCheck.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalityCheckController : ControllerBase
    {
        private readonly ILogger<PersonalityCheckController> _logger;
        private readonly IPersonalityCheckDALService _personalityCheckDALService;
        private readonly IPersonalityCheckService _personalityCheckService;
        public PersonalityCheckController(ILogger<PersonalityCheckController> logger, IPersonalityCheckService personalityCheckService, IPersonalityCheckDALService personalityCheckDALService)
        {
            _logger = logger;
            _personalityCheckService = personalityCheckService;
            _personalityCheckDALService = personalityCheckDALService;
        }

        [HttpGet("GetQuestionsAndAnswers")]
        public async Task<IActionResult> GetQuestionsAndAnswers(string email)
        {
            try
            {
                var response = await _personalityCheckService.GetAllQuestionsAndAnswers(email);

                return (ActionResult)new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Unable to get states from DB");
            }
        }

        [HttpPost("SaveResult")]
        public async Task<IActionResult> SaveResult(User user)
        {
            try
            {
                var response = await _personalityCheckService.SaveResult(user);

                return (ActionResult)new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Unable to get states from DB");
            }
        }
    }
}
