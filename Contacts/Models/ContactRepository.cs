

using CommunityToolkit.Maui.Core.Extensions;
using System.Collections.ObjectModel;

namespace Contacts.Models
{
    public static class ContactRepository
    {
        public static List<Contact> _contacts = new List<Models.Contact>() {
            new Models.Contact{ ContactId = 1, Name = "John Doe" , Email = "johndoe@gmail.com", PhoneNumber = "51999999999", Adress = "Rua banana"},
            new Models.Contact{ ContactId = 2, Name = "Marcelo" , Email = "marcelo@gmail.com", PhoneNumber = "51999999993", Adress = "Rua abacaxi"},
            new Models.Contact{ ContactId = 3, Name = "Maria" , Email = "maria@gmail.com", PhoneNumber = "51999999991", Adress = "Rua maça"},
            new Models.Contact{ ContactId = 4, Name = "João" , Email = "joao@gmail.com", PhoneNumber = "51999999992", Adress = "Rua batata"},
        };

        public static List<Contact> GetContacts() => _contacts;

        public static Contact GetContactById(int id)
        {
            var contact = _contacts.FirstOrDefault(e => e.ContactId == id);

            if (contact is not null)
            {
                return new Contact
                {
                    ContactId = contact.ContactId,
                    Name = contact.Name,
                    Email = contact.Email,
                    PhoneNumber = contact.PhoneNumber,
                    Adress = contact.Adress,
                };
            }

            return contact;
        }
        public static void UpdateContact(int contactId, Contact contact)
        {
            if (contactId != contact.ContactId) return;

            var contactToUpdate = _contacts.FirstOrDefault(e => e.ContactId == contactId);

            if (contactToUpdate is not null)
            {
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.PhoneNumber = contact.PhoneNumber;
                contactToUpdate.Adress = contact.Adress;
            }
        }

        public static void AddContact(Contact contact)
        {
            var maxId = _contacts.Max(e => e.ContactId);
            contact.ContactId = maxId + 1;
            _contacts.Add(contact);
        }

        internal static void DeleteContact(int contactId)
        {
            Contact contact = _contacts.FirstOrDefault(e => e.ContactId == contactId);
            _contacts.Remove(contact);
        }

        internal static ObservableCollection<Contact> SearchContacts(string text)
        {
            var contacts = new List<Contact>();

            if (string.IsNullOrEmpty(text))
                return _contacts.ToObservableCollection();
            else
            if(contacts is null || contacts.Count() <= 0)
                contacts = _contacts.Where(e => e.Name.ToLower().Contains(text.ToLower())).ToList();
            if (contacts is null || contacts.Count() <= 0)
                contacts = _contacts.Where(e => e.Email.ToLower().Contains(text)).ToList();
            if (contacts is null || contacts.Count() <= 0)
                contacts = _contacts.Where(e => e.PhoneNumber.ToLower().Contains(text)).ToList();
            if (contacts is null || contacts.Count() <= 0)
                contacts = _contacts.Where(e => e.Adress.ToLower().Contains(text)).ToList();

            return contacts.ToObservableCollection();
        }
    }
}
