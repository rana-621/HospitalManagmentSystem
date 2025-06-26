using Hospital.Models;
using Hospital.ViewModels.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.ViewModels;

public class TimingViewModel
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

    //List<TimeSelectList> morningShiftStart = new List<SelectListItem>();
    //List<SelectListItem> morningShiftEnd = new List<SelectListItem>();
    //List<SelectListItem> afternoonShiftStart = new List<SelectListItem>();
    //List<SelectListItem> afternoonShiftEnd = new List<SelectListItem>();

    public List<SelectListItem> MorningShiftStart => TimeSelectListHelper.GetMorningShiftStartTimes();
    public List<SelectListItem> MorningShiftEnd => TimeSelectListHelper.GetMorningShiftEndTimes();
    public List<SelectListItem> AfternoonShiftStart => TimeSelectListHelper.GetAfternoonShiftStartTimes();
    public List<SelectListItem> AfternoonShiftEnd => TimeSelectListHelper.GetAfternoonShiftEndTimes();



    public TimingViewModel()
    {

    }
    public TimingViewModel(Timing model)
    {
        Id = model.Id;
        Date = model.Date;
        MorningShiftStartTime = model.MorningShiftStartTime;
        MorningShiftEndTime = model.MorningShiftEndTime;
        AfternoonShiftStartTime = model.AfternoonShiftStartTime;
        AfternoonShiftEndTime = model.AfternoonShiftEndTime;
        Duration = model.Duration;
        Status = model.Status;
        DoctorId = model.DoctorId;

    }

    public Timing ConvertViewModel(TimingViewModel model)
    {
        return new Timing
        {
            Id = model.Id,
            Date = model.Date,
            MorningShiftStartTime = model.MorningShiftStartTime,
            MorningShiftEndTime = model.MorningShiftEndTime,
            AfternoonShiftStartTime = model.AfternoonShiftStartTime,
            AfternoonShiftEndTime = model.AfternoonShiftEndTime,
            Duration = model.Duration,
            Status = model.Status,
            DoctorId = model.DoctorId
        };
    }

}
