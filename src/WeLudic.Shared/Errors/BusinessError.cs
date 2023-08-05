using System.Diagnostics.CodeAnalysis;
using FluentResults;

namespace WeLudic.Shared.Errors;

[ExcludeFromCodeCoverage]
public sealed class BusinessError : Error
{
    public BusinessError(string message) : base(message) { }

    public BusinessError(string message, Error causedBy) : base(message, causedBy) { }
}
