using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.ViewModels;
using hospitals.Utilities;

namespace Hospital.Services;

public class DoctorService : IDoctorService
{

    public IUnitOfWork _unitOfWork;
    public DoctorService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void AddTiming(TimingViewModel timing)
    {
        var model = new TimingViewModel().ConvertViewModel(timing);
        _unitOfWork.GenericRepository<Timing>().Add(model);
        _unitOfWork.Save();
    }

    public void DeleteTiming(int TimingId)
    {
        var model = _unitOfWork.GenericRepository<Timing>().GetById(TimingId);
        _unitOfWork.GenericRepository<Timing>().Delete(model);
        _unitOfWork.Save();
    }

    public PagedResult<TimingViewModel> GetAll(int pageNumber, int pageSize)
    {
        var vm = new TimingViewModel();
        int totalCount;
        List<TimingViewModel> vmList = new List<TimingViewModel>();
        try
        {
            int ExcludeCount = (pageSize * pageNumber) - pageSize;
            var modelList = _unitOfWork.GenericRepository<Timing>()
                .GetAll()
                .Skip(ExcludeCount)
                .Take(pageSize)
                .ToList();

            totalCount = _unitOfWork.GenericRepository<Timing>().GetAll().Count();
            vmList = ConvertModelToViewModelList(modelList);
        }
        catch (Exception)
        {
            throw;
        }
        var result = new PagedResult<TimingViewModel>
        {
            Data = vmList,
            TotalItems = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        return result;
    }



    public IEnumerable<TimingViewModel> GetAll()
    {

        var TimingList = _unitOfWork.GenericRepository<Timing>().GetAll().ToList();
        var vmList = ConvertModelToViewModelList(TimingList);
        return vmList;
    }

    public TimingViewModel GetTimingById(int TimingId)
    {
        var model = _unitOfWork.GenericRepository<Timing>().GetById(TimingId);

        var vm = new TimingViewModel(model);
        return vm;
    }

    public void UpdateTiming(TimingViewModel timing)
    {
        var model = new TimingViewModel().ConvertViewModel(timing);
        var ModelById = _unitOfWork.GenericRepository<Timing>().GetById(model.Id);
        ModelById.Id = model.Id;
        ModelById.DoctorId = model.DoctorId;
        ModelById.MorningShiftStartTime = model.MorningShiftStartTime;
        ModelById.MorningShiftEndTime = model.MorningShiftEndTime;
        ModelById.AfternoonShiftStartTime = model.AfternoonShiftStartTime;
        ModelById.AfternoonShiftEndTime = model.AfternoonShiftEndTime;
        ModelById.Duration = model.Duration;
        ModelById.Status = model.Status;

        _unitOfWork.GenericRepository<Timing>().Update(model);
        _unitOfWork.Save();

    }

    private List<TimingViewModel> ConvertModelToViewModelList(List<Timing> modelList)
    {
        return modelList.Select(model => new TimingViewModel(model)).ToList();

    }
}
