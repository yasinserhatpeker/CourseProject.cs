namespace efCore.Controllers;

using System.Data;
using efCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class CourseController : Controller
{
    private readonly DataContext _context;

    public CourseController(DataContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Tutors=new SelectList(await _context.Tutors.ToListAsync(),"TutorId","NameSurname");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CourseViewModel model)
    {

        if (ModelState.IsValid)
        {
            _context.Courses.Add(new Course()
            {

                CourseId = model.CourseId,
                CourseName = model.CourseName,
                TutorId = model.TutorId,

            });
            await _context.SaveChangesAsync();
            return RedirectToAction("List");

        }
         ViewBag.Tutors=new SelectList(await _context.Tutors.ToListAsync(),"TutorId","NameSurname");

        return View(model);
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
       var course = await _context.Courses.Include(c => c.CourseRegisters).ThenInclude(a=>a.Student).Select(c=> new CourseViewModel()
       {
           CourseId = c.CourseId,
           CourseName = c.CourseName,
           CourseRegisters = c.CourseRegisters,
           TutorId=c.TutorId,
           
          }).FirstOrDefaultAsync(x=>x.CourseId == id);
        if (course == null)
        {
            return NotFound();
        }
      ViewBag.Tutors=new SelectList(await _context.Tutors.ToListAsync(),"TutorId","NameSurname");

        return View(course);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CourseViewModel model, int id)
    {
        if (id != model.CourseId)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(new Course()
                {
                    CourseId = model.CourseId,
                    CourseName = model.CourseName,
                    TutorId=model.TutorId,
                     
                });
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
    [ValidateAntiForgeryToken]
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


    
   


