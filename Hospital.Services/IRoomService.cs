using Hospital.ViewModels;
using hospitals.Utilities;

namespace Hospital.Services;

public interface IRoomService
{
    PagedResult<RoomViewModel> GetAll(int pageNumber, int pageSize);
    RoomViewModel GetRoomById(int RoomId);
    void UpdateRoom(RoomViewModel roomViewModel);
    void InsertRoom(RoomViewModel roomViewModel);
    void DeleteRoom(int id);
}
