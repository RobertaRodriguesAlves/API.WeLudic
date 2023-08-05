using Microsoft.AspNetCore.Http;

namespace WeLudic.Shared.Responses;

public sealed class ApiResponse<T> : ApiResponse
{
    public T Result { get; private set; }

    /// <summary>
    /// Cria uma resposta com HTTP Status 200 OK.
    /// </summary>
    /// <param name="result">Resultado da resposta.</param>
    public static ApiResponse<T> Ok(T result)
        => new() { Success = true, StatusCode = StatusCodes.Status200OK, Result = result };
}
