using AutoMapper;
using DanceBusinessLayer.Abstract;
using DanceDTOLayer.WebApiDTO.PriceDTO;
using DanceEntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DanceWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PricesController : ControllerBase
	{
		private readonly IPriceService _priceService;
		private readonly IMapper _mapper;

		public PricesController(IPriceService priceService, IMapper mapper)
		{
			_priceService = priceService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult PriceList()
		{
			var priceDTOs = _mapper.Map<List<ResultPriceDTO>>(_priceService.BGetListAll());
			return Ok(priceDTOs);
		}
		[HttpPost]
		public IActionResult CreatePrice(CreatePriceDTO createPriceDTO)
		{
			_priceService.BAdd(_mapper.Map<Price>(createPriceDTO));
			return Ok("Fiyat bilgisi başarıyla eklendi.");
		}

		[HttpDelete("{id}")]
		public IActionResult DeletePrice(int id)
		{
			var price = _priceService.BGetById(id);
			_priceService.BDelete(price);
			return Ok("Fiyat bilgisi başarıyla silindi.");
		}
		[HttpPut]
		public IActionResult UpdatePrice(UpdatePriceDTO updatePriceDTO)
		{
			_priceService.BUpdate(_mapper.Map<Price>(updatePriceDTO));
			return Ok("Fiyat bilgisi başarıyla güncellendi.");
		}
		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var value = _priceService.BGetById(id);
			return Ok(value);
		}
	}
}
