using Core.Domain.Entities;
using Infrastructure.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.ContactService
{
    public class GetContactsList
    {
        private readonly DataContext _context;

        public GetContactsList(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Contact>> GetContactsListFromDatabase()
        {
            return await _context.Contacts.ToListAsync();
        }
    }
}