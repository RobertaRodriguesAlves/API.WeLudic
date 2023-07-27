using System.Diagnostics.CodeAnalysis;
using FluentResults;

namespace WeLudic.Shared.Errors;

[ExcludeFromCodeCoverage]
public class ForbiddenError : Error
{
    public ForbiddenError() { }

    public ForbiddenError(string message) : base(message) { }

    public ForbiddenError(string message, Error causedBy) : base(message, causedBy) { }
}