using System.Diagnostics.CodeAnalysis;
using FluentResults;
using FluentValidation.Results;

namespace WeLudic.Shared.Errors;

[ExcludeFromCodeCoverage]
public sealed class ValidationError : Error
{
    public ValidationError(string message)
        : base(message) { }

    public ValidationError(ValidationFailure failure)
        : base(failure.ErrorMessage) { }
}