using AutoMapper;
using DanceDTOLayer.WebUIDTO.AboutDTO;
using DanceDTOLayer.WebUIDTO.ContactDTO;
using DanceDTOLayer.WebUIDTO.GradeDTO;
using DanceDTOLayer.WebUIDTO.LocationDTO;
using DanceDTOLayer.WebUIDTO.PriceDTO;
using DanceDTOLayer.WebUIDTO.TestimonialDTO;
using DanceEntityLayer.Entities;

namespace DanceWebUI.Mapping
{
	public class GeneralMapping:Profile
	{
		public GeneralMapping()
		{
			#region About 
			CreateMap<About, CreateAboutDTO>().ReverseMap();
			CreateMap<About, ResultAboutDTO>().ReverseMap();
			CreateMap<About, UpdateAboutDTO>().ReverseMap();
			CreateMap<About, GetByIdAboutDTO>().ReverseMap();
			#endregion

			#region Contact
			CreateMap<Contact, CreateContactDTO>().ReverseMap();
			CreateMap<Contact, UpdateContactDTO>().ReverseMap();
			CreateMap<Contact, ResultContactDTO>().ReverseMap();
			CreateMap<Contact, GetByIdContactDTO>().ReverseMap();
			#endregion

			#region Grade

			CreateMap<Grade, CreateGradeDTO>().ReverseMap();
			CreateMap<Grade, UpdateGradeDTO>().ReverseMap();
			CreateMap<Grade, ResultGradeDTO>().ReverseMap();
			CreateMap<Grade, GetByIdGradeDTO>().ReverseMap();
			#endregion

			#region Location
			CreateMap<Location, CreateLocationDTO>().ReverseMap();
			CreateMap<Location, UpdateLocationDTO>().ReverseMap();
			CreateMap<Location, ResultLocationDTO>().ReverseMap();
			CreateMap<Location, GetByIdLocationDTO>().ReverseMap();
			#endregion

			#region Price
			CreateMap<Price, CreatePriceDTO>().ReverseMap();
			CreateMap<Price, ResultPriceDTO>().ReverseMap();
			CreateMap<Price, UpdatePriceDTO>().ReverseMap();
			CreateMap<Price, GetByIdPriceDTO>().ReverseMap();
			#endregion

			#region Testimonial
			CreateMap<Testimonial, CreateTestimonialDTO>().ReverseMap();
			CreateMap<Testimonial, UpdateTestimonialDTO>().ReverseMap();
			CreateMap<Testimonial, ResultTestimonialDTO>().ReverseMap();
			CreateMap<Testimonial, GetByIdTestimonialDTO>().ReverseMap();
			#endregion
		}
	}
}
