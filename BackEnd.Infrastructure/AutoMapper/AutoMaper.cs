

using AutoMapper;
using BackEnd.Core.Dto.BcaClie;
using BackEnd.Core.Models;

namespace BackEnd.Infrastructure.AutoMapper;

public class AutoMaper: Profile
{
    public AutoMaper()
    {
        // DTO -> Entity
        CreateMap<BcaClieCreateDto, BcaClieEntity>()
            .ForMember(dest => dest.ClieFecIngr, opt => opt.MapFrom(_ => DateTime.Now));

        // Entity -> DTO (si necesitas retornar)
        CreateMap<BcaClieEntity, BcaClieCreateDto>();
    }
}
