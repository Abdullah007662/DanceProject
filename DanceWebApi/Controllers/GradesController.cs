using AutoMapper;
using DanceBusinessLayer.Abstract;
using DanceDTOLayer.WebApiDTO.GradeDTO;
using DanceEntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DanceWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GradesController : ControllerBase
	{
		private readonly IGradeService _gradeService;
		private readonly IMapper _mapper;

		public GradesController(IGradeService gradeService, IMapper mapper)
		{
			_gradeService = gradeService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GradeList()
		{
			var gradeDTOs = _mapper.Map<List<ResultGradeDTO>>(_gradeService.BGetListAll());
			return Ok(gradeDTOs);
		}
		[HttpPost]
		public IActionResult CreateGrade(CreateGradeDTO createGradeDTO)
		{
			_gradeService.BAdd(_mapper.Map<Grade>(createGradeDTO));
			return Ok("Sınıf bilgisi başarıyla eklendi.");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteGrade(int id)
		{
			var grade = _gradeService.BGetById(id);
			_gradeService.BDelete(grade);
			return Ok("Sınıf bilgisi başarıyla silindi.");
		}
		[HttpPut]
		public IActionResult UpdateGrade(UpdateGradeDTO updateGradeDTO)
		{
			_gradeService.BUpdate(_mapper.Map<Grade>(updateGradeDTO));
			return Ok("sınıf bilgisi başarıyla güncellendi.");
		}
		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var value = _gradeService.BGetById(id);
			return Ok(value);
		}
	}
}
