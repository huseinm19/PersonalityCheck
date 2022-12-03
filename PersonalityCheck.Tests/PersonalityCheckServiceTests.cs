using AutoFixture.AutoMoq;
using AutoFixture;
using Moq;
using PersonalityCheck.BLL.DataTransferObjects;
using PersonalityCheck.BLL.Service;
using PersonalityCheck.Tests.Helpers;
using System.Net;
using PersonalityCheck.Tests.Models;
using PersonalityCheck.BLL.Enums;
using PersonalityCheck.BLL.Models;
using PersonalityCheck.BLL.Interface;
using Microsoft.Extensions.Logging;

namespace PersonalityCheck.Tests
{
    public class PersonalityCheckServiceTests
    {
        private readonly IFixture _fixture;
        private Mock<IHttpClientFactory> _httpClientFactory = new Mock<IHttpClientFactory>();
        public readonly HttpHelperTest _httpHelperTest = new HttpHelperTest();
        private Mock<IPersonalityCheckDALService> _personalityCheckDALService = new Mock<IPersonalityCheckDALService>();
        private readonly User _user;
        private readonly List<Question> _questions;
        private readonly List<Answer> _answers;
        public Mock<ILogger<PersonalityCheckService>> _logger = new Mock<ILogger<PersonalityCheckService>>();

        public PersonalityCheckServiceTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _user = _fixture.Create<User>();
            _questions = _fixture.Create<List<Question>>();
            _answers = _fixture.Create<List<Answer>>();
        }

        [Fact]
        public async Task GetAllQuestionsAndAnswers_WhenIsSuccessStatusCode()
        {
            //Setup the mocked dependency
            _personalityCheckDALService.Setup(_ => _.GetAllQuestions()).Returns(Task.FromResult(_questions));
            _personalityCheckDALService.Setup(_ => _.GetAllAnswers()).Returns(Task.FromResult(_answers));
            _personalityCheckDALService.Setup(_ => _.AddNewUser(_user)).Returns(Task.FromResult(true));

            //Inject the dependency into the subject under test
            var providerService = new PersonalityCheckService(_personalityCheckDALService.Object, _logger.Object);

            //Act
            var result = await providerService.GetAllQuestionsAndAnswers();

            // Assert
            Assert.NotNull(result);
            Assert.False(result.HasError);
        }

        [Fact]
        public async Task SaveResult_WhenIsNoQuestionsInDatabase()
        {
            List<Question> questions = null;

            //Setup the mocked dependency
            _personalityCheckDALService.Setup(_ => _.GetAllQuestions()).Returns(Task.FromResult(questions));
            _personalityCheckDALService.Setup(_ => _.GetAllAnswers()).Returns(Task.FromResult(_answers));
            _personalityCheckDALService.Setup(_ => _.AddNewUser(_user)).Returns(Task.FromResult(true));

            //Inject the dependency into the subject under test
            var providerService = new PersonalityCheckService(_personalityCheckDALService.Object, _logger.Object);

            //Act
            var result = await providerService.GetAllQuestionsAndAnswers();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.HasError);
            Assert.Equal("There is no questions in database", result.ErrorMessage);
        }

        [Fact]
        public async Task SaveResult_WhenIsNoAnswersInDatabase()
        {
            List<Answer> answers = null;

            //Setup the mocked dependency
            _personalityCheckDALService.Setup(_ => _.GetAllQuestions()).Returns(Task.FromResult(_questions));
            _personalityCheckDALService.Setup(_ => _.GetAllAnswers()).Returns(Task.FromResult(answers));
            _personalityCheckDALService.Setup(_ => _.AddNewUser(_user)).Returns(Task.FromResult(true));

            //Inject the dependency into the subject under test
            var providerService = new PersonalityCheckService(_personalityCheckDALService.Object, _logger.Object);

            //Act
            var result = await providerService.GetAllQuestionsAndAnswers();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.HasError);
            Assert.Equal("There is no answers in database", result.ErrorMessage);
        }

        [Fact]
        public async Task SaveResult_WhenIsSuccessStatusCode()
        {
            //Setup the mocked dependency
            _personalityCheckDALService.Setup(_ => _.GetAllQuestions()).Returns(Task.FromResult(_questions));
            _personalityCheckDALService.Setup(_ => _.GetAllAnswers()).Returns(Task.FromResult(_answers));
            _personalityCheckDALService.Setup(_ => _.AddNewUser(_user)).Returns(Task.FromResult(true));

            //Inject the dependency into the subject under test
            var providerService = new PersonalityCheckService(_personalityCheckDALService.Object, _logger.Object);

            //Act
            var result = await providerService.SaveResult(_user);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.HasError);
        }

        [Fact]
        public async Task SaveResult_WhenIsUserNull()
        {
            User user = null;

            //Setup the mocked dependency
            _personalityCheckDALService.Setup(_ => _.GetAllQuestions()).Returns(Task.FromResult(_questions));
            _personalityCheckDALService.Setup(_ => _.GetAllAnswers()).Returns(Task.FromResult(_answers));
            _personalityCheckDALService.Setup(_ => _.AddNewUser(user)).Returns(Task.FromResult(false));

            //Inject the dependency into the subject under test
            var providerService = new PersonalityCheckService(_personalityCheckDALService.Object, _logger.Object);

            //Act
            var result = await providerService.SaveResult(user);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.HasError);
            Assert.Equal("User can't be saved in database.", result.ErrorMessage);
        }

    }
}
