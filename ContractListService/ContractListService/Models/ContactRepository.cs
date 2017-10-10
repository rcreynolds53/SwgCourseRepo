using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContractListService.Models
{
    public class ContactRepository
    {
        private static List<Contact> _contacts;
        static ContactRepository()
        {
            _contacts = new List<Contact>()
            {
                new Contact {FirstName = "John", LastName="Doe", Company="Oracle", Email="jd@oracle.com", Phone="111-111-1111" },
                new Contact {FirstName="Salley", LastName="Smith", Company="Microsoft", Email="ss@ms.com", Phone = "222-222-2222"}
            };
        }
        public static Contact GetContact(int id)
        {
            return  _contacts.FirstOrDefault(c => c.ContactId == id);
            
        }

        public static List<Contact> GetAll()
        {
            return _contacts;
        }

        public static void Add(Contact newContact)
        {
            if(_contacts.Any())
            {
                newContact.ContactId = _contacts.Max(c => c.ContactId) + 1;
            }
            else
            {
                newContact.ContactId = 0;
            }

            _contacts.Add(newContact);
        }

        public static void Update(Contact updatedContact)
        {
            _contacts.RemoveAll(c => c.ContactId == updatedContact.ContactId);
            _contacts.Add(updatedContact);

        }

        public static void Delete(int contactId)
        {
            _contacts.RemoveAll(c => c.ContactId == contactId);
        }
    }
}