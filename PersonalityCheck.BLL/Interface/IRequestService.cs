namespace PersonalityCheck.BLL.Interface;

public interface IRequestService
{
    Task<TResponse> Get<TResponse>(string requestUri);
    Task<TResponse> Post<TResponse>(string requestUri, object data);
    Task<TResponse> Update<TResponse>(string requestUri, object data);
    Task<TResponse> Delete<TResponse>(string requestUri);
}