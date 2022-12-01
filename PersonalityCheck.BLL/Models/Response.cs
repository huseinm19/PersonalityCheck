using System.ComponentModel.DataAnnotations;

namespace PersonalityCheck.BLL.Models;

public class Response<T>
{
    public bool HasError { get; private set; }
    public T Data { get; private set; }
    [DataType(DataType.Text)]
    public string ErrorMessage { get; private set; }

    private Response()
    {

    }

    public static Response<T> Successful(T data) => new() { Data = data };
    public static Response<T> Failed(string errorMessage) => new() { ErrorMessage = errorMessage, HasError = true, Data = default };
}