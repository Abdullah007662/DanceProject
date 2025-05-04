using Microsoft.AspNetCore.Mvc;

namespace DanceWebUI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

#region Deneme Yaptım
/*
 * 			// Eski resmin silinmesi için kontrol
			if (!string.IsNullOrEmpty(testimonial.ImageUrl))
			{
				// Eski dosyanın yolu
				var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", testimonial.ImageUrl.TrimStart('/'));

				// Eğer eski dosya varsa sil
				if (System.IO.File.Exists(oldImagePath))
				{
					System.IO.File.Delete(oldImagePath);
				}
			}
//[HttpPut]
		//public IActionResult UpdateTestimonial(UpdateTestimonialDTO updateTestimonialDTO)
		//{
		//	_testimonialService.BUpdate(_mapper.Map<Testimonial>(updateTestimonialDTO));
		//	return Ok("Kullanıcı bilgisi başarıyla güncellendi.");
		//}
 */
#endregion