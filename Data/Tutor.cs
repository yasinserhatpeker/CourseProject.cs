using System.ComponentModel.DataAnnotations;

namespace efCore.Data;

public class Tutor()
{
    [Key]
    public int TutorId { get; set; }

    public string? TutorName { get; set; }

    public string? TutorSurname { get; set; }

    public string? TutorEmail { get; set; }

    public string? TutorPhone { get; set; }

    public DateTime StartTime { get; set; }
    
}