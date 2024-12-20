using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dashbord.Models;
using dashbord.Data;
using System.Security.Principal;

namespace dashbord.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _dbContext;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var docCount = _dbContext.Doctor.Count()*100;
        var name = User?.Identity?.Name!;
        ViewBag.UserName = name;
        ViewBag.Users = _dbContext.Users.Count()*100;
        ViewBag.Clinc = _dbContext.clinicTable.Count() * 100;
        ViewBag.DocCount = docCount;
        return View();
    }

    //public IActionResult Clinics()
    //{
    //    return View();
    //}

    public IActionResult Patients()
    {
        return View();
    }
    
    public IActionResult medicalInfo()
    {
        return View();
    }

    //public IActionResult Doctors()
    //{
    //    return View();
    //}
    
    public IActionResult MyPatients()
    {
        return View();
    }
    public IActionResult Medicines()
    {
        return View();
    }

    public IActionResult Settings()
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

