namespace WeLudic.Domain.ValueObjects;
public sealed record Email
{
    public Email(string address) =>
        Address = address.ToLowerInvariant().Trim();

    public string Address { get; }
}
