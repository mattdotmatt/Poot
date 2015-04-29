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
                .ForMember(src => src.RowKey, opt => opt.Ignore())
                .ForMember(src => src.Clues, c => c.MapFrom(g => g.Clues));
            Mapper.CreateMap<Models.Clue, Clue>();

            Mapper.CreateMap<Clue, Models.Clue>();
            Mapper.CreateMap<Game, Models.Game>()
                .ForMember(src => src.Clues, c => c.MapFrom(g => g.Clues));

        }
    }
}