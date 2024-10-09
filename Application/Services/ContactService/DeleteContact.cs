using Core.Domain.Entities;
using Infrastructure.DataBaseContext;

namespace Application.Services.ContactService
{
    public class DeleteContact
    {
        private readonly DataContext _context;

        public DeleteContact(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteContactById(Guid Id)
        {
            var contact = await _context.Contacts.FindAsync(Id);
            if (contact == null) return false;
            _context.Remove(contact);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }
    }
}