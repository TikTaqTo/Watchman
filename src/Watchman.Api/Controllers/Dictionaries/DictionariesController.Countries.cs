using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Watchman.Api.Models.Dictionaries;
using Watchman.Api.Models.Replies;
using Watchman.Application.Commands.Countries.Create;
using Watchman.Application.Commands.Countries.Update;
using Watchman.Application.Queries.Countries;

namespace Watchman.Api.Controllers.Dictionaries {

  public partial class DictionariesController {

    /// <summary>
    ///     Method to retrieve countries by top parameter
    /// </summary>
    /// <param name="top"></param>
    /// <returns></returns>
    [HttpGet("retrieve-countries-top")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CountriesReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> RetrieveCountriesTop(int top = 10) {
      var query = new RetrieveCountriesQuery(top);
      var countriesReply = await _mediator.Send(query);
      var mappedCountriesReply = _mapper.Map<CountriesReply>(countriesReply);
      return Ok(mappedCountriesReply);
    }

    /// <summary>
    ///     Method to create country
    /// </summary>
    /// <param name="country"></param>
    /// <returns></returns>
    [HttpPost("create-country")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CountryReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> CreateCountry([FromBody] Country country) {
      var domainCountry = _mapper.Map<Domain.EntityModels.Dictionaries.Country>(country);
      var createCountryCommand = new CreateCountryCommand(domainCountry);
      var cratedCountryReply = await _mediator.Send(createCountryCommand);
      var mappedCratedCountryReply = _mapper.Map<CountryReply>(cratedCountryReply);
      return Ok(mappedCratedCountryReply);
    }

    /// <summary>
    ///     Method to retrieve all countries
    /// </summary>
    /// <returns></returns>
    [HttpGet("retrieve-countries-all")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CountriesReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> RetrieveAllCountries() {
      var query = new RetrieveAllCountriesQuery();
      var countriesReply = await _mediator.Send(query);
      var mappedCountriesReply = _mapper.Map<CountriesReply>(countriesReply);
      return Ok(mappedCountriesReply);
    }

    /// <summary>
    ///     Method to update country
    /// </summary>
    /// <param name="country"></param>
    /// <returns></returns>
    [HttpPut("update-country")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CountryReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> CountryReply([FromBody] Country country) {
      var domainCountry = _mapper.Map<Domain.EntityModels.Dictionaries.Country>(country);
      var updateCountryCommand = new UpdateCountryCommand(domainCountry);
      var updatedCountryReply = await _mediator.Send(updateCountryCommand);
      var mappedUpdatedCountryReply = _mapper.Map<CountryReply>(updatedCountryReply);
      return Ok(mappedUpdatedCountryReply);
    }
  }
}