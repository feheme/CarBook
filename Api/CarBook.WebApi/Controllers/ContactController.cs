using AutoMapper;
using CarBook.BusinessLayer.Abstract;
using CarBook.BusinessLayer.ValidationRules.CarDtoValidator;
using CarBook.BusinessLayer.ValidationRules.ContactDtoValidator;
using CarBook.EntityLayer.Concrete;
using CarBook.EntityLayer.Dtos.CarDto;
using CarBook.EntityLayer.Dtos.ContactDto;
using FluentValidation;
using FluentValidation.Results;

using Microsoft.AspNetCore.Mvc;

namespace ContactBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;


        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _contactService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddContact(AddContactDto addContactDto)
        {
            addContactDto.Date = DateTime.Now;
            AddContactDtoValidator validationRules = new AddContactDtoValidator();
            ValidationResult result = validationRules.Validate(addContactDto);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var values = _mapper.Map<Contact>(addContactDto);
            _contactService.TInsert(values);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var values = _contactService.TGetByID(id);
            _contactService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            updateContactDto.Date = DateTime.Now;

            UpdateContactDtoValidator validationRules = new UpdateContactDtoValidator();
            ValidationResult result = validationRules.Validate(updateContactDto);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            var values = _mapper.Map<Contact>(updateContactDto);

            _contactService.TUpdate(values);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var values = _contactService.TGetByID(id);
            return Ok(values);
        }
    }
}

