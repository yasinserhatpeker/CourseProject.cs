using System.ComponentModel.DataAnnotations;

namespace efCore.Data;

public class Student
{
    [Key]
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public string? StudentSurname { get; set; }

    public string NameSurname
    {
        get
        {
            return this.StudentName + " " + this.StudentSurname;
        }
    }
    public string? StudentEmail { get; set; }

    public string? StudentPhone { get; set; }
    
    public ICollection<CourseRegister> CourseRegisters { get; set; } = new List<CourseRegister>();
    

}