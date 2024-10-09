using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.ContactService;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("[controller]")]
    public class DotnetContactsController : Controller
    {
        private readonly UploadCsvFile _uploadCsv;
        private readonly GetContactsList _getContactsList;
        private readonly EditContact _editContact;

        public DotnetContactsController(UploadCsvFile uploadCsv, GetContactsList getContactsList, EditContact editContact)
        {
            _uploadCsv = uploadCsv;
            _getContactsList = getContactsList;
            _editContact = editContact;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Contact> contacts = await _getContactsList.GetContactsListFromDatabase();
            return View(contacts);
        }
        [HttpPost]
        public async Task<IActionResult> UploadCsv(IFormFile file)
        {
            await _uploadCsv.AddContactsFromCsvAsync(file);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Contact contact)
        {
            await _editContact.EditExistedContact(contact);
            return RedirectToAction("Index");
        }
    }
}