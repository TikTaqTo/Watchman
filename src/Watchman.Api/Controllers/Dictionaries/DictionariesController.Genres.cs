using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Watchman.Api.Models.Dictionaries;
using Watchman.Api.Models.Replies;
using Watchman.Application.Commands.Genres;
using Watchman.Application.Commands.Genres.Delete;
using Watchman.Application.Commands.Genres.Update;
using Watchman.Application.Queries.Genres;

namespace Watchman.Api.Controllers.Dictionaries {

  public partial class DictionariesController {

    /// <summary>
    ///     Method to create genre
    /// </summary>
    /// <param name="genre"></param>
    /// <returns></returns>
    [HttpPost("create-genre")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenreReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> CreateGenre([FromBody] Genre genre) {
      var domainGenre = _mapper.Map<Domain.EntityModels.Dictionaries.Genre>(genre);
      var createGenreCommand = new CreateGenreCommand(domainGenre);
      var createdGenreReply = await _mediator.Send(createGenreCommand);
      var mappedCreatedGenreReply = _mapper.Map<GenreReply>(createdGenreReply);
      return Ok(mappedCreatedGenreReply);
    }

    /// <summary>
    ///     Method to retrieve all genres
    /// </summary>
    /// <returns></returns>
    [HttpGet("retrieve-genres")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenresReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> RetrieveGenres() {
      var query = new RetrieveGenresQuery();
      var genresReply = await _mediator.Send(query);
      var mappedGenresReply = _mapper.Map<GenresReply>(genresReply);
      return Ok(mappedGenresReply);
    }

    /// <summary>
    ///     Method to update genre
    /// </summary>
    /// <param name="genre"></param>
    /// <returns></returns>
    [HttpPut("update-genre")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenreReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> UpdateGenre([FromBody] Genre genre) {
      var domainGenre = _mapper.Map<Domain.EntityModels.Dictionaries.Genre>(genre);
      var updateGenreCommand = new UpdateGenreCommand(domainGenre);
      var updatedGenreReply = await _mediator.Send(updateGenreCommand);
      var mappedUpdatedGenreReply = _mapper.Map<GenreReply>(updatedGenreReply);
      return Ok(mappedUpdatedGenreReply);
    }

    /// <summary>
    ///     Method to delete genre
    /// </summary>
    /// <param name="genreId"></param>
    /// <returns></returns>
    [HttpDelete("delete-genre-by-id")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenreReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> DeleteGenreById(int id) {
      var deletedGenreReply = await _mediator.Send(new DeleteGenreCommand(id));
      var mappedDeletedGenreReply = _mapper.Map<GenreReply>(deletedGenreReply);
      return Ok(mappedDeletedGenreReply);
    }
  }
}