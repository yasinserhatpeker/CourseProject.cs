namespace efCore.Controllers;
using efCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class StudentController : Controller
{
    private readonly DataContext _context;
    public StudentController(DataContext context)
    {
        _context = context;

    }
    public async Task<IActionResult> List()
    {
        return View(await _context.Students.ToListAsync());
    }

    [HttpGet]

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Student model)
    {
        _context.Students.Add(model);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index", "Home");

    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var student = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == id);

        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }

    

}