using System.ComponentModel.DataAnnotations;

namespace efCore.Data;

public class Course
{
    [Key]
    public int CourseId { get; set; }
    public string? CourseName { get; set; }
    public ICollection<CourseRegister> CourseRegisters { get; set; } = new List<CourseRegister>();
    
    public int? TutorId { get; set; }
    public Tutor Tutor { get; set; } = null!;
    

}