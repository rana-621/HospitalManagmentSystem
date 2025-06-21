using Hospital.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Controllers
{
    public class HospitalController : Controller
    {

        private IHospitalInfo _hospitalInfo;
        public HospitalController(IHospitalInfo hospitalInfo)
        {
            _hospitalInfo = hospitalInfo;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 1)
        {
            return View(_hospitalInfo.GetAll(pageNumber, pageSize));
        }

    }
}
