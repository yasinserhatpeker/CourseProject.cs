namespace efCore.Controllers;

using System.Data;
using efCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class CourseController : Controller
{
    private readonly DataContext _context;

    public CourseController(DataContext context)
    {
        _context = context;
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Course model)
    {
        _context.Courses.Add(model);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> List()
    {
        var courses = await _context.Courses.ToListAsync();
        return View(courses);
    }


    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == id);
        if (course == null)
        {
            return NotFound();
        }
        return View(course);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Course model, int id)
    {
        if (id != model.CourseId)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(model);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Courses.Any(course => course.CourseId == model.CourseId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("List");
        }
        return View(model);

    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var course = await _context.Courses.FindAsync(id);
        if (course == null)
        {
            return NotFound();
        }
        return View(course);


    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id, Course model)
    {
        if (id != model.CourseId)
        {
            return NotFound();
        }
        var course = await _context.Courses.FindAsync(id);
        if (course == null)
        {
            return NotFound();
        }
        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();
         
         return RedirectToAction("List");
    }

}


    
   


