using System.ComponentModel.DataAnnotations;

namespace efCore.Data;

public class Course
{
    [Key]
    public int CourseId { get; set; }

    public string? CourseName { get; set; }
    

}