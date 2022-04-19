using AutoMapper;
using Watchman.Api.Models.Film;
using Watchman.Api.Models.Replies;
using Watchman.Api.Models.Requests;

namespace Watchman.Api.MappingProfiles {

  public class MoviesProfile : Profile {

    public MoviesProfile() {
      CreateMap<MovieReply, Domain.Replies.MovieReply>().ReverseMap();
      CreateMap<MoviesReply, Domain.Replies.MoviesReply>().ReverseMap();
      CreateMap<StaffReply, Domain.Replies.StaffReply>().ReverseMap();
      CreateMap<MovieAmountReply, Domain.Replies.MovieAmountReply>().ReverseMap();

      CreateMap<Movie, Domain.EntityModels.Film.Movie>().ReverseMap();
      CreateMap<Staff, Domain.EntityModels.Film.Staff>().ReverseMap();

      CreateMap<AddPositionToStaffRequest, Domain.Requests.AddPositionToStaffRequest>().ReverseMap();
      CreateMap<AddStaffToMovieRequest, Domain.Requests.AddStaffToMovieRequest>().ReverseMap();
      CreateMap<AddGenreToMovieRequest, Domain.Requests.AddGenreToMovieRequest>().ReverseMap();
    }
  }
}