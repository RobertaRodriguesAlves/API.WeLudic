using System.Text.RegularExpressions;
using Ardalis.Result;

namespace WeLudic.Domain.Entities;
public sealed record Email
{
    private static readonly Regex EmailRegex = new(
        "^([0-9a-zA-Z]([\\+\\-_\\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]*\\.)+[a-zA-Z0-9]{2,17})$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    private Email(string address) =>
        Address = address.ToLowerInvariant().Trim();

    public string Address { get; }

    public static Result<Email> Create(string emailAddress)
    {
        if (string.IsNullOrWhiteSpace(emailAddress))
            return Result.Error("Endereço de e-mail deve ser informado.");

        return EmailRegex.IsMatch(emailAddress)
            ? Result.Success(new Email(emailAddress))
            : Result.Error("Endereço de e-mail inválido.");
    }
}
