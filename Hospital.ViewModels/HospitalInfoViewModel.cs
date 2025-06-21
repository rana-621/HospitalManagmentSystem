

using Hospital.Models;

namespace Hospital.ViewModels;

public class HospitalInfoViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;

    public string PinCode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;

    public HospitalInfoViewModel()
    {

    }
    public HospitalInfoViewModel(HospitalInfo model)
    {
        Id = model.Id;
        Name = model.Name;
        Type = model.Type;
        City = model.City;
        PinCode = model.PinCode;
        Country = model.Country;

    }
    public HospitalInfo ConvertViewModel(HospitalInfoViewModel model)
    {
        return new HospitalInfo
        {
            Id = model.Id,
            Name = model.Name,
            Type = model.Type,
            City = model.City,
            PinCode = model.PinCode,
            Country = model.Country,
        };

    }
}
