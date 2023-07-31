using AutoMapper;


using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CarBook.BusinessLayer.Abstract;
using CarBook.EntityLayer.Dtos.ServiceDto;

using CarBook.EntityLayer.Concrete;
using CarBook.BusinessLayer.ValidationRules.ServiceDtoValidator;

namespace ServiceBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;


        public ServiceController(IServiceService serviceService, IMapper mapper)
        {
            _serviceService = serviceService;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _serviceService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddService(AddServiceDto addServiceDto)
        {
            AddServiceDtoValidator validationRules = new AddServiceDtoValidator();
            ValidationResult result = validationRules.Validate(addServiceDto);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var values = _mapper.Map<Service>(addServiceDto);
            _serviceService.TInsert(values);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var values = _serviceService.TGetByID(id);
            _serviceService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateService(UpdateServiceDto updateServiceDto)
        {
            UpdateServiceDtoValidator validationRules = new UpdateServiceDtoValidator();
            ValidationResult result = validationRules.Validate(updateServiceDto);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            var values = _mapper.Map<Service>(updateServiceDto);

            _serviceService.TUpdate(values);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetService(int id)
        {
            var values = _serviceService.TGetByID(id);
            return Ok(values);
        }
    }
}
