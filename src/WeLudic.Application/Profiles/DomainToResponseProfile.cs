using AutoMapper;
using WeLudic.Application.Responses.Games;
using WeLudic.Domain.Entities;

namespace WeLudic.Application.Profiles;

public class DomainToResponseProfile : Profile
{
    public DomainToResponseProfile()
    {
        CreateMap<IEnumerable<RouletteOption>, IEnumerable<RouletteOptionsResponse>>(MemberList.Destination);
    }
}
