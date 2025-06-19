namespace Hospital.Models;

public class Medicine
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public decimal Cost { get; set; }
    public string Description { get; set; } = string.Empty;
    public ICollection<MedicineReport> MedicineReports { get; set; }
    public ICollection<PrescribedMedicine> PrescribedMedicines { get; set; }

}
