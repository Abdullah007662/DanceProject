using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceDTOLayer.WebApiDTO.PriceDTO
{
	public class GetByIdPriceDTO
	{
		public int PriceID { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
		public int Fiyat { get; set; }
	}
}
