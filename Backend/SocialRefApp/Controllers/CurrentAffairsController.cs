using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialRefApp.Dtos.CurrentAffairs;
using SocialRefApp.Entities;
using SocialRefApp.Models;
using SocialRefApp.Services.CurrentAffairService;

namespace SocialRefApp.Controllers
{
    [Authorize]
    [ApiController]
	[Route("[controller]")]
	public class CurrentAffairsController : ControllerBase
	{
		private readonly ICurrentAffairService _currentAffairService;

		public CurrentAffairsController(ICurrentAffairService currentAffairService)
		{
			_currentAffairService = currentAffairService;
		}

        // [AllowAnonymous]
        // [HttpPost("GetBySearch")]
        // public async Task<ActionResult<ServiceResponse<List<CurrentAffairsGetResponseDto>>>> GetBySearch()
        // {
        //     return Ok(await _currentAffairService.GetCurrentAffairsListBySearch());
        // }

        // [AllowAnonymous]
        // [HttpGet("{id}")]
        // public async Task<ActionResult<ServiceResponse<CurrentAffairsGetResponseDto>>> GetByID(int id)
        // {
        //     return Ok(await _currentAffairService.GetCurrentAffairById(id));
        // }

        // [AllowAnonymous]
        // [HttpPost()]
        // public async Task<ActionResult<ServiceResponse<bool>>> Add(CurrentAffairsAddRequestDto request)
        // {
        //     return Ok(await _currentAffairService.AddCurrentAffair(request));
        // }

        // [AllowAnonymous]
        // [HttpPut()]
        // public async Task<ActionResult<ServiceResponse<bool>>> Update(CurrentAffairUpdateRequestDto request)
        // {
        //     return Ok(await _currentAffairService.UpdateCurrentAffair(request));
        // }

        // [AllowAnonymous]
        // [HttpPost("ChangeStatus")]
        // public async Task<ActionResult<ServiceResponse<bool>>> ChangeStatus(CurrentAffairStatusRequestDto request)
        // {
        //     return Ok(await _currentAffairService.StatusChangeCurrentAffair(request));
        // }

        // [HttpGet("GetUserSavedCurrentAffairsBySearch")]
        // public async Task<ActionResult<ServiceResponse<List<CurrentAffairs>>>> GetUserSavedCurrentAffairsBySearch()
        // {
        //     int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);
        //     return Ok(await _currentAffairService.GetUserSavedCurrentAffairsBySearch(userId));
        // }
      
        // [HttpPost("PostAddCurrentAffairsSavedByUser/{currentAffairId}")]
        // public async Task<ActionResult<ServiceResponse<bool>>> PostAddCurrentAffairsSavedByUser(int currentAffairId)
        // {
        //     int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);
        //     return Ok(await _currentAffairService.AddCurrentAffairsSavedByUser(currentAffairId, userId));
        // }

        // [HttpPost("PostRemoveCurrentAffairsSavedByUser/{currentAffairId}")]
        // public async Task<ActionResult<ServiceResponse<bool>>> PostRemoveCurrentAffairsSavedByUser(int currentAffairId)
        // {
        //     int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);
        //     return Ok(await _currentAffairService.RemoveCurrentAffairsSavedByUser(currentAffairId, userId));
        // }    

    }
}

   