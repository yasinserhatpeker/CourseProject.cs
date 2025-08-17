using System.ComponentModel.DataAnnotations;

namespace efCore.Data;

public class CourseApply
{
    [Key]
    public int ApplyId { get; set; }
    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public DateTime ApplyTime { get; set; }

}