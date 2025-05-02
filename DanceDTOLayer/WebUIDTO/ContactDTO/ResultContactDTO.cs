using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceDTOLayer.WebUIDTO.ContactDTO
{
	public class ResultContactDTO
	{
		public int ContactID { get; set; }
		public string? NameSurname { get; set; }
		public string? PhoneNumber { get; set; }
		public string? Email { get; set; }
		public string? Message { get; set; }
	}
}
