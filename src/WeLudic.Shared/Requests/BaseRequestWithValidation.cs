using FluentValidation.Results;
using Newtonsoft.Json;

namespace WeLudic.Shared.Requests;

public abstract class BaseRequestWithValidation
{
    protected BaseRequestWithValidation() => ValidationResult = new ValidationResult();

    [JsonIgnore]
    public ValidationResult ValidationResult { get; protected set; }

    /// <summary>
    /// Indica se a requisição é válida.
    /// </summary>
    [JsonIgnore]
    public bool IsValid => ValidationResult.IsValid;

    /// <summary>
    /// Valida a requisição.
    /// </summary>
    public abstract Task ValidateAsync();
}
