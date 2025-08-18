namespace efCore.Controllers;

using System.Data;
using efCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class CourseRegisterController : Controller
{
    private readonly DataContext _context;

    public CourseRegisterController(DataContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> List()
    {
        var courseRegisters = await _context.CourseRegisters.Include(x=>x.Student).Include(x=>x.Course).ToListAsync();
        return View(courseRegisters);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Students = new SelectList(await _context.Students.ToListAsync(), "StudentId", "NameSurname");
        ViewBag.Courses = new SelectList(await _context.Courses.ToListAsync(), "CourseId", "CourseName");

        return View();

    }

    [HttpPost]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult> Create(CourseRegister model)
    {
        model.RegisterTime = DateTime.Now;
        _context.CourseRegisters.Add(model);
        await _context.SaveChangesAsync();

        return RedirectToAction("List");

    }    
    





}