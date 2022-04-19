using System;
using System.Linq;
using Watchman.Domain.EntityModels.Film;
using Watchman.Infrastructure.Persistence;
using Watchman.Infrastructure.Services;
using Xunit;

namespace Watchman.UnitTests.Film {

  public class MovieServiceTest {
    private WatchmanServiceContext dbContext;
    private MovieService movieService;
    private readonly string _movieNameDefault;
    private readonly int _countryIdDefault;

    //Enter created country id
    public MovieServiceTest() {
      dbContext = new WatchmanServiceContext();
      movieService = new MovieService(dbContext);
      _movieNameDefault = "Oldboy";
      _countryIdDefault = 1002;
    }

    [Fact]
    public void CreateMovie_AddingOldBoyMovie_ReturnedOldBoyMovieReply() {
      //Arrange
      var oldBoyMovie = new Movie() {
        Name = _movieNameDefault,
        CountryId = _countryIdDefault
      };
      var retrieveMovieResult = new Movie();

      //Act
      if (movieService.RetrieveMovies(1).Result.Movies.ToList().Count == 0) {
        retrieveMovieResult = movieService.CreateMovie(oldBoyMovie).Result.Movie;
      } else {
        Assert.True(true, "The movie of Old boy has already been created, for the tests to function correctly, it is necessary to remove Oldboy.");
        return;
      }

      //Assert
      Assert.Equal(oldBoyMovie, retrieveMovieResult);
    }

    [Fact]
    public void RetrieveMovies_RetriveAllMovie_ReturnedMovieReply() {
      //Arrange
      var allMovies = movieService.RetrieveMovies(1);

      //Act
      var actualMovie = allMovies.Result.Movies.ToList()[0];
      string actualMovieName = actualMovie.Name;

      //Assert
      Assert.NotNull(actualMovieName);
    }

    [Fact]
    public void RetrieveMoviesByName_RetriveOldBoyMovie_ReturnedMovieReply() {
      //Default
      var defaultMovie = movieService.RetrieveMovies(1).Result.Movies.ToList()[0];
      defaultMovie.Name = _movieNameDefault;
      defaultMovie.DeletedAt = null;
      defaultMovie.DeletedBy = null;
      defaultMovie.DeletedReason = null;
      _ = movieService.UpdateMovieById(defaultMovie);

      //Arrange
      var oldBoy = movieService.RetrieveMoviesByName(_movieNameDefault);

      //Act
      var actualMovie = oldBoy.Result.Movies.ToList()[0];
      string actualMovieName = actualMovie.Name;

      //Assert
      Assert.Equal(_movieNameDefault, actualMovieName);
    }

    [Fact]
    public void RetrieveMovieById_RetriveOldBoyMovie_ReturnedMovieReply() {
      //Arrange
      var allMovie = movieService.RetrieveMovies(1);
      var actualMovie = allMovie.Result.Movies.ToList()[0];
      Guid actualMovieId = actualMovie.Id;

      //Act
      var actualMovies = movieService.RetrieveMovieById(actualMovieId).Result.Movie.Name;

      //Assert
      Assert.NotNull(actualMovies);
    }

    [Fact]
    public void RetrieveMoviesAmount_RetriveInteger_ReturnedOneInteger() {
      //Arrange
      int expectedMovieCount = 1;

      //Act
      var amountReply = movieService.RetrieveMoviesAmount();
      int actualMovieCount = amountReply.Result.Amount;

      //Assert
      Assert.Equal(expectedMovieCount, actualMovieCount);
    }

    [Fact]
    public void UpdateMovie_UpdateOldBoyMovie_ReturnedUpdatedOldBoyMovieReply() {
      //Arrange
      string newMovieName = "UpdatedOldBoy";
      var oldMovie = movieService.RetrieveMovies(1).Result.Movies.ToList()[0];

      //Act
      oldMovie.Name = newMovieName;
      var result = movieService.UpdateMovieById(oldMovie);

      //Assert
      Assert.Equal(newMovieName, result.Result.Movie.Name);
    }

    [Fact]
    public void DeleteMovie_DeleteOldBoyMovie_ReturnedDeletedOldBoyMovieReply() {
      //Arrange
      var deletedMovie = movieService.RetrieveMovies(1).Result.Movies.ToList()[0];
      var oldMovieDeletedAt = deletedMovie.DeletedAt;

      //Act
      var result = movieService.DeleteMovieById(deletedMovie.Id);

      //Assert
      Assert.NotEqual(oldMovieDeletedAt, result.Result.Movie.DeletedAt);
    }
  }
}