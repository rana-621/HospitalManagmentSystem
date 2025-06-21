using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Controllers
{
    public class HospitalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
