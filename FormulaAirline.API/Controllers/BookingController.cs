using FormulaAirline.API.Models;
using FormulaAirline.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FormulaAirline.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingController : Controller
{
    private readonly ILogger<BookingController> _logger;
    private readonly IMessageProducer _messageProducer;

    // In-Memory Database 
    public static readonly List<Booking> _bookings = new List<Booking>();

    public BookingController(ILogger<BookingController> logger, IMessageProducer messageProducer)
    {
        _logger = logger;
        _messageProducer = messageProducer;
    }

    [HttpPost]
    [Route("Create")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult CreatingBooking(Booking newBooking)
    {
        if (!ModelState.IsValid) return BadRequest( ModelState);
        _bookings.Add(newBooking);  
        _messageProducer.Sendingmessage<Booking>(newBooking);   
        return Ok();    
    }
}