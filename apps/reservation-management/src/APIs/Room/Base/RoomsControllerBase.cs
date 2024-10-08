using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReservationManagement.APIs;
using ReservationManagement.APIs.Common;
using ReservationManagement.APIs.Dtos;
using ReservationManagement.APIs.Errors;

namespace ReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class RoomsControllerBase : ControllerBase
{
    protected readonly IRoomsService _service;

    public RoomsControllerBase(IRoomsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Room
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Room>> CreateRoom(RoomCreateInput input)
    {
        var room = await _service.CreateRoom(input);

        return CreatedAtAction(nameof(Room), new { id = room.Id }, room);
    }

    /// <summary>
    /// Delete one Room
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteRoom([FromRoute()] RoomWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteRoom(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Rooms
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<Room>>> Rooms([FromQuery()] RoomFindManyArgs filter)
    {
        return Ok(await _service.Rooms(filter));
    }

    /// <summary>
    /// Meta data about Room records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> RoomsMeta([FromQuery()] RoomFindManyArgs filter)
    {
        return Ok(await _service.RoomsMeta(filter));
    }

    /// <summary>
    /// Get one Room
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Room>> Room([FromRoute()] RoomWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Room(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Room
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateRoom(
        [FromRoute()] RoomWhereUniqueInput uniqueId,
        [FromQuery()] RoomUpdateInput roomUpdateDto
    )
    {
        try
        {
            await _service.UpdateRoom(uniqueId, roomUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Reservations records to Room
    /// </summary>
    [HttpPost("{Id}/reservations")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> ConnectReservations(
        [FromRoute()] RoomWhereUniqueInput uniqueId,
        [FromQuery()] ReservationWhereUniqueInput[] reservationsId
    )
    {
        try
        {
            await _service.ConnectReservations(uniqueId, reservationsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Reservations records from Room
    /// </summary>
    [HttpDelete("{Id}/reservations")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DisconnectReservations(
        [FromRoute()] RoomWhereUniqueInput uniqueId,
        [FromBody()] ReservationWhereUniqueInput[] reservationsId
    )
    {
        try
        {
            await _service.DisconnectReservations(uniqueId, reservationsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Reservations records for Room
    /// </summary>
    [HttpGet("{Id}/reservations")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<Reservation>>> FindReservations(
        [FromRoute()] RoomWhereUniqueInput uniqueId,
        [FromQuery()] ReservationFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindReservations(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple Reservations records for Room
    /// </summary>
    [HttpPatch("{Id}/reservations")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateReservations(
        [FromRoute()] RoomWhereUniqueInput uniqueId,
        [FromBody()] ReservationWhereUniqueInput[] reservationsId
    )
    {
        try
        {
            await _service.UpdateReservations(uniqueId, reservationsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
