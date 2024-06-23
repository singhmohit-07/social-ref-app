using System;
using System.ComponentModel.DataAnnotations;

namespace SocialRefApp.Dtos.User
{
	public class UserExistsDto
	{

		[Required]
		public required string EmailAddress { get; set; }

	}
}

