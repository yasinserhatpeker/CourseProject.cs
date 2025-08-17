namespace efCore.Controllers;
using efCore.Data;
using Microsoft.AspNetCore.Mvc;

public class StudentController : Controller
{
    private readonly DataContext _context;
    public StudentController(DataContext context)
    {
        _context = context;

    }

    [HttpGet]

    public IActionResult Create()
    {
        return View();
    }

    
    

}