using Application.Services.ContactService;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ContactsController : BaseApiController
    {
        private readonly UploadCsvFile _uploadCsv;
        private readonly GetContactsList _getContactsList;

        public ContactsController(UploadCsvFile uploadCsv, GetContactsList getContactsList)
        {
            _uploadCsv = uploadCsv;
            _getContactsList = getContactsList;
        }
        [HttpPost]
        public async Task<int> CsvUpload(IFormFile file)
        {
            return await _uploadCsv.AddContactsFromCsvAsync(file);
        }
        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetContacts()
        {
            return await _getContactsList.GetContactsListFromDatabase();
        }
    }
}