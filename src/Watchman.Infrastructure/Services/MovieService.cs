using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.EntityModels.Film;
using Watchman.Domain.Replies;
using Watchman.Domain.Requests;
using Watchman.Infrastructure.Persistence;

namespace Watchman.Infrastructure.Services {

  public class MovieService : IMovieService {
    private readonly WatchmanServiceContext _context;

    public MovieService(WatchmanServiceContext context) {
      _context = context;
    }

    #region Movies

    public async Task<MovieReply> CreateMovie(Movie movie) {
      await _context.Movies.AddAsync(movie);
      await _context.SaveChangesAsync();
      return new MovieReply {
        Movie = movie
      };
    }

    public async Task<MovieAmountReply> RetrieveMoviesAmount() {
      var amount = _context.Movies.Count();
      var reply = new MovieAmountReply {
        Amount = amount
      };
      return await Task.FromResult(reply);
    }

    public async Task<MovieReply> RetrieveMovieById(Guid movieId) {
      var movie = _context.Movies.Where(x => x.Id == movieId)
        .Include(x => x.Images)
        .Include(x => x.Country)
        .Include(x => x.Genres)
        .Include(x => x.Staffs).ThenInclude(x => x.StaffPositions)
        .First();
      var movieReply = new MovieReply {
        Movie = movie
      };
      return await Task.FromResult(movieReply);
    }

    public Task<MoviesReply> RetrieveMovies(int top) {
      var movies = _context.Movies.Take(top)
        .Include(x => x.Images)
        .Include(x => x.Country)
        .Include(x => x.Genres)
        .Include(x => x.Staffs).ThenInclude(x => x.StaffPositions);
      var moviesReply = new MoviesReply {
        Movies = movies
      };
      return Task.FromResult(moviesReply);
    }

    public Task<MoviesReply> RetrieveMoviesByName(string movieName) {
      var movies = _context.Movies.Where(m => m.Name.Contains(movieName))
        .Include(x => x.Images)
        .Include(x => x.Country)
        .Include(x => x.Genres)
        .Include(x => x.Staffs).ThenInclude(x => x.StaffPositions);
      var moviesReply = new MoviesReply {
        Movies = movies
      };
      return Task.FromResult(moviesReply);
    }

    public Task<MoviesReply> RetrieveMovieQueryPagination(int page, int countElement) {
      var movies = _context.Movies
        .Skip(page * countElement)
        .Take(countElement)
        .Include(x => x.Images)
        .Include(x => x.Country)
        .Include(x => x.Genres)
        .Include(x => x.Staffs).ThenInclude(x => x.StaffPositions)
        .ToList();
      var moviesReply = new MoviesReply {
        Movies = movies
      };
      return Task.FromResult(moviesReply);
    }

    public async Task<MovieReply> UpdateMovieById(Movie movie) {
      var newMovie = _context.Movies.Find(movie.Id);
      newMovie.ModifiedAt = DateTimeOffset.Now;
      newMovie.ModifiedBy = "admin";
      newMovie.ModifiedReason = "update info";

      newMovie.Name = movie.Name;
      newMovie.Country = movie.Country;
      newMovie.CountryId = movie.CountryId;
      newMovie.Description = movie.Description;
      newMovie.YearOfIssue = movie.YearOfIssue;
      newMovie.Staffs = movie.Staffs;
      newMovie.Genres = movie.Genres;
      newMovie.Images = movie.Images;
      // Implement deep copy

      await _context.SaveChangesAsync();
      return new MovieReply {
        Movie = movie
      };
    }

    public async Task<MovieReply> DeleteMovieById(Guid movieId) {
      var movie = _context.Movies.Find(movieId);
      movie.DeletedAt = DateTimeOffset.Now;
      movie.DeletedBy = "admin";
      movie.DeletedReason = "Deleted info";

      await _context.SaveChangesAsync();
      return new MovieReply() {
        Movie = movie
      };
    }

    #endregion Movies

    #region Staffs

    public async Task<StaffReply> CreateStaff(Staff staff) {
      await _context.Staffs.AddAsync(staff);
      await _context.SaveChangesAsync();
      return new StaffReply {
        Staff = staff
      };
    }

    public async Task<StaffReply> RetrieveStaffById(Guid staffId) {
      var staff = _context.Staffs.Where(x => x.Id == staffId).Include(x => x.StaffPositions).First();
      var staffReply = new StaffReply {
        Staff = staff
      };
      return await Task.FromResult(staffReply);
    }

    public async Task<StaffReply> DeleteStaffById(Guid staffId) {
      var staff = _context.Staffs.Find(staffId);
      staff.DeletedAt = DateTimeOffset.Now;
      staff.DeletedBy = "admin";
      staff.DeletedReason = "delete info";
      await _context.SaveChangesAsync();
      return new StaffReply {
        Staff = staff
      };
    }

    public async Task<StaffReply> UpdateStaff(Staff staff) {
      var newStaff = _context.Staffs.Find(staff);
      newStaff.ModifiedAt = DateTimeOffset.Now;
      newStaff.ModifiedBy = "admin";
      newStaff.ModifiedReason = "update info";
      newStaff.Name = staff.Name;
      newStaff.Surname = staff.Surname;
      newStaff.ImageId = staff.ImageId;
      newStaff.DateOfBirth = staff.DateOfBirth;
      await _context.SaveChangesAsync();
      return new StaffReply {
        Staff = staff
      };
    }

    #endregion Staffs

    #region Binding

    public async Task<StaffReply> AddPositionToStaff(AddPositionToStaffRequest request) {
      var staff = await _context.Staffs.FindAsync(request.StaffId);
      var staffPosition = await _context.StaffPositions.FindAsync(request.StaffPositionId);

      if (staff is null) {
        throw new ArgumentNullException($"Could not find staff by id: {request.StaffId}");
      } else if (staffPosition is null) {
        throw new ArgumentNullException($"Could not find staff position by id: {request.StaffPositionId}");
      }

      staff.StaffPositions.Add(staffPosition);
      await _context.SaveChangesAsync();

      return new StaffReply {
        Staff = staff
      };
    }

    public async Task<MovieReply> AddStaffToMovie(AddStaffToMovieRequest request) {
      var movie = await _context.Movies.FindAsync(request.MovieId);
      var staff = await _context.Staffs.FindAsync(request.StaffId);

      if (movie is null) {
        throw new ArgumentNullException($"Could not find movie by id: {request.MovieId}");
      } else if (staff is null) {
        throw new ArgumentNullException($"Could not find staff by id: {request.StaffId}");
      }

      movie.Staffs.Add(staff);
      await _context.SaveChangesAsync();

      return new MovieReply {
        Movie = movie
      };
    }

    public async Task<MovieReply> AddGenreToMovie(AddGenreToMovieRequest request) {
      var movie = await _context.Movies.FindAsync(request.MovieId);
      var genre = await _context.Genres.FindAsync(request.GenreId);

      if (movie is null) {
        throw new ArgumentNullException($"Could not find movie by id: {request.MovieId}");
      } else if (genre is null) {
        throw new ArgumentNullException($"Could not find genre by id: {request.GenreId}");
      }

      movie.Genres.Add(genre);
      await _context.SaveChangesAsync();

      return new MovieReply {
        Movie = movie
      };
    }

    #endregion Binding
  }
}