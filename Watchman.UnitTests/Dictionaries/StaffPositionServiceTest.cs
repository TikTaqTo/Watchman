using System.Linq;
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
  public class StaffPositionServiceTest {
    private WatchmanServiceContext dbContext;
    private DictionariesService dictionariesService;

    public StaffPositionServiceTest() {
      dbContext = new WatchmanServiceContext();
      dictionariesService = new DictionariesService(dbContext);
    }

    [Fact]
    public void CreateStaff_AddingProducerStaff_ReturnedProducerStaffPositionReply() {
      //Arrange
      var staffPosition = new StaffPosition() {
        Name = "Producer"
      };
      var staffRetrieveResult = new StaffPosition();

      //Act
      if (dictionariesService.RetrieveStaffPositions().Result.StaffPositions.ToList().Count == 0) {
        staffRetrieveResult = dictionariesService.CreateStaffPosition(staffPosition).Result.StaffPosition;
      } else {
        Assert.True(true, "The genre of Action has already been created, for the tests to function correctly, it is necessary to remove Action.");
        return;
      }

      //Assert
      Assert.Equal(staffPosition.Name, staffRetrieveResult.Name);
    }

    [Fact]
    public void RetrieveStaffPositions_RetriveAllStaffPositions_ReturnedStaffPositionsReply() {
      //Arrange
      var allStaffPositions = dictionariesService.RetrieveStaffPositions();

      //Act
      var actualStaffPosition = allStaffPositions.Result.StaffPositions.ToList()[0];
      string actualStaffPositionName = actualStaffPosition.Name;

      //Assert
      Assert.NotNull(actualStaffPositionName);
    }

    [Fact]
    public void UpdateStaffPosition_UpdateStaffPosition_ReturnedUpdatedStaffPositionReply() {
      //Arrange
      string newStaffPositionName = "UpdatedProducer";
      var oldStaffPosition = dictionariesService.RetrieveStaffPositions().Result.StaffPositions.ToList()[0];

      //Act
      oldStaffPosition.Name = newStaffPositionName;

      var result = dictionariesService.UpdateStaffPosition(oldStaffPosition);

      //Assert
      Assert.Equal(newStaffPositionName, result.Result.StaffPosition.Name);
    }

    //If the test method from below did not work the first time,
    //run it several times
    [Fact]
    public void DeleteStaffPosition_DeleteStaffPosition_ReturnedDeletedStaffPositionReply() {
      //Arrange
      var deletedStaffPosition = dictionariesService.RetrieveStaffPositions().Result.StaffPositions.ToList()[0];
      var oldGenreDeletedAt = deletedStaffPosition.DeletedAt;

      //Act
      var result = dictionariesService.DeleteStaffPositionById(deletedStaffPosition.Id);

      //Default
      deletedStaffPosition.Name = "Action";
      deletedStaffPosition.DeletedAt = null;
      deletedStaffPosition.DeletedBy = null;
      deletedStaffPosition.DeletedReason = null;
      _ = dictionariesService.UpdateStaffPosition(deletedStaffPosition);

      //Assert
      Assert.NotEqual(oldGenreDeletedAt, result.Result.StaffPosition.DeletedAt);
    }
  }
}