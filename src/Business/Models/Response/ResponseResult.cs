namespace Business.Models.Response;

public class ResponseResult
{
    public bool Success { get; set; }
    public int StatusCode { get; set; }
    public string? Message { get; set; }

    public static ResponseResult Ok(string? message = null) => new()
    {
        Success = true,
        StatusCode = 200,
        Message = message
    };
    
    public static ResponseResult Created(string? message = null) => new()
    {
        Success = true,
        StatusCode = 201, 
        Message = message
    };
    
    public static ResponseResult Exists(string? message = null) => new()
    {
        Success = false,
        StatusCode = 409,
        Message = message
    };

    public static ResponseResult InvalidModel(string? message = null) => new()
    {
        Success = false, 
        StatusCode = 400,
        Message = message
    };

    public static ResponseResult Failed(string? message = null) => new()
    {
        Success = false,
        StatusCode = 500,
        Message = message
    };
    
    public static ResponseResult NotFound(string? message = null) => new()
    {
        Success = false,
        StatusCode = 404,
        Message = message,
    };
    
}

public class ResponseResult<T> : ResponseResult
{
    public T? Result { get; set; }

    public static ResponseResult<T> Ok(string? message = null, T? result = default) => new()
    {
        Success = true,
        StatusCode = 200,
        Message = message,
        Result = result
    };

    public new static ResponseResult<T> NotFound(string? message = null) => new()
    {
        Success = false,
        StatusCode = 404,
        Message = message,
        Result = default
    };

    public new static ResponseResult<T> Failed(string? message = null) => new()
    {
        Success = false,
        StatusCode = 500,
        Message = message,
        Result = default
    };

    public new static ResponseResult<T> Exists(string? message = null) => new()
    {
        Success = false,
        StatusCode = 409,
        Message = message,
        Result = default
    };
}