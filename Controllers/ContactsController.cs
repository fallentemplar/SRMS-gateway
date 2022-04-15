using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using srms_orchestration_service.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace srms_orchestration_service.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactsServiceImpl _contactsService;

        public ContactsController(ContactsServiceImpl contactsService)
        {
            _contactsService = contactsService;
        }
        [HttpGet]
        public async Task Get()
        {
            await _contactsService.CreateContact();
        }
    }
}
