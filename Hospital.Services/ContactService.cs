using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.ViewModels;
using hospitals.Utilities;

namespace Hospital.Services;

public class ContactService : IContactService
{

    private readonly IUnitOfWork _unitOfWork;
    public ContactService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public void DeleteContact(int id)
    {
        var model = _unitOfWork.GenericRepository<Contacts>().GetById(id);
        _unitOfWork.GenericRepository<Contacts>().Delete(model);
        _unitOfWork.Save();

    }

    public PagedResult<ContactViewModel> GetAll(int pageNumber, int pageSize)
    {
        var vm = new ContactViewModel();
        int totalCount;
        List<ContactViewModel> vmList = new List<ContactViewModel>();

        try
        {
            int ExcludeRecordes = (pageSize * pageNumber) - pageSize;

            var modelList = _unitOfWork.GenericRepository<Contacts>()
                .GetAll()
                .Skip(ExcludeRecordes)
                .Take(pageSize)
                .ToList();

            totalCount = _unitOfWork.GenericRepository<Contacts>().GetAll().Count();

            vmList = ConvertModelToViewModelList(modelList);
        }
        catch (Exception)
        {
            throw;
        }
        var result = new PagedResult<ContactViewModel>
        {
            Data = vmList,
            TotalItems = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        return result;
    }

    public ContactViewModel GetContactById(int id)
    {
        var model = _unitOfWork.GenericRepository<Contacts>().GetById(id);
        var vm = new ContactViewModel(model);
        return vm;
    }

    public void InsertContact(ContactViewModel contactViewModel)
    {
        var model = new ContactViewModel().ConvertViewModel(contactViewModel);
        _unitOfWork.GenericRepository<Contacts>().Add(model);
        _unitOfWork.Save();
    }

    public void UpdateContact(ContactViewModel contactViewModel)
    {
        var model = new ContactViewModel().ConvertViewModel(contactViewModel);
        var ModelById = _unitOfWork.GenericRepository<Contacts>().GetById(model.Id);
        ModelById.Phone = contactViewModel.Phone;
        ModelById.Email = contactViewModel.Email;
        ModelById.HospitalId = contactViewModel.HospitalInfoId;

        _unitOfWork.GenericRepository<Contacts>().Update(ModelById);
        _unitOfWork.Save();
    }

    private List<ContactViewModel> ConvertModelToViewModelList(List<Contacts> modelList)
    {
        return modelList.Select(model => new ContactViewModel(model)).ToList();
    }

}
