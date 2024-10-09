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
        public async Task<int> EditExistedContact(Contact contact)
        {
            Console.WriteLine("");
            return 1;
        }
    }
}