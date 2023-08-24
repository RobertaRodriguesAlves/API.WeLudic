using WeLudic.Shared.Requests;

namespace WeLudic.Application.Requests.Games;

public sealed class CreateRouletteSessionRequest : BaseRequestWithValidation
{
    public CreateRouletteSessionRequest(IEnumerable<int> options)
    {
        Options = options;
    }

    public IEnumerable<int> Options { get; }

    public override async Task ValidateAsync()
        => ValidationResult = await LazyValidator.ValidateAsync<CreateRouletteSessionRequestValidator>(this);
}
