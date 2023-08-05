using FluentResults;
using FluentValidation.Results;
using WeLudic.Shared.Errors;
using WeLudic.Shared.Requests;

namespace WeLudic.Shared.Extensions;

public static class BaseRequestExtensions
{
    private static readonly IEnumerable<Error> EmptyErrors = Enumerable.Empty<Error>();

    public static Result ToFail(this BaseRequestWithValidation request)
        => new Result().WithErrors(request.ValidationResult.ToErrors());

    public static Result<TResponse> ToFail<TResponse>(this BaseRequestWithValidation request)
        => new Result<TResponse>().WithErrors(request.ValidationResult.ToErrors());

    private static IEnumerable<Error> ToErrors(this ValidationResult result)
    {
        IEnumerable<Error> result2;
        if (!result.IsValid)
        {
            result2 = result.Errors.ConvertAll((ValidationFailure failure) => new ValidationError(failure));
        }
        else
        {
            result2 = EmptyErrors;
        }

        return result2;
    }
}
