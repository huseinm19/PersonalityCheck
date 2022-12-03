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

namespace PersonalityCheck.Tests
{
    public class PersonalityCheckDALServiceTests
    {
        private readonly IFixture _fixture;
        private Mock<IHttpClientFactory> _httpClientFactory = new Mock<IHttpClientFactory>();
        public readonly TestModel _testModel;
        private readonly User _user;
        private readonly List<Question> _questions;
        private readonly List<Answer> _answers;
        public readonly HttpHelperTest _httpHelperTest = new HttpHelperTest();

        public PersonalityCheckDALServiceTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _user = _fixture.Create<User>();
            _questions = _fixture.Create<List<Question>>();
            _answers = _fixture.Create<List<Answer>>();
        }

        [Fact]
        public async Task GetAllQuestions_WhenFound()
        {
            // Arrange
            var service = _fixture.Create<PersonalityCheckDALService>();

            // Setup a respond for the DAL api 
            var response = _httpHelperTest.CreateHttpResponse(_questions, HttpStatusCode.OK);

            HttpClient httpClient = _httpHelperTest.HttpClientFactoryTest(response);

            //Setup the mocked dependency
            _httpClientFactory.Setup(_ => _.CreateClient(It.Is<string>(x => x.Equals(NamedClient.PersonalityCheckDALClient.ToString())))).Returns(httpClient);

            //Inject the dependency into the subject under test
            var selfRegistrationDALService = new PersonalityCheckDALService(_httpClientFactory.Object);

            // Act
            var result = await selfRegistrationDALService.GetAllQuestions();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAllQuestions_WhenNotFound()
        {
            // Arrange
            List<Question> questions = null;
            var response = _httpHelperTest.CreateHttpResponse(questions, HttpStatusCode.NotFound);
            HttpClient _httpClient = _httpHelperTest.HttpClientFactoryTest(response);

            //Setup the mocked dependency
            _httpClientFactory.Setup(_ => _.CreateClient(It.Is<string>(x => x.Equals(NamedClient.PersonalityCheckDALClient.ToString())))).Returns(_httpClient);

            //Inject the dependency into the subject under test
            var selfRegistrationDALService = new PersonalityCheckDALService(_httpClientFactory.Object);

            // Act
            var result = await selfRegistrationDALService.GetAllQuestions();

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetAllAnswers_WhenFound()
        {
            // Arrange
            var service = _fixture.Create<PersonalityCheckDALService>();

            // Setup a respond for the DAL api 
            var response = _httpHelperTest.CreateHttpResponse(_answers, HttpStatusCode.OK);

            HttpClient httpClient = _httpHelperTest.HttpClientFactoryTest(response);

            //Setup the mocked dependency
            _httpClientFactory.Setup(_ => _.CreateClient(It.Is<string>(x => x.Equals(NamedClient.PersonalityCheckDALClient.ToString())))).Returns(httpClient);

            //Inject the dependency into the subject under test
            var selfRegistrationDALService = new PersonalityCheckDALService(_httpClientFactory.Object);

            // Act
            var result = await selfRegistrationDALService.GetAllQuestions();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAllAnswers_WhenNotFound()
        {
            // Arrange
            List<Answer> answers = null;
            var response = _httpHelperTest.CreateHttpResponse(answers, HttpStatusCode.NotFound);
            HttpClient _httpClient = _httpHelperTest.HttpClientFactoryTest(response);

            //Setup the mocked dependency
            _httpClientFactory.Setup(_ => _.CreateClient(It.Is<string>(x => x.Equals(NamedClient.PersonalityCheckDALClient.ToString())))).Returns(_httpClient);

            //Inject the dependency into the subject under test
            var selfRegistrationDALService = new PersonalityCheckDALService(_httpClientFactory.Object);

            // Act
            var result = await selfRegistrationDALService.GetAllQuestions();

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task AddNewUser_WhenAdded()
        {
            // Arrange
            var service = _fixture.Create<PersonalityCheckDALService>();

            // Setup a respond for the DAL api 
            var response = _httpHelperTest.CreateHttpResponse(true, HttpStatusCode.OK);

            HttpClient httpClient = _httpHelperTest.HttpClientFactoryTest(response);

            //Setup the mocked dependency
            _httpClientFactory.Setup(_ => _.CreateClient(It.Is<string>(x => x.Equals(NamedClient.PersonalityCheckDALClient.ToString())))).Returns(httpClient);

            //Inject the dependency into the subject under test
            var selfRegistrationDALService = new PersonalityCheckDALService(_httpClientFactory.Object);

            // Act
            var result = await selfRegistrationDALService.AddNewUser(_user);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task AddNewUser_WhenNotAdded()
        {
            User user = null;

            // Arrange
            var service = _fixture.Create<PersonalityCheckDALService>();

            // Setup a respond for the DAL api 
            var response = _httpHelperTest.CreateHttpResponse(false, HttpStatusCode.OK);

            HttpClient httpClient = _httpHelperTest.HttpClientFactoryTest(response);

            //Setup the mocked dependency
            _httpClientFactory.Setup(_ => _.CreateClient(It.Is<string>(x => x.Equals(NamedClient.PersonalityCheckDALClient.ToString())))).Returns(httpClient);

            //Inject the dependency into the subject under test
            var selfRegistrationDALService = new PersonalityCheckDALService(_httpClientFactory.Object);

            // Act
            var result = await selfRegistrationDALService.AddNewUser(user);

            // Assert
            Assert.False(result);
        }
    }
}
