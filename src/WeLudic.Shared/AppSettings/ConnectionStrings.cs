using System.ComponentModel.DataAnnotations;

namespace WeLudic.Shared.AppSettings;

public sealed class ConnectionStrings
{
    [Required]
    public string Database { get; private init; }
}
