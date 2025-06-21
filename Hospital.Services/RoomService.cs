using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.ViewModels;
using hospitals.Utilities;

namespace Hospital.Services;

public class RoomService : IRoomService
{

    private readonly IUnitOfWork _unitOfWork;
    public RoomService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void DeleteRoom(int id)
    {
        var model = _unitOfWork.GenericRepository<Room>().GetById(id);
        _unitOfWork.GenericRepository<Room>().Delete(model);
        _unitOfWork.Save();
    }

    public PagedResult<RoomViewModel> GetAll(int pageNumber, int pageSize)
    {
        var vm = new RoomViewModel();
        int totalCount;
        List<RoomViewModel> vmList = new();
        try
        {
            int ExcludedRecords = (pageSize * pageNumber) - pageSize;

            var modelList = _unitOfWork.GenericRepository<Room>().GetAll().Skip(ExcludedRecords).Take(pageSize).ToList();

            totalCount = _unitOfWork.GenericRepository<Room>().GetAll().Count();

            vmList = ConvertModelToViewModelList(modelList);

        }
        catch (Exception)
        {
            throw;
        }

        var result = new PagedResult<RoomViewModel>
        {
            Data = vmList,
            TotalItems = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        return result;
    }



    public RoomViewModel GetRoomById(int RoomId)
    {
        var model = _unitOfWork.GenericRepository<Room>().GetById(RoomId);
        var vm = new RoomViewModel(model);
        return vm;
    }

    public void InsertRoom(RoomViewModel roomViewModel)
    {
        var model = new RoomViewModel().ConvertViewModel(roomViewModel);
        _unitOfWork.GenericRepository<Room>().Add(model);
        _unitOfWork.Save();
    }

    public void UpdateRoom(RoomViewModel Room)
    {
        var model = new RoomViewModel().ConvertViewModel(Room);
        var modelById = _unitOfWork.GenericRepository<Room>().GetById(model.Id);
        modelById.RoomNumber = Room.RoomNumber;
        modelById.Type = Room.Type;
        modelById.Status = Room.Status;
        modelById.HospitalId = Room.HospitalInfoId;

        _unitOfWork.GenericRepository<Room>().Update(modelById);
        _unitOfWork.Save();
    }
    private List<RoomViewModel> ConvertModelToViewModelList(List<Room> modelList)
    {
        return modelList.Select(x => new RoomViewModel(x)).ToList();
    }
}
