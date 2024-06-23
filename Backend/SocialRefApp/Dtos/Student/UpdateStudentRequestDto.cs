using System;
using SocialRefApp.Enums;

namespace SocialRefApp.Dtos.Student
{
	public class UpdateStudentRequestDto
	{
        public int StudentId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Gender { get; set; }

        public string? DateOfBirth { get; set; }

        public string? SubCategorySelected { get; set; }

        public bool? EmailNewsletterPreference { get; set; } = true;
    }
}

