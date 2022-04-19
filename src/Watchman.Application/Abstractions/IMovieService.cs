using System;
using System.Threading.Tasks;
using Watchman.Domain.EntityModels.Film;
using Watchman.Domain.Replies;
using Watchman.Domain.Requests;

namespace Watchman.Application.Abstractions {

  public interface IMovieService {

    Task<MoviesReply> RetrieveMovies(int top);

    Task<MovieReply> CreateMovie(Movie movie);

    Task<MovieReply> UpdateMovieById(Movie movie);

    Task<MovieReply> DeleteMovieById(Guid movieId);

    Task<MoviesReply> RetrieveMoviesByName(string movieName);

    Task<MovieReply> RetrieveMovieById(Guid movieId);

    Task<MoviesReply> RetrieveMovieQueryPagination(int page, int countElement);

    Task<MovieAmountReply> RetrieveMoviesAmount();

    Task<StaffReply> CreateStaff(Staff staff);

    Task<StaffReply> RetrieveStaffById(Guid staffId);

    Task<StaffReply> DeleteStaffById(Guid staffId);

    Task<StaffReply> UpdateStaff(Staff staff);

    Task<StaffReply> AddPositionToStaff(AddPositionToStaffRequest request);

    Task<MovieReply> AddStaffToMovie(AddStaffToMovieRequest request);

    Task<MovieReply> AddGenreToMovie(AddGenreToMovieRequest request);
  }
}