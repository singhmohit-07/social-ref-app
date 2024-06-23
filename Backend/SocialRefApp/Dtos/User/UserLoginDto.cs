using System;
using System.ComponentModel.DataAnnotations;

namespace SocialRefApp.Dtos.User
{
	public class UserLoginDto
	{

		[Required]
		public required string EmailAddress { get; set; }

		[Required]
        public required string Password { get; set; }

    }
}

