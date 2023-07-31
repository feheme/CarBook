using AutoMapper;
using CarBook.BusinessLayer.Abstract;
using CarBook.BusinessLayer.ValidationRules.TestimonialDtoValidator;
using CarBook.EntityLayer.Concrete;
using CarBook.EntityLayer.Dtos.TestimonialDto;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;


        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _testimonialService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddTestimonial(AddTestimonialDto addTestimonialDto)
        {
            AddTestimonialDtoValidator validationRules = new AddTestimonialDtoValidator();
            ValidationResult result = validationRules.Validate(addTestimonialDto);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var values = _mapper.Map<Testimonial>(addTestimonialDto);
            _testimonialService.TInsert(values);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var values = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            UpdateTestimonialDtoValidator validationRules = new UpdateTestimonialDtoValidator();
            ValidationResult result = validationRules.Validate(updateTestimonialDto);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            var values = _mapper.Map<Testimonial>(updateTestimonialDto);

            _testimonialService.TUpdate(values);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var values = _testimonialService.TGetByID(id);
            return Ok(values);
        }
    }
}
