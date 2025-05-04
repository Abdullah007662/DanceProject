using AutoMapper;
using DanceBusinessLayer.Abstract;
using DanceDTOLayer.WebApiDTO.TestimonialDTO;
using DanceEntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;  // Burada System.IO'yu kullanarak, sınıf çakışmasını önlüyoruz.


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
		public async Task<IActionResult> CreateTestimonial([FromForm] CreateTestimonialDTO dto, IFormFile? image)
		{
			var testimonial = new Testimonial
			{
				NameSurname = dto.NameSurname,
				Title = dto.Title,
				Description = dto.Description
			};

			if (image != null)
			{
				// Dosya adı güncelleniyor: Gün-Ay-Yıl formatında
				var fileName = $"{DateTime.Now:yyyyMMdd}-{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
				var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/TestimonialImages", fileName);

				// Dosyayı sunucuya kaydetme
				using (var stream = new FileStream(imagePath, FileMode.Create))
				{
					await image.CopyToAsync(stream);
				}

                // Yeni dosyanın yolunu kaydet
                testimonial.ImageUrl = $"{Request.Scheme}://{Request.Host}/TestimonialImages/{fileName}";

            }

            _testimonialService.BAdd(testimonial);
			return Ok("Kullanıcı başarıyla eklendi.");
		}

        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial([FromForm] UpdateTestimonialDTO updateTestimonialDTO, IFormFile? image)
        {
            var testimonial = _testimonialService.BGetById(updateTestimonialDTO.TestimonialID);
            if (testimonial == null)
            {
                return NotFound("Testimonial bulunamadı.");
            }

            // Metinsel alanları güncelle
            testimonial.NameSurname = updateTestimonialDTO.NameSurname;
            testimonial.Title = updateTestimonialDTO.Title;
            testimonial.Description = updateTestimonialDTO.Description;

            // Eğer yeni bir resim yüklendiyse, eskiyi silip yenisini kaydet
            if (image != null)
            {
                // Eski resmi sil (varsa)
                if (!string.IsNullOrEmpty(testimonial.ImageUrl))
                {
                    var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", testimonial.ImageUrl.TrimStart('/'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                // Yeni resmi kaydet
                var fileName = $"{DateTime.Now:yyyyMMdd}-{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/TestimonialImages", fileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                testimonial.ImageUrl = "/TestimonialImages/" + fileName;
            }

            // Eğer yeni görsel gelmediyse ImageUrl değişmez (mevcut haliyle kalır)
            _testimonialService.BUpdate(testimonial);
            return Ok("Testimonial başarıyla güncellendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var testimonial = _testimonialService.BGetById(id);
            if (testimonial == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }

            // Görsel varsa sil
            if (!string.IsNullOrEmpty(testimonial.ImageUrl))
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", testimonial.ImageUrl.TrimStart('/'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _testimonialService.BDelete(testimonial);
            return Ok("Kullanıcı bilgisi başarıyla silindi.");
        }

        [HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var value = _testimonialService.BGetById(id);
			return Ok(value);
		}
	}
}

