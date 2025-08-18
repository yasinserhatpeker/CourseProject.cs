namespace efCore.Controllers;

using System.Data;
using efCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class CourseRegisterController : Controller
{
    private readonly DataContext _context;

    public CourseRegisterController(DataContext context)
    {
        _context = context;
    }

    


}