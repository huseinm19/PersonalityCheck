using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PersonalityCheck.BLL.Enums;
using PersonalityCheck.BLL.Models;

namespace PersonalityCheck.BLL.Service;

public class RequestService
{
    public readonly HttpClient _httpClient;
    private readonly NamedClient _namedClient;
    public RequestService(IHttpClientFactory httpClientFactory, NamedClient namedClient)
    {
        _httpClient = httpClientFactory.CreateClient(namedClient.ToString());
        _namedClient = namedClient;
    }

    public virtual async Task<Response<TModel>> Get<TModel>(string requestUri) where TModel : class
    {
        var request = await _httpClient.GetAsync(requestUri);

        if (request.IsSuccessStatusCode)
        {
            var result = await request.Content.ReadAsStringAsync();
            return Response<TModel>.Successful(JsonConvert.DeserializeObject<TModel>(result));
        }

        return Response<TModel>.Failed("Unsuccessful request");
    }

    public virtual async Task<string> Get(string requestUri)
    {
        var request = await _httpClient.GetAsync(requestUri);

        if (request.IsSuccessStatusCode)
        {
            var result = await request.Content.ReadAsStringAsync();
            return result;
        }

        return "Unsuccessful request";
    }


    public virtual async Task<Response<TModel>> Post<TModel>(string requestUri, object data)
    {
        var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

        var request = await _httpClient.PostAsync(requestUri, content);

        if (request.IsSuccessStatusCode)
        {
            var result = await request.Content.ReadAsStringAsync();
            return Response<TModel>.Successful(JsonConvert.DeserializeObject<TModel>(result));
        }

        return Response<TModel>.Failed("Unsuccessful request");
    }

    public virtual async Task<Response<TModel>> Update<TModel>(string requestUri, object data) where TModel : class
    {
        var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

        var request = await _httpClient.PutAsync(requestUri, content);

        if (request.IsSuccessStatusCode)
        {
            var result = await request.Content.ReadAsStringAsync();
            return Response<TModel>.Successful(JsonConvert.DeserializeObject<TModel>(result));
        }

        return Response<TModel>.Failed("Unsuccessful request");
    }

    public virtual async Task<Response<TModel>> Delete<TModel>(string requestUri) where TModel : class
    {
        var request = await _httpClient.DeleteAsync(requestUri);

        if (request.IsSuccessStatusCode)
        {
            var result = await request.Content.ReadAsStringAsync();
            return Response<TModel>.Successful(JsonConvert.DeserializeObject<TModel>(result));
        }

        return Response<TModel>.Failed("Unsuccessful request");
    }
}