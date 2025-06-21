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

        public IActionResult Index()
        {
            return View();
        }
    }
}
