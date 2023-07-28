using FluentResults;
using Microsoft.AspNetCore.Mvc;
using WeLudic.Shared.Errors;
using WeLudic.Shared.Responses;

namespace WeLudic.Shared.Extensions;

public static class FluentResultExtensions
{
    private static readonly OkObjectResult EmptyOkResult = new(ApiResponse.Ok());

    public static IActionResult ToActionResult(this Result result)
        => result.IsFailed ? result.ToHttpNonSuccessResult() : EmptyOkResult;

    public static IActionResult ToActionResult<T>(this Result<T> result)
        => result.IsFailed ? result.ToHttpNonSuccessResult() : new OkObjectResult(ApiResponse<T>.Ok(result.Value));

    private static IActionResult ToHttpNonSuccessResult(this ResultBase result)
    {
        var apiErrors = result.Errors.ToApiErrors();

        ApiResponse apiResponse;

        if (result.HasError<ValidationError>() || result.HasError<BusinessError>())
        {
            apiResponse = ApiResponse.BadRequest(apiErrors);
        }
        else if (result.HasError<UnauthorizedError>())
        {
            apiResponse = ApiResponse.Unauthorized(apiErrors);
        }
        else if (result.HasError<ForbiddenError>())
        {
            apiResponse = ApiResponse.Forbidden(apiErrors);
        }
        else if (result.HasError<NotFoundError>())
        {
            apiResponse = ApiResponse.NotFound(apiErrors);
        }
        else
        {
            apiResponse = ApiResponse.InternalServerError(apiErrors);
        }

        return new ObjectResult(apiResponse) { StatusCode = apiResponse.StatusCode };
    }

    private static IEnumerable<ApiError> ToApiErrors(this IEnumerable<IError> errors)
        => errors
            .Select(error => error.Message)
            .Distinct()
            .OrderBy(message => message)
            .Select(message => new ApiError(message))
            .ToList();
}
