using AutoMapper;
using DanceBusinessLayer.Abstract;
using DanceDTOLayer.WebApiDTO.TestimonialDTO;
using DanceEntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DanceWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialsController : ControllerBase
	{
		private readonly ITestimonialService _testimonialService;
		private readonly IMapper _mapper;

		public TestimonialsController(ITestimonialService testimonialService, IMapper mapper)
		{
			_testimonialService = testimonialService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult TestimonialList()
		{
			var testimonialDTOs = _mapper.Map<List<ResultTestimonialDTO>>(_testimonialService.BGetListAll());
			return Ok(testimonialDTOs);
		}
		[HttpPost]
		public IActionResult CreateTestimonial(CreateTestimonialDTO createTestimonialDTO)
		{
			_testimonialService.BAdd(_mapper.Map<Testimonial>(createTestimonialDTO));
			return Ok("Kullanıcı bilgisi başarıyla eklendi.");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteTestimonial(int id)
		{
			var testimonial = _testimonialService.BGetById(id);
			_testimonialService.BDelete(testimonial);
			return Ok("Kullanıcı bilgisi başarıyla silindi.");
		}
		[HttpPut]
		public IActionResult UpdateTestimonial(UpdateTestimonialDTO updateTestimonialDTO)
		{
			_testimonialService.BUpdate(_mapper.Map<Testimonial>(updateTestimonialDTO));
			return Ok("Kullanıcı bilgisi başarıyla güncellendi.");
		}
		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var value = _testimonialService.BGetById(id);
			return Ok(value);
		}
	}
}
