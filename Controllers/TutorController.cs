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
        
        return View(model);
    }

    public async Task<IActionResult> List()
    {
        return View(await _context.Tutors.ToListAsync());
    }


    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var tutor = await _context.Tutors.FirstOrDefaultAsync(x => x.TutorId == id);
        if (tutor == null)
        {
            return NotFound();
        }
        return View(tutor);
    }

    [HttpPost]
    [IgnoreAntiforgeryToken]

    public async Task<IActionResult> Edit(int id, Tutor model)
    {
        if (id != model.TutorId)
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
            catch (DBConcurrencyException)
            {
                if (!_context.Tutors.Any(tutor => tutor.TutorId == model.TutorId))
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
        var tutor = await _context.Tutors.FindAsync(id);
        if (tutor == null)
        {
            return NotFound();
        }
        return View(tutor);
    }
    [HttpPost]
   [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int? id, Tutor model)
    {
        if (id != model.TutorId)
        {
            return NotFound();
        }

        var tutor = await _context.Tutors.FindAsync(id);
        if (tutor == null)
        {
            return NotFound();
        }
        _context.Tutors.Remove(tutor);
        await _context.SaveChangesAsync();

        return RedirectToAction("List");
    }


}