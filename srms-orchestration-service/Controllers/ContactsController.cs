using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using srms_orchestration_service.Constants;
using srms_orchestration_service.Dto;
using srms_orchestration_service.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace srms_orchestration_service.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsService _contactsService;

        public ContactsController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        [HttpGet]
        public async Task<List<ContactDto>> GetUserContacts()
        {
            string userId = GetHeaderFromRequest(HeaderNames.USER_ID);
            return await _contactsService.GetUserContacts(userId);
        }

        [HttpGet("{contactId}")]
        public async Task<ContactDto> GetContact(string contactId)
        {
            return await _contactsService.GetContact(contactId);
        }

        [HttpPost]
        public async Task<ContactDto> CreateContact(ContactDto newContact)
        {
            newContact.ContactId = null;
            return await _contactsService.CreateContact(newContact);
        }

        [HttpPut("{contactId}")]
        public async Task<ContactDto> UpdateContact(string contactId, ContactDto contactDto)
        {
            return await _contactsService.CreateContact(contactDto);
        }

        [HttpDelete("{contactId}")]
        public async Task<IActionResult> DeleteContact(string contactId)
        {
            bool deleted = await _contactsService.DeleteContact(contactId);
            if (deleted)
            {
                return Ok();
            }
            return StatusCode(500, "Unable to delete contact");
        }

        private string GetHeaderFromRequest(string headerName)
        {
            bool retrieved = Request.Headers.TryGetValue(headerName, out StringValues retrievedHeader);
            if (!retrieved)
            {
                Console.WriteLine("Error :c");
            }
            return retrievedHeader;
        }
    }
}
