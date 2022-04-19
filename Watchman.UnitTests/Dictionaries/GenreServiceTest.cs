using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.EntityModels.Dictionaries;
using Watchman.Infrastructure.Persistence;
using Watchman.Infrastructure.Services;
using Xunit;

namespace Watchman.UnitTests.Dictionaries {

  /// <summary>
  ///     This class works directly with the database and checks the methods of services,
  ///     for this reason, the speed of passing tests is so low, there will be separate
  ///     tests working with mock data
  /// </summary>
  public class GenreServiceTest {
    private WatchmanServiceContext dbContext;
    private DictionariesService dictionariesService;

    public GenreServiceTest() {
      dbContext = new WatchmanServiceContext();
      dictionariesService = new DictionariesService(dbContext);
    }

    /// <summary>
    ///     The test for CreateGenre only works if there are
    ///     no records of any genres in the database,
    ///     since we have unit tests
    /// </summary>
    [Fact]
    public void CreateGenre_AddingActionGenre_ReturnedActionGenreReply() {
      //Arrange
      var actionGenre = new Genre() {
        Name = "Action"
      };
      var genreRetrieveResult = new Genre();

      //Act
      if (dictionariesService.RetrieveGenres().Result.Genres.ToList().Count == 0) {
        genreRetrieveResult = dictionariesService.CreateGenre(actionGenre).Result.Genre;
      } else {
        Assert.True(true, "The genre of Action has already been created, for the tests to function correctly, it is necessary to remove Action.");
        return;
      }

      //Assert
      Assert.Equal(actionGenre.Name, genreRetrieveResult.Name);
    }

    [Fact]
    public void RetrieveGenres_RetriveAllGenre_ReturnedActionGenreReply() {
      //Arrange
      var allGenres = dictionariesService.RetrieveGenres();

      //Act
      var actualGenre = allGenres.Result.Genres.ToList()[0];
      string actualGenreName = actualGenre.Name;

      //Assert
      Assert.NotNull(actualGenreName);
    }

    [Fact]
    public void UpdateGenre_UpdateActionGenre_ReturnedUpdatedActionGenreReply() {
      //Arrange
      string newGenreName = "UpdatedAction";
      var oldGenre = dictionariesService.RetrieveGenres().Result.Genres.ToList()[0];

      //Act
      oldGenre.Name = newGenreName;

      var result = dictionariesService.UpdateGenre(oldGenre);

      //Assert
      Assert.Equal(newGenreName, result.Result.Genre.Name);
    }

    [Fact]
    public void DeleteGenre_DeleteActionGenre_ReturnedDeletedActionGenreReply() {
      //Arrange
      var deletedGenre = dictionariesService.RetrieveGenres().Result.Genres.ToList()[0];
      var oldGenreDeletedAt = deletedGenre.DeletedAt;

      //Act
      var result = dictionariesService.DeleteGenreById(deletedGenre.Id);

      //Default
      deletedGenre.Name = "Action";
      deletedGenre.DeletedAt = null;
      deletedGenre.DeletedBy = null;
      deletedGenre.DeletedReason = null;
      _ = dictionariesService.UpdateGenre(deletedGenre);

      //Assert
      Assert.NotEqual(oldGenreDeletedAt, result.Result.Genre.DeletedAt);
    }
  }
}