using AutoFixture.AutoMoq;
using AutoFixture;
using Moq;
using PersonalityCheck.BLL.DataTransferObjects;
using PersonalityCheck.BLL.Service;
using PersonalityCheck.Tests.Helpers;
using System.Net;
using PersonalityCheck.Tests.Models;
using PersonalityCheck.BLL.Enums;

namespace PersonalityCheck.Tests
{
    public class RequestServiceTests
    {
        private readonly IFixture _fixture;
        private Mock<IHttpClientFactory> _httpClientFactory = new Mock<IHttpClientFactory>();
        public readonly TestModel _testModel;
        public readonly ErrorTestModel _errorTestModel;
        public readonly HttpHelperTest _httpHelperTest = new HttpHelperTest();

        public RequestServiceTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _testModel = _fixture.Create<TestModel>();
            _errorTestModel = _fixture.Create<ErrorTestModel>();
        }

        [Fact]
        public async Task GetWithTModel_WhenIsSuccessStatusCode()
        {
            // Arrange
            var response = _httpHelperTest.CreateHttpResponse(_testModel, HttpStatusCode.OK);
            HttpClient _httpClient = _httpHelperTest.HttpClientFactoryTest(response);

            //Setup the mocked dependency
            _httpClientFactory.Setup(_ => _.CreateClient(It.Is<string>(x => x.Equals(NamedClient.PersonalityCheckDALClient.ToString())))).Returns(_httpClient);

            //Inject the dependency into the subject under test
            var requestService = new RequestService(_httpClientFactory.Object, NamedClient.PersonalityCheckDALClient);

            // Act
            var result = await requestService.Get<TestModel>("https://test/");

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual("Unsuccessful request", result.ErrorMessage);
        }

        [Fact]
        public async Task GetWithTModel_WhenIsNotSuccessStatusCode()
        {
            // Arrange
            var response = _httpHelperTest.CreateHttpResponse(_testModel, HttpStatusCode.ServiceUnavailable);
            HttpClient _httpClient = _httpHelperTest.HttpClientFactoryTest(response);

            //Setup the mocked dependency
            _httpClientFactory.Setup(_ => _.CreateClient(It.Is<string>(x => x.Equals(NamedClient.PersonalityCheckDALClient.ToString())))).Returns(_httpClient);

            //Inject the dependency into the subject under test
            var requestService = new RequestService(_httpClientFactory.Object, NamedClient.PersonalityCheckDALClient);

            // Act
            var result = await requestService.Get<List<QuestionAndAnswersDto>>("https://test/");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Unsuccessful request", result.ErrorMessage);
        }

        [Fact]
        public async Task Get_WhenIsSuccessStatusCode()
        {
            // Arrange
            var response = _httpHelperTest.CreateHttpResponse("Request successful", HttpStatusCode.OK);
            HttpClient _httpClient = _httpHelperTest.HttpClientFactoryTest(response);

            //Setup the mocked dependency
            _httpClientFactory.Setup(_ => _.CreateClient(It.Is<string>(x => x.Equals(NamedClient.PersonalityCheckDALClient.ToString())))).Returns(_httpClient);

            //Inject the dependency into the subject under test
            var requestService = new RequestService(_httpClientFactory.Object, NamedClient.PersonalityCheckDALClient);

            // Act
            var result = await requestService.Get("https://test/");

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual("Unsuccessful request", result);
        }

        [Fact]
        public async Task Get_WhenIsNotSuccessStatusCode()
        {
            // Arrange
            var response = _httpHelperTest.CreateHttpResponse((object) null, HttpStatusCode.ServiceUnavailable);
            HttpClient _httpClient = _httpHelperTest.HttpClientFactoryTest(response);

            //Setup the mocked dependency
            _httpClientFactory.Setup(_ => _.CreateClient(It.Is<string>(x => x.Equals(NamedClient.PersonalityCheckDALClient.ToString())))).Returns(_httpClient);

            //Inject the dependency into the subject under test
            var requestService = new RequestService(_httpClientFactory.Object, NamedClient.PersonalityCheckDALClient);

            // Act
            var result = await requestService.Get("https://test/");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Unsuccessful request", result);
        }

        [Fact]
        public async Task Post_WhenIsSuccessStatusCode()
        {
            // Arrange
            var response = _httpHelperTest.CreateHttpResponse(_testModel, HttpStatusCode.OK);
            HttpClient _httpClient = _httpHelperTest.HttpClientFactoryTest(response);

            //Setup the mocked dependency
            _httpClientFactory.Setup(_ => _.CreateClient(It.Is<string>(x => x.Equals(NamedClient.PersonalityCheckDALClient.ToString())))).Returns(_httpClient);

            //Inject the dependency into the subject under test
            var requestService = new RequestService(_httpClientFactory.Object, NamedClient.PersonalityCheckDALClient);

            // Act
            var result = await requestService.Post<TestModel>("https://test/", _testModel);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual("Unsuccessful request", result.ErrorMessage);
        }

        [Fact]
        public async Task Post_WhenIsNotSuccessStatusCode()
        {
            // Arrange
            var response = _httpHelperTest.CreateHttpResponse(_testModel, HttpStatusCode.ServiceUnavailable);
            HttpClient _httpClient = _httpHelperTest.HttpClientFactoryTest(response);

            //Setup the mocked dependency
            _httpClientFactory.Setup(_ => _.CreateClient(It.Is<string>(x => x.Equals(NamedClient.PersonalityCheckDALClient.ToString())))).Returns(_httpClient);

            //Inject the dependency into the subject under test
            var requestService = new RequestService(_httpClientFactory.Object, NamedClient.PersonalityCheckDALClient);

            // Act
            var result = await requestService.Post<TestModel>("https://test/", _testModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Unsuccessful request", result.ErrorMessage);
        }

        [Fact]
        public async Task Update_WhenIsSuccessStatusCode()
        {
            // Arrange
            var response = _httpHelperTest.CreateHttpResponse(_testModel, HttpStatusCode.OK);
            HttpClient _httpClient = _httpHelperTest.HttpClientFactoryTest(response);

            //Setup the mocked dependency
            _httpClientFactory.Setup(_ => _.CreateClient(It.Is<string>(x => x.Equals(NamedClient.PersonalityCheckDALClient.ToString())))).Returns(_httpClient);

            //Inject the dependency into the subject under test
            var requestService = new RequestService(_httpClientFactory.Object, NamedClient.PersonalityCheckDALClient);

            // Act
            var result = await requestService.Update<TestModel>("https://test/", _testModel);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual("Unsuccessful request", result.ErrorMessage);
        }

        [Fact]
        public async Task Update_WhenIsNotSuccessStatusCode()
        {
            // Arrange
            var response = _httpHelperTest.CreateHttpResponse(_testModel, HttpStatusCode.ServiceUnavailable);
            HttpClient _httpClient = _httpHelperTest.HttpClientFactoryTest(response);

            //Setup the mocked dependency
            _httpClientFactory.Setup(_ => _.CreateClient(It.Is<string>(x => x.Equals(NamedClient.PersonalityCheckDALClient.ToString())))).Returns(_httpClient);

            //Inject the dependency into the subject under test
            var requestService = new RequestService(_httpClientFactory.Object, NamedClient.PersonalityCheckDALClient);

            // Act
            var result = await requestService.Update<TestModel>("https://test/", _testModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Unsuccessful request", result.ErrorMessage);
        }

        [Fact]
        public async Task Delete_WhenIsSuccessStatusCode()
        {
            // Arrange
            var response = _httpHelperTest.CreateHttpResponse(_testModel, HttpStatusCode.OK);
            HttpClient _httpClient = _httpHelperTest.HttpClientFactoryTest(response);

            //Setup the mocked dependency
            _httpClientFactory.Setup(_ => _.CreateClient(It.Is<string>(x => x.Equals(NamedClient.PersonalityCheckDALClient.ToString())))).Returns(_httpClient);

            //Inject the dependency into the subject under test
            var requestService = new RequestService(_httpClientFactory.Object, NamedClient.PersonalityCheckDALClient);

            // Act
            var result = await requestService.Delete<TestModel>("https://test/");

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual("Unsuccessful request", result.ErrorMessage);
        }

        [Fact]
        public async Task Delete_WhenIsNotSuccessStatusCode()
        {
            // Arrange
            var response = _httpHelperTest.CreateHttpResponse(_testModel, HttpStatusCode.ServiceUnavailable);
            HttpClient _httpClient = _httpHelperTest.HttpClientFactoryTest(response);

            //Setup the mocked dependency
            _httpClientFactory.Setup(_ => _.CreateClient(It.Is<string>(x => x.Equals(NamedClient.PersonalityCheckDALClient.ToString())))).Returns(_httpClient);

            //Inject the dependency into the subject under test
            var requestService = new RequestService(_httpClientFactory.Object, NamedClient.PersonalityCheckDALClient);

            // Act
            var result = await requestService.Delete<TestModel>("https://test/");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Unsuccessful request", result.ErrorMessage);
        }
    }
}
