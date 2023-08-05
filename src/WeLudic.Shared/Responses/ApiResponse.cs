namespace WeLudic.Shared.Responses;

/// <summary>
/// Classe responsável pela padronização das respostas da API.
/// </summary>
public class ApiResponse
{
    #region Properties

    /// <summary>
    /// Indica se a requisição foi bem-sucedida.
    /// </summary>
    public bool Success { get; protected set; }

    /// <summary>
    /// O código do status HTTP.
    /// </summary>
    public int StatusCode { get; protected set; }

    /// <summary>
    /// Lista com os erros da requisição se não for bem-sucedida.
    /// </summary>
    public IEnumerable<ApiError> Errors { get; protected set; } = Enumerable.Empty<ApiError>();

    #endregion

    #region HTTP Status 200 Ok

    /// <summary>
    /// Cria uma resposta com HTTP Status 200 Ok.
    /// </summary>
    public static ApiResponse Ok()
    {
        return new ApiResponse
        {
            Success = true,
            StatusCode = 200,
        };
    }

    #endregion

    #region HTTP Status 400 BadRequest

    /// <summary>
    /// Cria uma resposta com HTTP Status 400 BadRequest.
    /// </summary>
    public static ApiResponse BadRequest()
    {
        return new ApiResponse
        {
            Success = false,
            StatusCode = 400
        };
    }

    /// <summary>
    /// Cria uma resposta com HTTP Status 400 BadRequest.
    /// </summary>
    /// <param name="errorMessage">Mensagem de erro a ser exibida na resposta.</param>
    /// <returns></returns>
    public static ApiResponse BadRequest(string errorMessage)
    {
        return new ApiResponse
        {
            Success = false,
            StatusCode = 400,
            Errors = CreateApiErrors(errorMessage)
        };
    }

    // Summary:
    //     Cria uma resposta com HTTP Status 400 BadRequest.
    //
    // Parameters:
    //   errors:
    //     Lista de erros a serem exibidas na resposta.
    public static ApiResponse BadRequest(IEnumerable<ApiError> errors)
    {
        return new ApiResponse
        {
            Success = false,
            StatusCode = 400,
            Errors = errors
        };
    }

    #endregion

    #region HTTP Status 401 Unauthorized

    // Summary:
    //     Cria uma resposta com HTTP Status 401 Unauthorized.
    public static ApiResponse Unauthorized()
    {
        return new ApiResponse
        {
            Success = false,
            StatusCode = 401
        };
    }

    //
    // Summary:
    //     Cria uma resposta com HTTP Status 401 Unauthorized.
    //
    // Parameters:
    //   errorMessage:
    //     Mensagem de erro a ser exibida na resposta.
    public static ApiResponse Unauthorized(string errorMessage)
    {
        return new ApiResponse
        {
            Success = false,
            StatusCode = 401,
            Errors = CreateApiErrors(errorMessage)
        };
    }

    //
    // Summary:
    //     Cria uma resposta com HTTP Status 401 Unauthorized.
    //
    // Parameters:
    //   errors:
    //     Lista de erros a serem exibidas na resposta.
    public static ApiResponse Unauthorized(IEnumerable<ApiError> errors)
    {
        return new ApiResponse
        {
            Success = false,
            StatusCode = 401,
            Errors = errors
        };
    }

    #endregion

    #region HTTP Status 403 Forbidden

    // Summary:
    //     Cria uma resposta com HTTP Status 403 Forbidden.
    public static ApiResponse Forbidden()
    {
        return new ApiResponse
        {
            Success = false,
            StatusCode = 403
        };
    }

    //
    // Summary:
    //     Cria uma resposta com HTTP Status 403 Forbidden.
    //
    // Parameters:
    //   errorMessage:
    //     Mensagem de erro a ser exibida na resposta.
    public static ApiResponse Forbidden(string errorMessage)
    {
        return new ApiResponse
        {
            Success = false,
            StatusCode = 403,
            Errors = CreateApiErrors(errorMessage)
        };
    }

    //
    // Summary:
    //     Cria uma resposta com HTTP Status 403 Forbidden.
    //
    // Parameters:
    //   errors:
    //     Lista de erros a serem exibidas na resposta.
    public static ApiResponse Forbidden(IEnumerable<ApiError> errors)
    {
        return new ApiResponse
        {
            Success = false,
            StatusCode = 403,
            Errors = errors
        };
    }

    #endregion

    #region HTTP Status 404 NotFound

    // Summary:
    //     Cria uma resposta com HTTP Status 404 NotFound.
    public static ApiResponse NotFound()
    {
        return new ApiResponse
        {
            Success = false,
            StatusCode = 404
        };
    }

    // Summary:
    //     Cria uma resposta com HTTP Status 404 NotFound.
    //
    // Parameters:
    //   errorMessage:
    //     Mensagem de erro a ser exibida na resposta.
    public static ApiResponse NotFound(string errorMessage)
    {
        return new ApiResponse
        {
            Success = false,
            StatusCode = 404,
            Errors = CreateApiErrors(errorMessage)
        };
    }

    // Summary:
    //     Cria uma resposta com HTTP Status 404 NotFound.
    //
    // Parameters:
    //   errors:
    //     Lista de erros a serem exibidas na resposta.
    public static ApiResponse NotFound(IEnumerable<ApiError> errors)
    {
        return new ApiResponse
        {
            Success = false,
            StatusCode = 404,
            Errors = errors
        };
    }

    #endregion

    #region HTTP Status 500 InternalServerError

    // Summary:
    //     Cria uma resposta com HTTP Status 500.
    //
    // Parameters:
    //   errorMessage:
    //     Mensagem de erro a ser exibida na resposta.
    public static ApiResponse InternalServerError(string errorMessage)
    {
        return new ApiResponse
        {
            Success = false,
            StatusCode = 500,
            Errors = CreateApiErrors(errorMessage)
        };
    }

    // Summary:
    //     Cria uma resposta com HTTP Status 500.
    //
    // Parameters:
    //   errors:
    //     Lista de erros a serem exibidas na resposta.
    public static ApiResponse InternalServerError(IEnumerable<ApiError> errors)
    {
        return new ApiResponse
        {
            Success = false,
            StatusCode = 500,
            Errors = errors
        };
    }

    #endregion

    private static IEnumerable<ApiError> CreateApiErrors(string errorMessage) => new[] { new ApiError(errorMessage) };
}