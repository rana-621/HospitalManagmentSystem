namespace Hospital.Models;

public class Hospital
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;

    public string PinCode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public ICollection<Room> Rooms { get; set; }
    public ICollection<Contacts> Contacts { get; set; }

}
