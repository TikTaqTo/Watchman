using AutoMapper;
using Watchman.Api.Models.Media;
using Watchman.Api.Models.Replies;

namespace Watchman.Api.MappingProfiles {

  public class MediasProfile : Profile {

    public MediasProfile() {
      CreateMap<ImagesReply, Domain.Replies.ImagesReply>().ReverseMap();
      CreateMap<ImageReply, Domain.Replies.ImageReply>().ReverseMap();
      CreateMap<Image, Domain.EntityModels.Media.Image>().ReverseMap();
    }
  }
}