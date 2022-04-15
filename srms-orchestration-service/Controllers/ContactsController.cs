using Microsoft.AspNetCore.Mvc;
using srms_orchestration_service.Dto;
using srms_orchestration_service.Services;
using System.Threading.Tasks;

namespace srms_orchestration_service.Controllers
{
    [Route("api/contacts/mycontacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsService _contactsService;

        public ContactsController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        [HttpGet("{contactId}")]
        public async Task<ContactDto> GetContact(string contactId)
        {
            return await _contactsService.GetContact(contactId);
        }

        [HttpPost]
        public async Task<ContactDto> CreateContact(ContactDto newContact)
        {
            ContactDto contactDto = new ContactDto
            {
                BirthDate = new System.DateTime(1997, 01, 15),
                FirstName = "Rodrigo",
                LastName = "Aguirre",
                UserId = "961e7e8d-0022-40f7-9844-074acbb18a81"
            };
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
    }
}
