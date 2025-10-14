namespace Finances_Uno.WebServices.Finances;

public class APIResult
{

    public static APIResult Success() => new APIResult(
        isSuccess: true,
        message: "",
        error: "",
        cacheChangeDomain: enumCacheChangeDomain.None
    );

    public static APIResult Success(string message) => new APIResult(
        isSuccess: true,
        message: message,
        error: "",
        cacheChangeDomain: enumCacheChangeDomain.None
    );

    public static APIResult Fail(string message) => new APIResult(
        isSuccess: false,
        message: message,
        error: "",
        cacheChangeDomain: enumCacheChangeDomain.None
    );

    public APIResult(bool isSuccess, string? message, string? error, enumCacheChangeDomain cacheChangeDomain)
    {
        IsSuccess = isSuccess;
        Message = message ?? "";
        Error = error ?? "";
        CacheChangeDomain = cacheChangeDomain;
    }

    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public string Error { get; set; }
    public enumCacheChangeDomain CacheChangeDomain { get; set; }
}

public class APIResult<T> : APIResult
{
    public APIResult(bool isSuccess, string? message, string? error, enumCacheChangeDomain cacheChangeDomain, T? obj) : base(isSuccess, message, error, cacheChangeDomain)
    {
        Obj = obj;
    }

    public static APIResult<T> Success(T obj) => new APIResult<T>(
        isSuccess: true,
        message: "",
        error: "",
        cacheChangeDomain: enumCacheChangeDomain.None,
        obj: obj
    );

    public static APIResult<T> Success(T obj, string message) => new APIResult<T>(
        isSuccess: true,
        message: message,
        error: "",
        cacheChangeDomain: enumCacheChangeDomain.None,
        obj: obj
    );

    public static new APIResult<T> Fail(string message) => new APIResult<T>(
        isSuccess: false,
        message: message,
        error: "",
        cacheChangeDomain: enumCacheChangeDomain.None,
        obj: default(T)
    );

    public T? Obj { get; set; }
}
