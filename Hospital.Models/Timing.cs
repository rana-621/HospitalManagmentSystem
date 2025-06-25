namespace Hospital.Models
{

    public class Timing
    {
        public int Id { get; set; }
        public ApplicationUser DoctorId { get; set; }
        public DateTime Date { get; set; }
        public int MorningShiftStartTime { get; set; }
        public int MorningShiftEndTime { get; set; }
        public int AfternoonShiftStartTime { get; set; }
        public int AfternoonShiftEndTime { get; set; }
        public int Duration { get; set; } // Duration in minutes
        public Status Status { get; set; }
    }
}
namespace Hospital.Models
{
    public enum Status
    {
        Available,
        Pending,
        Confirmave,

    }
}