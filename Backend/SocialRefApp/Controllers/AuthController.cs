using System;
using Microsoft.AspNetCore.Mvc;
using SocialRefApp.Dtos.User;
using SocialRefApp.Models;
using SocialRefApp.Repository.Auth;

namespace SocialRefApp.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly IAuthRepository _autoRepository;

		public AuthController(IAuthRepository authRepository)
		{
			_autoRepository = authRepository;
		}

		// [HttpPost("Register")]
		// public async Task<ActionResult<ServiceResponse<string>>> Register(UserRegisterDto request)
		// {
		// 	var response = await _autoRepository.Register(
		// 		new Entities.User { EmailAddress = request.EmailAddress.ToLower() }, request.Password
		// 		);

		// 	if (!response.Success)
		// 	{
		// 		return BadRequest(response);

		// 	}

		// 	return Ok(response);

		// }

        // [HttpPost("Login")]
        // public async Task<ActionResult<ServiceResponse<int>>> Login(UserLoginDto request)
        // {
        //     var response = await _autoRepository.Login(
        //         request.EmailAddress, request.Password
        //         );

        //     if (!response.Success)
        //     {
        //         return BadRequest(response);

        //     }

        //     return Ok(response);

        // }

        // [HttpPost("UserExists")]
        // public async Task<ActionResult<ServiceResponse<bool>>> UserExists(UserExistsDto request)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest("Invalid model");
        //     }

        //     var response = await _autoRepository.UserExists(
        //         request.EmailAddress
        //         );

        //     if (!response.Success)
        //     {
        //         return BadRequest(response);

        //     }

        //     return Ok(response);

        // }

        // [HttpPost("ForgotPasswordRequest/{emailAddress}")]
        // public async Task<ActionResult<ServiceResponse<bool>>> ForgotPasswordRequest([FromRoute]string emailAddress)
        // {

        //     if (string.IsNullOrEmpty(emailAddress))
        //     {
        //         return BadRequest("Invalid Email address");
        //     }

        //     var response = await _autoRepository.ForgotPasswordRequest(
        //         emailAddress
        //         );

        //     return Ok(response);

        // }

        // [HttpPost("ForgotPasswordCodeVerify/{emailAddress}/{code}")]
        // public async Task<ActionResult<ServiceResponse<bool>>> ForgotPasswordCodeVerify([FromRoute]string emailAddress,[FromRoute]string code)
        // {

        //     if (string.IsNullOrEmpty(emailAddress))
        //     {
        //         return BadRequest("Invalid Email address");
        //     }

        //     if (string.IsNullOrEmpty(code))
        //     {
        //         return BadRequest("Invalid code");
        //     }

        //     var response = await _autoRepository.ForgotPasswordCodeVerify(
        //         emailAddress,code
        //         );


        //     if (!response.Success)
        //     {
        //         return BadRequest(response.Message);

        //     }

        //     return Ok(response);

        // }

        // [HttpPost("ForgotSetNewPassword/{emailAddress}/{newPassword}")]
        // public async Task<ActionResult<ServiceResponse<bool>>> ForgotSetNewPassword([FromRoute]string emailAddress,[FromRoute]string newPassword)
        // {
        //     if (string.IsNullOrEmpty(emailAddress))
        //     {
        //         return BadRequest("Invalid Email address");
        //     }

        //     if (string.IsNullOrEmpty(newPassword))
        //     {
        //         return BadRequest("Invalid password");
        //     }


        //     var response = await _autoRepository.ForgotSetNewPassword(
        //         emailAddress,newPassword
        //         );

        //     if (!response.Success)
        //     {
        //         return BadRequest(response.Message);

        //     }

        //     return Ok(response);

        // }

    }
}

