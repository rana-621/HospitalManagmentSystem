using Hospital.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private IApplicationUserService _applicationUserService;

        public UsersController(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }

        public IActionResult Index(int PageNumber = 1, int PageSize = 10)
        {
            return View(_applicationUserService.GetAll(PageNumber, PageSize));
        }
    }
}
