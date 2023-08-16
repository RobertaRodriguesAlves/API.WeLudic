using AutoMapper;
using WeLudic.Application.Responses.Games;
using WeLudic.Domain.Entities;

namespace WeLudic.Application.Profiles;

public class DomainToResponseProfile : Profile
{
    public DomainToResponseProfile()
    {
        CreateMap<RouletteOption, RouletteOptionsResponse>(MemberList.Destination);
    }
}
