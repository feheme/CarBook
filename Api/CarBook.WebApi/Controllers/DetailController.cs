using AutoMapper;
using CarBook.BusinessLayer.Abstract;
using CarBook.BusinessLayer.ValidationRules.ContactDtoValidator;
using CarBook.BusinessLayer.ValidationRules.DetailDtoValidator;
using CarBook.EntityLayer.Concrete;
using CarBook.EntityLayer.Dtos.ContactDto;
using CarBook.EntityLayer.Dtos.DetailDto;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailController : ControllerBase
    {
        private readonly IDetailService _detailService;
        private readonly IMapper _mapper;


        public DetailController(IDetailService detailService, IMapper mapper)
        {
            _detailService = detailService;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult DetailList()
        {
            var values = _detailService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddDetail(AddDetailDto addDetailDto)
        {
            AddDetailDtoValidator validationRules = new AddDetailDtoValidator();
            ValidationResult result = validationRules.Validate(addDetailDto);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var values = _mapper.Map<Detail>(addDetailDto);
            _detailService.TInsert(values);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteDetail(int id)
        {
            var values = _detailService.TGetByID(id);
            _detailService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateDetail(UpdateDetailDto updateDetailDto)
        {
            UpdateDetailDtoValidator validationRules = new UpdateDetailDtoValidator();
            ValidationResult result = validationRules.Validate(updateDetailDto);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            var values = _mapper.Map<Detail>(updateDetailDto);

            _detailService.TUpdate(values);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetDetail(int id)
        {
            var values = _detailService.TGetByID(id);
            return Ok(values);
        }
       
    }
}
