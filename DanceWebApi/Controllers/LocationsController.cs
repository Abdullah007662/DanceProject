using AutoMapper;
using DanceBusinessLayer.Abstract;
using DanceDTOLayer.WebApiDTO.LocationDTO;
using DanceEntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DanceWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LocationsController : ControllerBase
	{
		private readonly ILocationService _locationService;
		private readonly IMapper _mapper;

		public LocationsController(ILocationService locationService, IMapper mapper)
		{
			_locationService = locationService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult LocationList()
		{
			var locationsDTOs = _mapper.Map<List<ResultLocationDTO>>(_locationService.BGetListAll());
			return Ok(locationsDTOs);
		}
		[HttpPost]
		public IActionResult CreateLocation(CreateLocationDTO createLocationDTO)
		{
			_locationService.BAdd(_mapper.Map<Location>(createLocationDTO));
			return Ok("Konum bilgisi başarıyla eklendi.");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteLocation(int id)
		{
			var location = _locationService.BGetById(id);
			_locationService.BDelete(location);
			return Ok("Konum bilgisi başarıyla silindi.");
		}
		[HttpPut]
		public IActionResult UpdateLocation(UpdateLocationDTO updateLocationDTO)
		{
			_locationService.BUpdate(_mapper.Map<Location>(updateLocationDTO));
			return Ok("Konum bilgisi başarıyla güncellendi.");
		}
		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var value = _locationService.BGetById(id);
			return Ok(value);
		}
	}
}
