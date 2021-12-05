using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactFinder.Models;
using System;

namespace ContactFinder.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ContactsController : ControllerBase
  {
    private readonly ContactFinderContext _db;

    public ContactsController(ContactFinderContext db)
    {
      _db = db;
    }

    // GET api/Contacts
    [HttpGet]
    public ActionResult<IEnumerable<Contact>> Get(string firstName, string lastName, string email, string companyName, string location, string department)
    {
      var query = _db.Contacts.AsQueryable();

      if (firstName != null)
      {
        query = query.Where(entry => entry.FirstName == firstName);
      }
      if (lastName != null)
      {
        query = query.Where(entry => entry.LastName == lastName);
      }
      if (email != null)
      {
        query = query.Where(entry => entry.Email == email);
      }
      if (companyName != null)
      {
        query = query.Where(entry => entry.CompanyName == companyName);
      }
       if (location != null)
      {
        query = query.Where(entry => entry.Location == location);
      }
       if (department != null)
      {
        query = query.Where(entry => entry.Department == department);
      }
      return query.ToList();
    }

    // POST api/Contacts
    [HttpPost]
    public async Task<ActionResult<Contact>> Post(Contact contact)
    {
      _db.Contacts.Add(contact);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetContact), new { id = contact.ContactId }, contact);
    }
    // GET: api/Contacts/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Contact>> GetContact(int id)
    {
      var contact = await _db.Contacts.FindAsync(id);

      if (contact == null)
      {
          return NotFound();
      }

      return contact;
    }
     // PUT: api/Contact/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Contact contact)
    {
      if (id != contact.ContactId)
      {
        return BadRequest();
      }

      _db.Entry(contact).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ContactExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    private bool ContactExists(int id)
    {
      return _db.Contacts.Any(e => e.ContactId == id);
    }
    // DELETE: api/Contacts/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContact(int id)
    {
      var contact = await _db.Contacts.FindAsync(id);
      if (contact == null)
      {
        return NotFound();
      }

      _db.Contacts.Remove(contact);
      await _db.SaveChangesAsync();

      return NoContent();
    }
    //Get api/Contacts/random
    [HttpGet("random")]
    public ActionResult<Contact> Get()
    {
      int count = _db.Contacts.Count();
      int index = new Random().Next(count);
      return _db.Contacts.Skip(index).FirstOrDefault();
    } 
  }
}