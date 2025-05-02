using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceDTOLayer.WebUIDTO.LocationDTO
{
	public class ResultLocationDTO
	{
		public int LocationID { get; set; }
		public string? GoogleMapLink { get; set; }
		public string? iFrame { get; set; }
		public string? PhoneNumber { get; set; }
		public string? Email { get; set; }
	}
}
