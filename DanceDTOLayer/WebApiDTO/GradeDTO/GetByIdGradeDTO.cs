using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceDTOLayer.WebApiDTO.GradeDTO
{
	public class GetByIdGradeDTO
	{
		public int GradeID { get; set; }
		public string? Title { get; set; }
		public string? SmallTitle { get; set; }
		public string? ImageUrl { get; set; }
	}
}
