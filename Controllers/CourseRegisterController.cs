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
        var courseRegisters = await _context.CourseRegisters.Include(x => x.Student).Include(x => x.Course).ToListAsync();
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

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var courseRegister = await _context.CourseRegisters.FindAsync(id);
        if (courseRegister == null)
        {
            return NotFound();
        }
        return View(courseRegister);
    }

    [HttpPost]

    public async Task<IActionResult> Delete(int? id, CourseRegister model)
    {
        if (id != model.CourseId)
        {
            return NotFound();
        }
        var courseRegister = await _context.CourseRegisters.FindAsync(id);
        if (courseRegister == null)
        {
            return NotFound();
        }
        _context.CourseRegisters.Remove(courseRegister);
        await _context.SaveChangesAsync();

        return RedirectToAction("List");

    }

    





}