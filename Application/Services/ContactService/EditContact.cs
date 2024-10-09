using Core.Domain.Entities;
using Infrastructure.DataBaseContext;

namespace Application.Services.ContactService
{
    public class EditContact
    {
        private readonly DataContext _context;

        public EditContact(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> EditExistedContact(Contact editedContact)
        {
            var contact = await _context.Contacts.FindAsync(editedContact.Id);
            if (contact == null) return false;
            contact.Name = editedContact.Name;
            contact.DateOfBirth = editedContact.DateOfBirth;
            contact.Married = editedContact.Married;
            contact.Phone = editedContact.Phone;
            contact.Salary = editedContact.Salary;
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }
    }
}