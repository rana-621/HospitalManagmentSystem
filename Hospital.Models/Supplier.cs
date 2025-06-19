namespace Hospital.Models;

public class Supplier
{
    public int Id { get; set; }
    public string Company { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public ICollection<MedicineReport> MedicineReports { get; set; }
}
