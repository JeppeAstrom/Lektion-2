

using WebApi.Models;
using WebApi.Models.Entities;

namespace _01_ASPNetMVC.Services
{
    public class ContactService
    {
        private readonly DataContext _context;

        public ContactService(DataContext context)
        {
            _context = context;
        }

        public void AddContact(ContactEntity model)
        {
            var contact = new ContactEntityModel
            {
                Name = model.Name,
                Email = model.Email,
                Comment = model.Comment
            };

            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }
    }
}
