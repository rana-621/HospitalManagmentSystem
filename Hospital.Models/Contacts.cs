namespace Hospital.Models;

public class Contacts
{
    public int Id { get; set; }
    public string HospitalId { get; set; }
    public HospitalInfo Hospital { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}