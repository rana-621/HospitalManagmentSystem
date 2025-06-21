using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.ViewModels;
using hospitals.Utilities;

namespace Hospital.Services;

public class HospitalInfoService : IHospitalInfo
{
    private IUnitOfWork _unitOfWork;
    public HospitalInfoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void DeleteHospitalInfo(int id)
    {
        var model = _unitOfWork.GenericRepository<HospitalInfo>().GetById(id);
        _unitOfWork.GenericRepository<HospitalInfo>().Delete(model);
        _unitOfWork.Save();
    }

    public PagedResult<HospitalInfoViewModel> GetAll(int pageNumber, int pageSize)
    {
        var vm = new HospitalInfoViewModel();
        int totalCount;

        List<HospitalInfoViewModel> vmList = new List<HospitalInfoViewModel>();
        try
        {
            int ExcludedRecords = (pageSize * pageNumber) - pageSize;

            var modelList = _unitOfWork.GenericRepository<HospitalInfo>().GetAll().Skip(ExcludedRecords).Take(pageSize).ToList();
            totalCount = _unitOfWork.GenericRepository<HospitalInfo>().GetAll().ToList().Count();

            vmList = ConvertModelToViewModelList(modelList);
        }
        catch (Exception ex)
        {
            throw;
        }
        var result = new PagedResult<HospitalInfoViewModel>
        {
            Data = vmList,
            TotalItems = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        return result;
    }

    public HospitalInfoViewModel GetHospitalById(int id)
    {
        var model = _unitOfWork.GenericRepository<HospitalInfo>().GetById(id);
        var vm = new HospitalInfoViewModel(model);
        return vm;
    }

    public void IsertHospitalInfo(HospitalInfoViewModel hospitalInfo)
    {
        var model = new HospitalInfoViewModel().ConvertViewModel(hospitalInfo);
        _unitOfWork.GenericRepository<HospitalInfo>().Add(model);
        _unitOfWork.Save();
    }

    public void UpdateHopitalInfo(HospitalInfoViewModel hospitalInfo)
    {
        var model = new HospitalInfoViewModel().ConvertViewModel(hospitalInfo);
        var modelById = _unitOfWork.GenericRepository<HospitalInfo>().GetById(model.Id);
        modelById.Name = model.Name;
        modelById.City = model.City;
        modelById.PinCode = model.PinCode;
        modelById.Country = model.Country;
        _unitOfWork.GenericRepository<HospitalInfo>().Update(model);
        _unitOfWork.Save();
    }

    private List<HospitalInfoViewModel> ConvertModelToViewModelList(List<HospitalInfo> modelList)
    {
        return modelList.Select(x => new HospitalInfoViewModel(x)).ToList();
    }
}

