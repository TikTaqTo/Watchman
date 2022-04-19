using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchman.Application.Abstractions;
using Watchman.Domain.EntityModels.Dictionaries;
using Watchman.Domain.Replies;
using Watchman.Infrastructure.Persistence;

namespace Watchman.Infrastructure.Services {

  public class DictionariesService : IDictionariesService {
    private readonly WatchmanServiceContext _context;

    public DictionariesService(WatchmanServiceContext context) {
      _context = context;
    }

    #region Countries

    public Task<CountriesReply> RetrieveCountries(int top) {
      var countries = _context.Countries.Take(top);
      var countriesReply = new CountriesReply {
        Countries = countries
      };
      return Task.FromResult(countriesReply);
    }

    public async Task<CountryReply> CreateCountry(Country country) {
      await _context.Countries.AddAsync(country);
      await _context.SaveChangesAsync();
      return new CountryReply {
        Country = country
      };
    }

    public async Task<CountriesReply> RetrieveAllCountries() {
      var countries = _context.Countries;
      var countriesReply = new CountriesReply {
        Countries = countries
      };
      return await Task.FromResult(countriesReply);
    }

    public async Task<CountryReply> UpdateCountry(Country country) {
      _context.Countries.Update(country);
      await _context.SaveChangesAsync();
      return new CountryReply {
        Country = country
      };
    }

    #endregion Countries

    #region Genres

    public async Task<GenreReply> CreateGenre(Genre genre) {
      await _context.Genres.AddAsync(genre);
      await _context.SaveChangesAsync();
      return new GenreReply {
        Genre = genre
      };
    }

    public async Task<GenresReply> RetrieveGenres() {
      var genres = _context.Genres;
      var genresReply = new GenresReply {
        Genres = genres
      };
      return await Task.FromResult(genresReply);
    }

    public async Task<GenreReply> UpdateGenre(Genre genre) {
      _context.Genres.Update(genre);
      await _context.SaveChangesAsync();
      return new GenreReply {
        Genre = genre
      };
    }

    public async Task<GenreReply> DeleteGenreById(int id) {
      var genre = _context.Genres.Find(id);
      genre.DeletedAt = DateTimeOffset.Now;
      genre.DeletedBy = "admin";
      genre.DeletedReason = "delete info";
      await _context.SaveChangesAsync();
      return new GenreReply {
        Genre = genre
      };
    }

    #endregion Genres

    #region StaffPositions

    public Task<StaffPositionsReply> RetrieveStaffPositions() {
      var staffPositions = _context.StaffPositions.ToList();
      var staffPositionsReply = new StaffPositionsReply {
        StaffPositions = staffPositions
      };
      return Task.FromResult(staffPositionsReply);
    }

    public async Task<StaffPositionReply> CreateStaffPosition(StaffPosition staffPosition) {
      await _context.StaffPositions.AddAsync(staffPosition);
      await _context.SaveChangesAsync();
      return new StaffPositionReply {
        StaffPosition = staffPosition
      };
    }

    public async Task<StaffPositionReply> UpdateStaffPosition(StaffPosition staffPosition) {
      _context.StaffPositions.Update(staffPosition);
      await _context.SaveChangesAsync();
      return new StaffPositionReply {
        StaffPosition = staffPosition
      };
    }

    public async Task<StaffPositionReply> DeleteStaffPositionById(int id) {
      var staffPosition = _context.StaffPositions.Find(id);
      staffPosition.DeletedAt = DateTimeOffset.Now;
      staffPosition.DeletedBy = "admin";
      staffPosition.DeletedReason = "delete info";
      await _context.SaveChangesAsync();
      return new StaffPositionReply {
        StaffPosition = staffPosition
      };
    }

    #endregion StaffPositions
  }
}