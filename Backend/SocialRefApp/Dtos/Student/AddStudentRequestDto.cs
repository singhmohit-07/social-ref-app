using System;
using System.ComponentModel.DataAnnotations;
using SocialRefApp.Enums;

namespace SocialRefApp.Dtos.Student
{
	public class AddStudentRequestDto
	{
        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        public required string Gender { get; set; }

    }
}

