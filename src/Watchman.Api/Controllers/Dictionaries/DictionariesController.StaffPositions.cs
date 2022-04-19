using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Watchman.Api.Models.Dictionaries;
using Watchman.Api.Models.Replies;
using Watchman.Application.Commands.StaffPositions.Create;
using Watchman.Application.Commands.StaffPositions.Delete;
using Watchman.Application.Commands.StaffPositions.Update;
using Watchman.Application.Queries.StaffPositions;

namespace Watchman.Api.Controllers.Dictionaries {

  public partial class DictionariesController {

    /// <summary>
    ///     Method to retrieve all staff positions
    /// </summary>
    /// <returns></returns>
    [HttpGet("retrieve-staffPositions")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StaffPositionsReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> RetrieveStaffPositions() {
      var query = new RetrieveStaffPositionsQuery();
      var staffPositionsReply = await _mediator.Send(query);
      var mappedStaffPositionsReply = _mapper.Map<StaffPositionsReply>(staffPositionsReply);
      return Ok(mappedStaffPositionsReply);
    }

    /// <summary>
    ///     Method to create staffPosition
    /// </summary>
    /// <param name="staffPosition"></param>
    /// <returns></returns>
    [HttpPost("create-staffPosition")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StaffPositionReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> CreateStaffPosition([FromBody] StaffPosition staffPosition) {
      var domainStaffPosition = _mapper.Map<Domain.EntityModels.Dictionaries.StaffPosition>(staffPosition);
      var createStaffPositionCommand = new CreateStaffPositionCommand(domainStaffPosition);
      var cratedStaffPositionReply = await _mediator.Send(createStaffPositionCommand);
      var mappedCratedStaffPositionReply = _mapper.Map<StaffPositionReply>(cratedStaffPositionReply);
      return Ok(mappedCratedStaffPositionReply);
    }

    /// <summary>
    ///     Method to update staffPosition
    /// </summary>
    /// <param name="staffPosition"></param>
    /// <returns></returns>
    [HttpPut("update-staffPosition")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StaffPositionReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> UpdateStaffPosition([FromBody] StaffPosition staffPosition) {
      var domainStaffPosition = _mapper.Map<Domain.EntityModels.Dictionaries.StaffPosition>(staffPosition);
      var updateStaffPositionCommand = new UpdateStaffPositionCommand(domainStaffPosition);
      var updatedStaffPositionReply = await _mediator.Send(updateStaffPositionCommand);
      var mappedUpdatedStaffPositionReply = _mapper.Map<StaffPositionReply>(updatedStaffPositionReply);
      return Ok(mappedUpdatedStaffPositionReply);
    }

    /// <summary>
    ///     Method to delete staffPosition
    /// </summary>
    /// <param name="staffPositionId"></param>
    /// <returns></returns>
    [HttpDelete("delete-staffPosition-by-id")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StaffPositionReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> DeleteStaffPositionById(int id) {
      var deletedStaffPositionReply = await _mediator.Send(new DeleteStaffPositionCommand(id));
      var mappedDeletedStaffPositionReply = _mapper.Map<StaffPositionReply>(deletedStaffPositionReply);
      return Ok(mappedDeletedStaffPositionReply);
    }
  }
}