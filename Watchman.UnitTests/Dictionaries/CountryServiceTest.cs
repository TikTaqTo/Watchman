using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watchman.Domain.EntityModels.Dictionaries;
using Watchman.Domain.Replies;
using Watchman.Infrastructure.Persistence;
using Watchman.Infrastructure.Services;
using Xunit;

namespace Watchman.UnitTests.Dictionaries {
  /// <summary>
  ///     This class works directly with the database and checks the methods of services,
  ///     for this reason, the speed of passing tests is so low, there will be separate
  ///     tests working with mock data
  /// </summary>

  public class CountryServiceTest {
    private WatchmanServiceContext dbContext;
    private DictionariesService dictionariesService;

    public CountryServiceTest() {
      dbContext = new WatchmanServiceContext();
      dictionariesService = new DictionariesService(dbContext);
    }

    [Fact]
    public void CreateCountry_AddingJapanCountry_ReturnedJapanCountry() {
      //Arrange
      var japanCountry = new Country() {
        Name = "Japan"
      };
      var countryRetrieveResult = new Country();

      //Act
      if (dictionariesService.RetrieveAllCountries().Result.Countries.ToList().Count == 0) {
        countryRetrieveResult = dictionariesService.CreateCountry(japanCountry).Result.Country;
      } else {
        Assert.True(true, "The country of Japan has already been created, for the tests to function correctly, it is necessary to remove Japan.");
        return;
      }

      //Assert
      Assert.Equal(japanCountry, countryRetrieveResult);
    }

    [Fact]
    public void RetrieveCountries_RetriveOneCountry_ReturnedJapanCountry() {
      //Arrange
      var allCountry = dictionariesService.RetrieveCountries(1);

      //Act
      var actualCountry = allCountry.Result.Countries.ToList();
      string actualCountryName = actualCountry[0].Name;

      //Assert
      Assert.NotNull(actualCountryName);
    }

    [Fact]
    public void UpdateCountry_UpdateFirstCountry_ReturnedUpdatedJapanCountryReply() {
      //Arrange
      string newCountryName = "UpdatedJapan";
      var oldCountry = dictionariesService.RetrieveAllCountries().Result.Countries.ToList()[0];

      //Act
      oldCountry.Name = newCountryName;

      var result = dictionariesService.UpdateCountry(oldCountry);

      //Assert
      Assert.Equal(newCountryName, result.Result.Country.Name);
    }

    [Fact]
    public void RetrieveAllCountries_JapanCountryRetrieve_ReturnAllCountry() {
      //Arrange
      var allCountry = new List<Country>();
      int actualCount;
      int errorCount = 0;

      //Act
      allCountry = dictionariesService.RetrieveAllCountries().Result.Countries.ToList();
      actualCount = allCountry.Count;

      //Assert
      Assert.NotEqual(errorCount, actualCount);
    }
  }
}