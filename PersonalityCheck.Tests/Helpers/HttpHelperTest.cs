using Moq.Protected;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PersonalityCheck.Tests.Helpers
{
    public class HttpHelperTest
    {
        public HttpClient HttpClientFactoryTest(HttpResponseMessage response)
        {
            // Setup a respond for the staging api 
            var handlerMock = new Mock<HttpMessageHandler>();

            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("https://test/")
            };

            return httpClient;
        }

        public HttpResponseMessage CreateHttpResponse<T>(T objectToReturn, HttpStatusCode statusCode)
        {

            var response = new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StringContent(JsonConvert.SerializeObject(objectToReturn)),
            };

            return response;
        }

        public HttpResponseMessage CreateHttpResponseForString(string contentString, HttpStatusCode statusCode)
        {

            var response = new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StringContent(contentString),
            };

            return response;
        }
    }
}
