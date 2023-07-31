using AutoMapper;
using CarBook.BusinessLayer.Abstract;
using CarBook.BusinessLayer.ValidationRules.CarDtoValidator;
using CarBook.EntityLayer.Concrete;
using CarBook.EntityLayer.Dtos.CarDto;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;



        public CarController(ICarService carService, IMapper mapper, ILogger<CarController> logger)
        {
            _carService = carService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult CarList()
        {
            var values = _carService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddCar(AddCarDto addCarDto)
        {
            AddCarDtoValidator validationRules = new AddCarDtoValidator();
            ValidationResult result = validationRules.Validate(addCarDto);
            if (!result.IsValid)
            {
               
                return BadRequest(result.Errors);
            }

            var values = _mapper.Map<Car>(addCarDto);
            _carService.TInsert(values);

           
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteCar(int id)
        {
            var values = _carService.TGetByID(id);
            _carService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateCar(UpdateCarDto updateCarDto)
        {
            UpdateCarDtoValidator validationRules = new UpdateCarDtoValidator();
            ValidationResult result = validationRules.Validate(updateCarDto);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            var values = _mapper.Map<Car>(updateCarDto);

            _carService.TUpdate(values);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetCar(int id)
        {
            var values = _carService.TGetByID(id);
            return Ok(values);
        }
    }
}
