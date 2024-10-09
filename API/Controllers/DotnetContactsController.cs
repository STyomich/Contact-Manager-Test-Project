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
    [Route("/")]
    public class DotnetContactsController : Controller
    {
        private readonly UploadCsvFile _uploadCsv;
        private readonly GetContactsList _getContactsList;
        private readonly EditContact _editContact;
        private readonly FindContact _findContact;
        private readonly DeleteContact _deleteContact;

        public DotnetContactsController(UploadCsvFile uploadCsv, GetContactsList getContactsList, EditContact editContact, FindContact findContact, DeleteContact deleteContact)
        {
            _uploadCsv = uploadCsv;
            _getContactsList = getContactsList;
            _editContact = editContact;
            _findContact = findContact;
            _deleteContact = deleteContact;
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
        [HttpGet]
        [Route("edit/{Id}")]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var contact = await _findContact.GetContactById(Id);
            return View(contact);
        }
        [HttpPost]
        [Route("edit/{Id}")]
        public async Task<IActionResult> Edit(Contact contact)
        {
            await _editContact.EditExistedContact(contact);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("delete/{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            await _deleteContact.DeleteContactById(Id);
            return RedirectToAction("Index");
        }
    }
}