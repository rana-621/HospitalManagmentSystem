using Hospital.Models;

namespace Hospital.ViewModels;

public class RoomViewModel
{
    public int Id { get; set; }
    public string RoomNumber { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public string HospitalInfoId { get; set; }

    public RoomViewModel()
    {
    }
    public RoomViewModel(Room model)
    {
        Id = model.Id;
        RoomNumber = model.RoomNumber;
        Type = model.Type;
        Status = model.Status;
        HospitalInfoId = model.HospitalId;
    }

    public Room ConvertViewModel(RoomViewModel model)
    {
        return new Room
        {
            Id = model.Id,
            RoomNumber = model.RoomNumber,
            Type = model.Type,
            Status = model.Status,
            HospitalId = model.HospitalInfoId
        };
    }
}
