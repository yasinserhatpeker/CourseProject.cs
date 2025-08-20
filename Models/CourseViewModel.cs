using System.ComponentModel.DataAnnotations;

namespace efCore.Data;

public class CourseViewModel
{
    [Key]
    public int CourseId { get; set; }
    public string? CourseName { get; set; }

    public int? TutorId { get; set; }
    public ICollection<CourseRegister> CourseRegisters { get; set; } = new List<CourseRegister>();
    
    

}