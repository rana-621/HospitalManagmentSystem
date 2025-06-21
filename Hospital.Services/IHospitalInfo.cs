using Hospital.ViewModels;
using hospitals.Utilities;

namespace Hospital.Services;

public interface IHospitalInfo
{
    PagedResult<HospitalInfoViewModel> GetAll(int pageNumber, int pageSize);
    HospitalInfoViewModel GetHospitalById(int id);
    void UpdateHopitalInfo(HospitalInfoViewModel model);
    void IsertHospitalInfo(HospitalInfoViewModel model);
    void DeleteHospitalInfo(int id);
}
