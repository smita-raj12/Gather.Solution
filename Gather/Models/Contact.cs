using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Gather.Models
{
  public class Contact
  {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }

    public static List<Contact> GetAll()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Contact> ContactsList = JsonConvert.DeserializeObject<List<Contact>>(jsonResponse.ToString());

      return ContactsList;
    }

    public static List<Contact> SearchContact(string companyName, string  location)
    {
      var apiCallTask = ApiHelper.SearchContact(companyName, location);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Contact> ContactsList = JsonConvert.DeserializeObject<List<Contact>>(jsonResponse.ToString());

      return ContactsList;
    }
    public static Contact GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Contact Contact = JsonConvert.DeserializeObject<Contact>(jsonResponse.ToString());

      return Contact;
    }
    public static void Post(Contact Contact)
    {
      string jsonContact = JsonConvert.SerializeObject(Contact);
      var apiCallTask = ApiHelper.Post(jsonContact);
    }
    public static void Put(Contact Contact)
    {
      string jsonContact = JsonConvert.SerializeObject(Contact);
      var apiCallTask = ApiHelper.Put(Contact.ContactId, jsonContact);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
  }
}