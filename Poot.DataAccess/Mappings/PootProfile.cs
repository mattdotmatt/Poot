using AutoMapper;
using Poot.DAL.Entities;

namespace Poot.DAL.Mappings
{
    /// <summary>
    /// All the mappings required for DAL <=> Service Layer
    /// </summary>
    public class PootProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Models.Game, Game>()
                .ForMember(src => src.ETag, opt => opt.Ignore())
                .ForMember(src => src.PartitionKey, opt => opt.Ignore())
                .ForMember(src => src.Timestamp, opt => opt.Ignore())
                .ForMember(src => src.RowKey, opt => opt.Ignore());
            Mapper.CreateMap<Game, Models.Game>();
        }
    }
}