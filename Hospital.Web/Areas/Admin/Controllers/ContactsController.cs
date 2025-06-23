using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers;

[Area("admin")]
public class ContactsController : Controller
{
    private IContactService _contact;
    private IHospitalInfo _hospitalInfo;

    public ContactsController(IContactService contact, IHospitalInfo hospitalInfo)
    {
        _contact = contact;
        _hospitalInfo = hospitalInfo;
    }
    public IActionResult Index(int pageNumber = 1, int pageSize = 10)
    {
        return View(_contact.GetAll(pageNumber, pageSize));
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(ContactViewModel contactViewModel)
    {

        _contact.InsertContact(contactViewModel);
        return RedirectToAction("Index");

    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        //ViewBag.hopital = new SelectList(_hospitalInfo.GetAll(), "Id", "Name");
        //var viewModel = _contact.GetContactById(id);

        //return View(viewModel);

        var contact = _contact.GetContactById(id);

        return View(contact);
    }
    [HttpPost]
    public IActionResult Edit(ContactViewModel contactViewModel)
    {

        _contact.UpdateContact(contactViewModel);
        return RedirectToAction("Index");

    }

    public IActionResult Delete(int id)
    {
        _contact.DeleteContact(id);
        return RedirectToAction("Index");

    }
}