using Core.Domain.Entities;
using Infrastructure.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.ContactService
{
    public class FindContact
    {

        private readonly DataContext _context;

        public FindContact(DataContext context)
        {
            _context = context;
        }
        public async Task<Contact> GetContactById(Guid Id)
        {
            return await _context.Contacts.Where(c => c.Id == Id).FirstOrDefaultAsync();
        }
    }
}