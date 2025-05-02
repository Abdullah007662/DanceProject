using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceDTOLayer.WebUIDTO.TestimonialDTO
{
	public class GetByIdTestimonialDTO
	{
		public int TestimonialID { get; set; }
		public string? NameSurname { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
		public string? ImageUrl { get; set; }
	}
}
