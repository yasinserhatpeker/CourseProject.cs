namespace efCore.Controllers;

using System.Data;
using efCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class TutorController : Controller
{

    private readonly DataContext _context;

    public TutorController(DataContext dataContext)
    {
        _context = dataContext;
    }


    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Tutor model)
    {
        _context.Tutors.Add(model);
        await _context.SaveChangesAsync();
        return View("Index", "Home");
    }

    public async Task<IActionResult> List()
    {
        return View(await _context.Tutors.ToListAsync());
    }
    
    




}