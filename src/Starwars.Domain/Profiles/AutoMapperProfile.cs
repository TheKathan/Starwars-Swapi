using Starwars.Domain.Models;
using Starwars.Domain.Models.Requests;
using Starwars.Domain.Models.Responses;

namespace Starwars.Domain.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, AuthenticateResponse>();
        CreateMap<RegisterRequest, User>()
            .ForMember(m => m.Username,
                opt => opt.MapFrom(o => o.Email));
    }
}