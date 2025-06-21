using Hospital.Models;

namespace Hospital.ViewModels;

public class ContactViewModel
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int HospitalInfoId { get; set; }

    public ContactViewModel()
    {

    }

    public ContactViewModel(Contacts model)
    {
        Id = model.Id;
        Email = model.Email;
        Phone = model.Phone;
        HospitalInfoId = model.HospitalId;
    }

    public Contacts ConvertViewModel(ContactViewModel model)
    {
        return new Contacts
        {
            Id = model.Id,
            Email = model.Email,
            Phone = model.Phone,
            HospitalId = model.HospitalInfoId,
        };

    }
}
