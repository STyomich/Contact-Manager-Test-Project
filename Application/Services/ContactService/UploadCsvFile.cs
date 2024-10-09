using System.Globalization;
using Core.Domain.Entities;
using CsvHelper;
using CsvHelper.Configuration;
using Infrastructure.DataBaseContext;
using Microsoft.AspNetCore.Http;

namespace Application.Services.ContactService
{
    public class UploadCsvFile
    {
        private readonly DataContext _context;

        public UploadCsvFile(DataContext context)
        {
            _context = context;
        }

       public async Task<int> AddContactsFromCsvAsync(IFormFile file)
{
    var contacts = new List<Contact>();

    using (var stream = new StreamReader(file.OpenReadStream()))
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null, // Disable header validation
                MissingFieldFound = null // Ignore missing fields
            };
        using (var csv = new CsvReader(stream, config))
        {
            var records = csv.GetRecords<Contact>().ToList();
            foreach (var record in records)
            {
                var contact = new Contact
                {
                    Id = Guid.NewGuid(),
                    Name = record.Name,
                    DateOfBirth = record.DateOfBirth,
                    Married = record.Married,
                    Phone = record.Phone,
                    Salary = record.Salary
                };
                contacts.Add(contact);
            }
        }
    }

    await _context.Contacts.AddRangeAsync(contacts);
    await _context.SaveChangesAsync();

    return contacts.Count;
}

    }
}