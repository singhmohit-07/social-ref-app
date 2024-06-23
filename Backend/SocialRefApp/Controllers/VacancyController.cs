using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialRefApp.Dtos.Vacancy;
using SocialRefApp.Entities;
using SocialRefApp.Models;
using SocialRefApp.Services.VacancyService;

namespace SocialRefApp.Controllers
{
    [Authorize]
    [ApiController]
	[Route("[controller]")]
	public class VacancyController : ControllerBase
	{
		private readonly IVacancyService _vacancyService;

		public VacancyController(IVacancyService vacancyService)
		{
            _vacancyService = vacancyService;
		}

        // [AllowAnonymous]
        // [HttpPost("GetBySearch")]
        // public async Task<ActionResult<ServiceResponse<List<VacancyGetResponseDto>>>> GetBySearch()
        // {
        //     return Ok(await _vacancyService.GetVacancyListBySearch());
        // }

        // [AllowAnonymous]
        // [HttpGet("{id}")]
        // public async Task<ActionResult<ServiceResponse<VacancyGetResponseDto>>> GetByID(int id)
        // {
        //     return Ok(await _vacancyService.GetVacancyById(id));
        // }

        // [AllowAnonymous]
        // [HttpPost()]
        // public async Task<ActionResult<ServiceResponse<bool>>> Add(VacancyAddRequestDto request)
        // {
        //     return Ok(await _vacancyService.AddVacancy(request));
        // }

        // [AllowAnonymous]
        // [HttpPut()]
        // public async Task<ActionResult<ServiceResponse<bool>>> Update(VacancyUpdateRequestDto request)
        // {
        //     return Ok(await _vacancyService.UpdateVacancy(request));
        // }

        // [AllowAnonymous]
        // [HttpPost("ChangeStatus")]
        // public async Task<ActionResult<ServiceResponse<bool>>> ChangeStatus(VacancyStatusRequestDto request)
        // {
        //     return Ok(await _vacancyService.StatusChangeVacancy(request));
        // }

        // [HttpGet("GetUserSavedVacancyBySearch")]
        // public async Task<ActionResult<ServiceResponse<List<Vacancy>>>> GetUserSavedVacancyBySearch()
        // {
        //     int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);
        //     return Ok(await _vacancyService.GetUserSavedVacanciesBySearch(userId));
        // }
      
        // [HttpPost("PostAddVacancySavedByUser/{vacancyId}")]
        // public async Task<ActionResult<ServiceResponse<bool>>> PostAddVacancySavedByUser(int vacancyId)
        // {
        //     int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);
        //     return Ok(await _vacancyService.AddVacancySavedByUser(vacancyId, userId));
        // }

        // [HttpPost("PostRemoveVacancySavedByUser/{vacancyId}")]
        // public async Task<ActionResult<ServiceResponse<bool>>> PostRemoveVacancySavedByUser(int vacancyId)
        // {
        //     int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);
        //     return Ok(await _vacancyService.RemoveVacancySavedByUser(vacancyId, userId));
        // }
        
    }
}

   