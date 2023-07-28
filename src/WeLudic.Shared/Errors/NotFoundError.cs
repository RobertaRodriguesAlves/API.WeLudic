using System.Diagnostics.CodeAnalysis;
using FluentResults;

namespace WeLudic.Shared.Errors;

[ExcludeFromCodeCoverage]
public sealed class NotFoundError : Error
{
    public NotFoundError(string message) : base(message) { }

    public NotFoundError(string message, Error causedBy) : base(message, causedBy) { }
}