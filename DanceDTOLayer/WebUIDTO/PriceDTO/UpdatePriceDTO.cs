using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceDTOLayer.WebUIDTO.PriceDTO
{
	public class UpdatePriceDTO
	{
		public int PriceID { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
		public int Fiyat { get; set; }
	}
}
