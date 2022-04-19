using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Watchman.Api.Models.Replies;
using Watchman.Application.Queries.Images;
using Watchman.Application.Commands.Images.Create;
using System.IO;
using Watchman.Application.Commands.Images.Delete;
using Watchman.Application.Commands.Images.Update;
using Watchman.Api.Models.Media;

namespace Watchman.Api.Controllers.Medias {

  public partial class MediasController {

    /// <summary>
    ///     Method to retrieve images with top
    /// </summary>
    /// <param name="top"></param>
    /// <returns></returns>
    [HttpGet("retrieve-images")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ImagesReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> RetrieveImages(int top = 10) {
      var query = new RetrieveImagesQuery(top);
      var imagesReply = await _mediator.Send(query);
      var mappedImagesReply = _mapper.Map<ImagesReply>(imagesReply);
      return Ok(mappedImagesReply);
    }

    /// <summary>
    ///     Method to retrieve image by id
    /// </summary>
    /// <param name="imageId"></param>
    /// <returns></returns>
    [HttpGet("retrieve-image-by-id")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ImageReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> RetrieveByIdImages(Guid id) {
      var query = new RetriveImageByMovieId(id);
      var imagesReply = await _mediator.Send(query);
      var mappedImagesReply = _mapper.Map<ImageReply>(imagesReply);
      return Ok(mappedImagesReply);
    }

    /// <summary>
    ///     Method to retrieve images by movie id
    /// </summary>
    /// <param name="movieId"></param>
    /// <returns></returns>
    [HttpGet("retrieve-image-by-movieId")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ImageReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> RetrieveByMovieIdImages(Guid id) {
      var query = new RetrieveByIdImageQuery(id);
      var imagesReply = await _mediator.Send(query);
      var mappedImagesReply = _mapper.Map<ImageReply>(imagesReply);
      return Ok(mappedImagesReply);
    }

    /// <summary>
    ///     Method to create image
    /// </summary>
    /// <param name="image"></param>
    /// <param name="movieId"></param>
    /// <returns></returns>
    [HttpPost("create-image")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ImageReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> CreateImage([FromForm(Name = "file")] IFormFile file, [FromForm] Guid? movieId = null) {
      var domainImage = new Domain.EntityModels.Media.Image();
      domainImage.MovieId = movieId;
      domainImage.Name = Path.GetFileName(file.FileName);
      using (var dataStream = new MemoryStream()) {
        await file.CopyToAsync(dataStream);
        domainImage.Source = dataStream.ToArray();
      }
      var createCountryCommand = new CreateImageCommand(domainImage);
      var cratedImageReply = await _mediator.Send(createCountryCommand);
      var mappedCratedImageReply = _mapper.Map<ImageReply>(cratedImageReply);
      return Ok(mappedCratedImageReply);
    }

    /// <summary>
    ///     Method to delete image
    /// </summary>
    /// <param name="imageId"></param>
    /// <returns></returns>
    [HttpDelete("delete-image")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ImageReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> DeleteImage(Guid id) {
      var query = new DeleteImageCommand(id);
      var imagesReply = await _mediator.Send(query);
      var mappedImagesReply = _mapper.Map<ImageReply>(imagesReply);
      return Ok(mappedImagesReply);
    }

    /// <summary>
    ///     Method to update image
    /// </summary>
    /// <param name="image"></param>
    /// <returns></returns>
    [HttpPut("update-image")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ImageReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> UpdateImage([FromBody] Image image) {
      var domainImage = _mapper.Map<Domain.EntityModels.Media.Image>(image);
      var query = new UpdateImageCommand(domainImage);
      var imagesReply = await _mediator.Send(query);
      var mappedImagesReply = _mapper.Map<ImageReply>(imagesReply);
      return Ok(mappedImagesReply);
    }
  }
}