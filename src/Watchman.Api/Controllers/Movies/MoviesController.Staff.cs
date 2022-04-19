using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Watchman.Api.Models.Film;
using Watchman.Api.Models.Replies;
using Watchman.Api.Models.Requests;
using Watchman.Application.Commands.Movies.Create;
using Watchman.Application.Commands.Staffs.AddPosition;
using Watchman.Application.Commands.Staffs.Create;
using Watchman.Application.Commands.Staffs.Delete;
using Watchman.Application.Commands.Staffs.Update;
using Watchman.Application.Queries.Movies;
using Watchman.Application.Queries.Staffs;

namespace Watchman.Api.Controllers.Movies {

  public partial class MoviesController {

    /// <summary>
    ///     Method to create staff
    /// </summary>
    /// <param name="staff"></param>
    /// <returns></returns>
    [HttpPost("create-staff")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StaffReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> CreateMovie([FromBody] Staff staff) {
      var domainStaff = _mapper.Map<Domain.EntityModels.Film.Staff>(staff);
      var createStaffCommand = new CreateStaffCommand(domainStaff);
      var createdMovieReply = await _mediator.Send(createStaffCommand);
      var mappedCreatedStaffReply = _mapper.Map<StaffReply>(createdMovieReply);
      return Ok(mappedCreatedStaffReply);
    }

    /// <summary>
    ///     Method to retrieve staff by id
    /// </summary>
    /// <param name="staffId"></param>
    /// <returns></returns>
    [HttpGet("retrieve-staff-by-id")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StaffReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> RetrieveStaffById(Guid staffId) {
      var query = new RetrieveStaffByIdQuery(staffId);
      var staffReply = await _mediator.Send(query);
      var mappedStaffReply = _mapper.Map<StaffReply>(staffReply);
      return Ok(mappedStaffReply);
    }

    /// <summary>
    ///     Method to delete staff by id
    /// </summary>
    /// <param name="staffId"></param>
    /// <returns></returns>
    [HttpDelete("delete-staff-by-id")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StaffReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> DeleteImage(Guid id) {
      var query = new DeleteStaffCommand(id);
      var staffReply = await _mediator.Send(query);
      var mappedStaffReply = _mapper.Map<StaffReply>(staffReply);
      return Ok(mappedStaffReply);
    }

    /// <summary>
    ///     Method to update staff
    /// </summary>
    /// <param name="staff"></param>
    /// <returns></returns>
    [HttpPut("update-staff-by-id")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StaffReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> UpdateStaff([FromBody] Staff staff) {
      var domainStaff = _mapper.Map<Domain.EntityModels.Film.Staff>(staff);
      var query = new UpdateStaffCommand(domainStaff);
      var staffReply = await _mediator.Send(query);
      var mappedStaffReply = _mapper.Map<StaffReply>(staffReply);
      return Ok(mappedStaffReply);
    }

    /// <summary>
    ///     Method to add position to staff
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("add-position-to-staff")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StaffReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> AddPositionToStaff([FromBody] AddPositionToStaffRequest request) {
      var domainRequest = _mapper.Map<Domain.Requests.AddPositionToStaffRequest>(request);
      var query = new AddPositionToStaffCommand(domainRequest);
      var staffReply = await _mediator.Send(query);
      var mappedStaffReply = _mapper.Map<StaffReply>(staffReply);
      return Ok(mappedStaffReply);
    }
  }
}