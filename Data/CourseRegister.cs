using System.ComponentModel.DataAnnotations;

namespace efCore.Data;

public class CourseApply
{
    [Key]
    public int RegisterId { get; set; }
    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public DateTime RegisterTime { get; set; }

}