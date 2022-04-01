using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Calculator.Models;
using System.Data;
using System.Text;

namespace Calculator.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Produces("text/html")]
    public IActionResult Calculate(string number)
    {
        CalculatorModel cal = new CalculatorModel();
        DataTable table = new DataTable();

        string value = table.Compute(number, null).ToString();
        cal.CalculateValue = value;
        return Content(cal.CalculateValue, "text/html", Encoding.UTF8);
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
