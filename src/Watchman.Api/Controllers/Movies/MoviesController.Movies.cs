using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Watchman.Api.Models.Film;
using Watchman.Api.Models.Replies;
using Watchman.Api.Models.Requests;
using Watchman.Application.Commands.Movies.AddGenre;
using Watchman.Application.Commands.Movies.AddStaff;
using Watchman.Application.Commands.Movies.Create;
using Watchman.Application.Commands.Movies.Delete;
using Watchman.Application.Commands.Movies.Update;
using Watchman.Application.Queries.Movies;

namespace Watchman.Api.Controllers.Movies {

  public partial class MoviesController {

    #region Retrieve

    /// <summary>
    ///     Method to retrieve movies by top
    /// </summary>
    /// <param name="top"></param>
    /// <returns></returns>
    [HttpGet("retrieve-movies")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MoviesReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> RetrieveMovies(int top = 10) {
      var query = new RetrieveMoviesQuery(top);
      var moviesReply = await _mediator.Send(query);
      var mappedMoviesReply = _mapper.Map<MoviesReply>(moviesReply);
      return Ok(mappedMoviesReply);
    }

    /// <summary>
    ///     Method to retrieve movies amount
    /// </summary>
    /// <returns></returns>
    [HttpGet("retrieve-movies-amount")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieAmountReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> RetrieveMoviesAmount() {
      var query = new RetrieveMoviesAmountQuery();
      var moviesReply = await _mediator.Send(query);
      var mappedMoviesReply = _mapper.Map<MovieAmountReply>(moviesReply);
      return Ok(mappedMoviesReply);
    }

    /// <summary>
    ///     Method to retrieve movies by name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [HttpGet("retrieve-movies-by-name")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MoviesReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> RetrieveMoviesByName(string movieName = "The Shawshank Redemption") {
      var query = new RetrieveMoviesQueryByName(movieName);
      var moviesReply = await _mediator.Send(query);
      var mappedMoviesReply = _mapper.Map<MoviesReply>(moviesReply);
      return Ok(mappedMoviesReply);
    }

    /// <summary>
    ///     Method to retrieve movies for pagination
    /// </summary>
    /// <param name="page"></param>
    /// <param name="countElement"></param>
    /// <returns></returns>
    [HttpGet("retrieve-movies-pagination")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MoviesReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> RetrieveMovieQueryPagination(int page, int countElement) {
      var query = new RetrieveMovieQueryPagination(page, countElement);
      var moviesReply = await _mediator.Send(query);
      var mappedMoviesReply = _mapper.Map<MoviesReply>(moviesReply);
      return Ok(mappedMoviesReply);
    }

    /// <summary>
    ///     Method to retrieve movie by id
    /// </summary>
    /// <param name="movieId"></param>
    /// <returns></returns>
    [HttpGet("retrieve-movie-by-id")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> RetrieveMovieById(Guid movieId) {
      var query = new RetrieveMovieQueryById(movieId);
      var movieReply = await _mediator.Send(query);
      var mappedMovieReply = _mapper.Map<MovieReply>(movieReply);
      return Ok(mappedMovieReply);
    }

    #endregion Retrieve

    /// <summary>
    ///     Method to create movie
    /// </summary>
    /// <param name="create"></param>
    /// <returns></returns>
    [HttpPost("create-movie")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> CreateMovie([FromBody] Movie movie) {
      var domainMovie = _mapper.Map<Domain.EntityModels.Film.Movie>(movie);
      var createMovieCommand = new CreateMovieCommand(domainMovie);
      var cratedMovieReply = await _mediator.Send(createMovieCommand);
      var mappedCratedMovieReply = _mapper.Map<MovieReply>(cratedMovieReply);
      return Ok(mappedCratedMovieReply);
    }

    /// <summary>
    ///     Method to update movie
    /// </summary>
    /// <param name="movie"></param>
    /// <returns></returns>
    [HttpPost("update-movie")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> UpdateMovie([FromBody] Movie movie) {
      var domainMovie = _mapper.Map<Domain.EntityModels.Film.Movie>(movie);
      var updateMovieCommand = new UpdateMovieCommand(domainMovie);
      var updatedMovieReply = await _mediator.Send(updateMovieCommand);
      var mappedUpdatedMovieReply = _mapper.Map<MovieReply>(updatedMovieReply);
      return Ok(mappedUpdatedMovieReply);
    }

    /// <summary>
    ///     Method to delete movie by id
    /// </summary>
    /// <param name="movieId"></param>
    /// <returns></returns>
    [HttpDelete("delete-movie-by-id")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> DeleteMovie(Guid movieId) {
      var deleteMovieReply = await _mediator.Send(new DeleteMovieCommand(movieId));
      var mappedDeletedMovieReply = _mapper.Map<MovieReply>(deleteMovieReply);
      return Ok(mappedDeletedMovieReply);
    }

    /// <summary>
    ///     Method to add staff to movie
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("add-staff-to-movie")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> AddStaffToMovie([FromBody] AddStaffToMovieRequest request) {
      var domainRequest = _mapper.Map<Domain.Requests.AddStaffToMovieRequest>(request);
      var query = new AddStaffToMovieCommand(domainRequest);
      var movieReply = await _mediator.Send(query);
      var mappedMovieReply = _mapper.Map<MovieReply>(movieReply);
      return Ok(mappedMovieReply);
    }

    /// <summary>
    ///     Method to add genre to movie
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("add-genre-to-movie")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> AddGenreToMovie([FromBody] AddGenreToMovieRequest request) {
      var domainRequest = _mapper.Map<Domain.Requests.AddGenreToMovieRequest>(request);
      var query = new AddGenreToMovieCommand(domainRequest);
      var movieReply = await _mediator.Send(query);
      var mappedMovieReply = _mapper.Map<MovieReply>(movieReply);
      return Ok(mappedMovieReply);
    }
  }
}