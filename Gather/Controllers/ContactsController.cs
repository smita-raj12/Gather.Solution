using Microsoft.AspNetCore.Mvc;
using Gather.Models;

namespace Gather.Controllers
{

  public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            //var allContacts = Contact.GetAll();
            return View();
        }
       
        public IActionResult Search(string companyName, string location)
        {
                var searchContacts = Contact.SearchContact(companyName, location);
                return View(searchContacts);
        }
        public IActionResult Details(int id)
        {
            Contact Contact = Contact.GetDetails(id);
            return View(Contact);

        }
        public ActionResult Create()
        {
          return View();
        }

        [HttpPost]
        public ActionResult Create(Contact Contact)
        {
            Contact.Post(Contact);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var contact = Contact.GetDetails(id);
            return View(contact);    
        }
        [HttpPost]
        public IActionResult Edit(int id, Contact Contact)
        {
           Contact.ContactId = id;
           Contact.Put(Contact);
           return RedirectToAction("Index", id);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Contact.Delete(id);
            return RedirectToAction("Index");
        }
    }
}