using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.ViewModels;
using hospitals.Utilities;

namespace Hospital.Services;

public class ApplicationUserService : IApplicationUserService
{
    private IUnitOfWork _unitOfWork;

    public ApplicationUserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public PagedResult<ApplicationUserViewModel> GetAll(int PageNumber, int PageSize)
    {
        var vm = new ApplicationUserViewModel();
        int totalCount;
        List<ApplicationUserViewModel> vmList = new List<ApplicationUserViewModel>();

        try
        {
            int ExcludeCount = (PageSize * PageNumber) - PageSize;

            var modelList = _unitOfWork.GenericRepository<ApplicationUser>().GetAll()
                .Skip(ExcludeCount)
                .Take(PageSize)
                .ToList();

            totalCount = _unitOfWork.GenericRepository<ApplicationUser>().GetAll().Count();
            vmList = ConvertModelToViewModelList(modelList);

        }
        catch (Exception)
        {
            throw;
        }

        var result = new PagedResult<ApplicationUserViewModel>
        {
            Data = vmList,
            TotalItems = totalCount,
            PageNumber = PageNumber,
            PageSize = PageSize
        };
        return result;
    }

    public PagedResult<ApplicationUserViewModel> GetAllDoctor(int PageNumber, int PageSize)
    {
        var vm = new ApplicationUserViewModel();
        int totalCount;
        List<ApplicationUserViewModel> vmList = new List<ApplicationUserViewModel>();
        try
        {
            int ExcludeCount = (PageSize * PageNumber) - PageSize;
            var modelList = _unitOfWork.GenericRepository<ApplicationUser>()
                .GetAll()
                .Where(x => x.IsDoctor)
                .Skip(ExcludeCount)
                .Take(PageSize)
                .ToList();
            totalCount = _unitOfWork.GenericRepository<ApplicationUser>()
                .GetAll(x => x.IsDoctor == true)
                .ToList()
                .Count();
            vmList = ConvertModelToViewModelList(modelList);
        }
        catch (Exception)
        {
            throw;
        }

        var result = new PagedResult<ApplicationUserViewModel>
        {
            Data = vmList,
            TotalItems = totalCount,
            PageNumber = PageNumber,
            PageSize = PageSize
        };
        return result;
    }

    public PagedResult<ApplicationUserViewModel> GetAllPatient(int PageNumber, int PageSize)
    {
        throw new NotImplementedException();
    }

    public PagedResult<ApplicationUserViewModel> SearchDoctor(int PageNumber, int PageSize, string Spicility = null)
    {
        throw new NotImplementedException();
    }


    private List<ApplicationUserViewModel> ConvertModelToViewModelList(List<ApplicationUser> modelList)
    {
        return modelList.Select(x => new ApplicationUserViewModel(x)).ToList();
    }

}
