using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class RoomsController : Controller
    {
        private IRoomService _room;

        public RoomsController(IRoomService room)
        {
            _room = room;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_room.GetAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoomViewModel roomViewModel)
        {

            _room.InsertRoom(roomViewModel);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var room = _room.GetRoomById(id);

            return View(room);
        }
        [HttpPost]
        public IActionResult Edit(RoomViewModel roomViewModel)
        {

            _room.UpdateRoom(roomViewModel);
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            _room.DeleteRoom(id);
            return RedirectToAction("Index");

        }
    }
}