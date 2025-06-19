using Microsoft.AspNetCore.Identity;

namespace Hospital.Models;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; }
    public Gender Gender { get; set; }
    public string Nationality { get; set; }
    public string Address { get; set; }
    public DateTime DOF { get; set; }
    public string Specialist { get; set; }
    public Department Department { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<Payroll> Payrolls { get; set; }


}

public enum Gender
{
    Male, Female
}