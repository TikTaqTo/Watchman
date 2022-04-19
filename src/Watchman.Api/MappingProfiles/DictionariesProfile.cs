using AutoMapper;
using Watchman.Api.Models.Dictionaries;
using Watchman.Api.Models.Replies;

namespace Watchman.Api.MappingProfiles {
  public class DictionariesProfile : Profile {
    public DictionariesProfile() {
      CreateMap<CommonReply, Domain.Replies.CommonReply>().ReverseMap();
      CreateMap<CountriesReply, Domain.Replies.CountriesReply>().ReverseMap();
      CreateMap<CountryReply, Domain.Replies.CountryReply>().ReverseMap();
      CreateMap<GenreReply, Domain.Replies.GenreReply>().ReverseMap();
      CreateMap<GenresReply, Domain.Replies.GenresReply>().ReverseMap();
      CreateMap<StaffPositionsReply, Domain.Replies.StaffPositionsReply>().ReverseMap();
      CreateMap<StaffPositionReply, Domain.Replies.StaffPositionReply>().ReverseMap();

      CreateMap<Country, Domain.EntityModels.Dictionaries.Country>().ReverseMap();
      CreateMap<Genre, Domain.EntityModels.Dictionaries.Genre>().ReverseMap();
      CreateMap<StaffPosition, Domain.EntityModels.Dictionaries.StaffPosition>().ReverseMap();
    }
  }
}