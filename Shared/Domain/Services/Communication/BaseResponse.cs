namespace Jobit.API.Shared.Domain.Services.Communication;

public class BaseResponse<T> //Template (really useful)
{   
    //Constructor - 1
    protected BaseResponse(T resource)
    {
        Success = true;
        Resource = resource;
        Message = string.Empty;
    }
    
    //Constructor - 2
    protected BaseResponse(string message)
    {
        Success = false;
        Resource = default;
        Message = message;
    }

    public bool Success { get; private set; }
    public string Message { get; private set; }
    public T Resource { get; private set; }
}