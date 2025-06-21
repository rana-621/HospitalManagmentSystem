using Hospital.ViewModels;
using hospitals.Utilities;

namespace Hospital.Services;

public interface IContactService
{

    PagedResult<ContactViewModel> GetAll(int pageNumber, int pageSize);

    ContactViewModel GetContactById(int id);
    void UpdateContact(ContactViewModel contactViewModel);
    void InsertContact(ContactViewModel contactViewModel);
    void DeleteContact(int id);

}
