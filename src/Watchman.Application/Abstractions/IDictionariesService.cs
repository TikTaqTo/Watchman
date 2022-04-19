using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Domain.EntityModels.Dictionaries;
using Watchman.Domain.Replies;

namespace Watchman.Application.Abstractions {

  public interface IDictionariesService {

    Task<CountriesReply> RetrieveAllCountries();

    Task<CountriesReply> RetrieveCountries(int top);

    Task<CountryReply> UpdateCountry(Country country);

    Task<CountryReply> CreateCountry(Country country);

    Task<GenreReply> CreateGenre(Genre genre);

    Task<GenreReply> UpdateGenre(Genre genre);

    Task<GenreReply> DeleteGenreById(int id);

    Task<GenresReply> RetrieveGenres();

    Task<StaffPositionsReply> RetrieveStaffPositions();

    Task<StaffPositionReply> CreateStaffPosition(StaffPosition staffPosition);

    Task<StaffPositionReply> UpdateStaffPosition(StaffPosition staffPosition);

    Task<StaffPositionReply> DeleteStaffPositionById(int id);
  }
}