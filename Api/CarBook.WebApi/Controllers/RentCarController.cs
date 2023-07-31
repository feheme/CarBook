using AutoMapper;
using CarBook.BusinessLayer.Abstract;
using CarBook.BusinessLayer.ValidationRules.DetailDtoValidator;
using CarBook.BusinessLayer.ValidationRules.RentCarDtoValidator;
using CarBook.EntityLayer.Concrete;
using CarBook.EntityLayer.Dtos.DetailDto;
using CarBook.EntityLayer.Dtos.RentCarDto;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentCarController : ControllerBase
    {
        private readonly IRentCarService _rentCarService;
        private readonly IMapper _mapper;


        public RentCarController(IRentCarService rentCarService, IMapper mapper)
        {
            _rentCarService = rentCarService;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult RentCarList()
        {
            var values = _rentCarService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddRentCar(AddRentCarDto addRentCarDto)
        {
            AddRentCarDtoValidator validationRules = new AddRentCarDtoValidator();
            ValidationResult result = validationRules.Validate(addRentCarDto);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var values = _mapper.Map<RentCar>(addRentCarDto);
            _rentCarService.TInsert(values);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteRentCar(int id)
        {
            var values = _rentCarService.TGetByID(id);
            _rentCarService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateRentCar(UpdateRentCarDto updateRentCarDto)
        {
            UpdateRentCarDtoValidator validationRules = new UpdateRentCarDtoValidator();
            ValidationResult result = validationRules.Validate(updateRentCarDto);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            var values = _mapper.Map<RentCar>(updateRentCarDto);

            _rentCarService.TUpdate(values);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetRentCar(int id)
        {
            var values = _rentCarService.TGetByID(id);
            return Ok(values);
        }


        [HttpGet("[action]")]
        public IActionResult RentCarApproved(int id)
        {
            _rentCarService.TRentCarStatusChangeApproved(id);
            return Ok();
        }
        [HttpGet("[action]")]
        public IActionResult RentCarCancel(int id)
        {
            _rentCarService.TRentCarStatusChangeCancel(id);
            return Ok();
        }
        [HttpGet("[action]")]
        public IActionResult RentCarWait(int id)
        {
            _rentCarService.TRentCarStatusChangeWait(id);
            return Ok();
        }
    }
}
