using Microsoft.AspNetCore.Mvc;

namespace FormulaAirline.API.Controllers;

public class BookingController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}