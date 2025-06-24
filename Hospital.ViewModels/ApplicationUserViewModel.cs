using Hospital.Models;

namespace Hospital.ViewModels;

public class ApplicationUserViewModel
{

    public List<ApplicationUser> Doctors { get; set; } = new List<ApplicationUser>();
    public string Name { get; set; }
    public string City { get; set; }
    public Gender Gender { get; set; }
    public bool IsDoctor { get; set; }
    public string Specilist { get; set; }

    public ApplicationUserViewModel()
    {
    }

    public ApplicationUserViewModel(ApplicationUser user)
    {
        Name = user.Name;
        City = user.City;
        Gender = user.Gender;
        IsDoctor = user.IsDoctor;
        Specilist = user.Specialist;

    }

    public ApplicationUser ConvertViewModelToModel(ApplicationUserViewModel user)
    {
        return new ApplicationUser
        {
            Name = user.Name,
            City = user.City,
            Gender = user.Gender,
            IsDoctor = user.IsDoctor,
            Specialist = user.Specilist

        };
    }
}
