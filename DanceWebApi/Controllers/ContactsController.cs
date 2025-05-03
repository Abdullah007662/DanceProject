using AutoMapper;
using DanceBusinessLayer.Abstract;
using DanceDTOLayer.WebApiDTO.ContactDTO;
using DanceEntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DanceWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly IContactService _contactService;
		private readonly IMapper _mapper;

		public ContactsController(IContactService contactService, IMapper mapper)
		{
			_contactService = contactService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult ContactList()
		{
			var contactDTOs = _mapper.Map<List<ResultContactDTO>>(_contactService.BGetListAll());
			return Ok(contactDTOs);
		}
		[HttpPost]
		public IActionResult CreateContact(CreateContactDTO createContactDTO)
		{
			_contactService.BAdd(_mapper.Map<Contact>(createContactDTO));
			return Ok("İletişim bilgisi başarıyla eklendi.");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteContact(int id)
		{
			var contact = _contactService.BGetById(id);
			_contactService.BDelete(contact);
			return Ok("İletişim bilgisi başarıyla silindi.");
		}
		[HttpPut]
		public IActionResult UpdateContact(UpdateContactDTO updateContactDTO)
		{
			_contactService.BUpdate(_mapper.Map<Contact>(updateContactDTO));
			return Ok("İletişim bilgisi başarıyla güncellendi.");
		}
		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var value = _contactService.BGetById(id);
			return Ok(value);
		}
	}
}
